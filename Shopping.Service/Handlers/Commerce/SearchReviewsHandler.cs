using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchReviewsHandler : CommandHandler<Commands.SearchReviews>
    {
        private readonly IRepository<Review> reviewRepository;
        public SearchReviewsHandler(IRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchReviews command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;

            // define the sort expression
            Expression<Func<Review, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "email":
                    orderby = o => o.Email;
                    break;
                case "productId":
                    orderby = o => o.ProductId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Review, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.Email != null ? w.Email == command.Email : true)
                && (command.ProductId != null ? w.ProductId == command.ProductId : true);
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                
                var value = reviewRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<ReviewQuery>(x)).ToList();
                // return the paged query
                result = new Result(true,value, $"Bulunan {totalRecordCount} görüşün {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = reviewRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<ReviewQuery>(x)).ToList();
                // return the query
                 result =new Result(true,value, $"{value.Count()} adet görüş bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
