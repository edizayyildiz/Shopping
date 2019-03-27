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
    public class SearchProductsHandler : CommandHandler<Commands.SearchProducts>
    {
        private readonly IRepository<Product> productRepository;
        public SearchProductsHandler(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchProducts command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Product, object>> orderby;
            switch (command.SortField)
            {
                case "Best match":
                    orderby = o => o.RatingsCount;
                    command.SortOrder = "desc";
                    break;
                case "Lowest first":
                    orderby = o => o.NewPrice;
                    command.SortOrder = "asc";
                    break;
                case "Highest first":
                    orderby = o => o.NewPrice;
                    command.SortOrder = "desc";
                    break;
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "categoryId":
                    orderby = o => o.CategoryId;
                    break;
                case "categoryName":
                    orderby = o => o.Category.Name;
                    break;
                case "brandId":
                    orderby = o => o.BrandId;
                    break;
                case "storeId":
                    orderby = o => o.StoreId;
                    break;
                case "condition":
                    orderby = o => o.Condition;
                    break;
                case "Search by Default":
                default:

                    orderby = o => o.CreatedAt;
                    command.SortOrder = "desc";
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Product, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => ((!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) || w.AdditionalInformation.Contains(command.Name) || w.Description.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.CategoryId != null ? w.CategoryId == command.CategoryId : true)
                && (command.CategoryName != null ? w.Category.Name == command.CategoryName || w.Category.Parent.Name == command.CategoryName || w.Category.Parent.Parent.Name == command.CategoryName : true)
                && (command.BrandId != null ? w.BrandId == command.BrandId : true)
                && (command.StoreId != null ? w.StoreId == command.StoreId : true)
                && (command.IsFeatured != null ? w.IsFeatured == command.IsFeatured : true)
                && (command.IsOnSale != null ? w.IsOnSale == command.IsOnSale : true)
                && (command.IsNew != null ? w.IsNew == command.IsNew : true)
                && (command.Condition != null ? w.Condition == command.Condition : true));

            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value2 = productRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Images", "Category", "Brand", "Store");
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} ürünün {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value2 = productRepository.GetMany(where, orderby, desc, "Images", "Category", "Brand", "Store");
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet ürün bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
