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
    public class SearchNewsletterHandler : CommandHandler<Commands.SearchNewsletter>
    {
        private readonly IRepository<Newsletter> newsletterRepository;
        public SearchNewsletterHandler(IRepository<Newsletter> newsletterRepository)
        {
            this.newsletterRepository = newsletterRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchNewsletter command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Newsletter, object>> orderby;
            switch (command.SortField)
            {
                case "FullName":
                    orderby = o => o.FullName;
                    break;
                case "Email":
                    orderby = o => o.Email;
                    break;
                case "IsConfirmed":
                    orderby = o => o.IsConfirmed;
                    break;
                case "ConfirmationDate":
                    orderby = o => o.ConfirmationDate;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Newsletter, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.FullName) ? w.FullName.Contains(command.FullName) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.Email != null ? w.Email == command.Email : true);


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.FullName) ? w.FullName.Contains(command.FullName) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = newsletterRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<NewsletterQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} sayfanın {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);

            }
            else
            {
                var value = newsletterRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<NewsletterQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet sayfa bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
