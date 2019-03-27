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
    public class SearchSlidesHandler : CommandHandler<Commands.SearchSlides>
    {
        private readonly IRepository<Slide> slideRepository;
        public SearchSlidesHandler(IRepository<Slide> slideRepository)
        {
            this.slideRepository = slideRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchSlides command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;

            // define the sort expression
            Expression<Func<Slide, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "title":
                    orderby = o => o.Title;
                    break;
                case "position":
                    orderby = o => o.Position;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Slide, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                 && (command.Title != null ? w.Title == command.Title : true);



            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = slideRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Slider")
                .Select(x => Mapper.Map<SlideQuery>(x)).ToList();
                // return the paged query
                result =new Result(true, value,  $"Bulunan {totalRecordCount} slaytın {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = slideRepository.GetMany(where, orderby, desc, "Slider")
                .Select(x => Mapper.Map<SlideQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet slayt bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
