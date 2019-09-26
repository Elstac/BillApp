using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProductCategories
{
    class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategories, IEnumerable<ProductCategoryDto>>
    {
        private IDbConnectionFactory dbConnectionFactory;

        public GetAllProductCategoriesQueryHandler(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategories request, CancellationToken cancellationToken)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            const string sql = "SELECT C.Id, C.Name " +
                                "FROM ProductCategories C";

            var CategoriesCollection = connection.Query<ProductCategoryDto>(sql).ToList();

            return CategoriesCollection;
        }
    }
}
