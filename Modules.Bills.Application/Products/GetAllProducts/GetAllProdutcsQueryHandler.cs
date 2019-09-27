using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProducts
{
    class GetAllProdutcsQueryHandler : IRequestHandler<GetAllProducts, List<ProductDto>>
    {
        private IDbConnectionFactory dbConnectionFactory;

        public GetAllProdutcsQueryHandler(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<ProductDto>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            const string sql = "SELECT P.Id, P.Name, P.Barcode_Value AS Barcode, P.Price_Value AS Price, P.CategoryId " +
                                "FROM Products P "+
                                "WHERE P.LatestVersion = 1";

            var productsCollection = connection.Query<ProductDto>(sql).ToList();

            return productsCollection;
        }
    }
}
