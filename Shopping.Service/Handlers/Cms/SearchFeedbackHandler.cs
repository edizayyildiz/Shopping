using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchFeedbackHandler:CommandHandler<Commands.SearchFeedbacks>
    {
        private readonly IRepository<Feedback> feedbackRepository;
        public SearchFeedbackHandler(IRepository<Feedback> feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchFeedbacks command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Feedback, object>> orderby;
            switch (command.SortField)
            {
                case "Ad":
                    orderby = o => o.Name;
                    break;
                case "E-mail":
                    orderby = o => o.Email;
                    break;
                case "Konu":
                    orderby = o => o.Subject;
                    break;
                case "Mesaj":
                    orderby = o => o.Message;
                    break;
                
                    
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Feedback, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
            
                && (command.Email != null ? w.Email == command.Email : true)
                && (command.Message != null ? w.Message == command.Message : true)
                && (command.Subject != null ? w.Subject == command.Subject : true);
               


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = feedbackRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<FeedbackQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} geribildirim {command.PageNumber}. sayfasındaki kayıtlar.", false, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = feedbackRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<FeedbackQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet geri bildirim bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
