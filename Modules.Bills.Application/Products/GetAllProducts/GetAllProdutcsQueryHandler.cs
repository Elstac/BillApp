using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using Dapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetAllProducts
{
    class GetAllProdutcsQueryHandler : IRequestHandler<GetAllProducts, ProductDto[]>
    {
        private IDbConnectionFactory dbConnectionFactory;

        public GetAllProdutcsQueryHandler(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<ProductDto[]> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            const string sql = "SELECT P.Id, P.Name, P.Barcode_Value, P.Price_Value, P.CategoryId " +
                                "FROM Products P";

            var productsCollection = connection.Query<ProductDto>(sql).ToArray();

            return productsCollection;
        }
    }
}
