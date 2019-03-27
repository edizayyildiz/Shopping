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
    public class SearchAdvertisementsHandler : CommandHandler<Commands.SearchAdvertisements>
    {
        private readonly IRepository<Advertisement> advertisementRepository;
        public SearchAdvertisementsHandler(IRepository<Advertisement> advertisementRepository)
        {
            this.advertisementRepository = advertisementRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchAdvertisements command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Advertisement, object>> orderby;
            switch (command.SortField)
            {
                case "title":
                    orderby = o => o.Title;
                    break;
                case "subTitle":
                    orderby = o => o.SubTitle;
                    break;
                case "html":
                    orderby = o => o.Html;
                    break;
                case "image":
                    orderby = o => o.Image;
                    break;
                case "location":
                    orderby = o => o.Location;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Advertisement, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Title) ? w.Title.Contains(command.Title) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.SubTitle != null ? w.SubTitle == command.SubTitle : true)
                && (command.Html != null ? w.Html == command.Html : true)
                && (command.Image != null ? w.Image == command.Image : true)
                && (command.Location != null ? w.Location == command.Location : true);


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Title) ? w.Title.Contains(command.Title) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = advertisementRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<AdvertisementQuery>(x)).ToList();
                // return the paged query
                result= new Result(true,value, $"Bulunan {totalRecordCount} reklamın {command.PageNumber}. sayfasındaki kayıtlar.", false, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = advertisementRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<AdvertisementQuery>(x)).ToList();
                // return the query
                result= new Result(true,value, $"{value.Count()} adet reklam bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
