using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchSlidersHandler : CommandHandler<Commands.SearchSliders>
    {
        private readonly IRepository<Slider> sliderRepository;
        public SearchSlidersHandler(IRepository<Slider> sliderRepository)
        {
            this.sliderRepository = sliderRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchSliders command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Slider, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Slider, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true);



            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = sliderRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<SliderQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} kaydırıcının {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = sliderRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<SliderQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet kaydırıcı bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
