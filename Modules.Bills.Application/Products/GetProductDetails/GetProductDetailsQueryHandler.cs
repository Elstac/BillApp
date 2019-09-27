using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Application.Products.Dto;
using Dapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Products.GetProductDetails
{
    class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetails, ProductDto>
    {
        private IDbConnectionFactory dbConnectionFactory;

        public GetProductDetailsQueryHandler(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<ProductDto> Handle(GetProductDetails request, CancellationToken cancellationToken)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            const string sql = "SELECT P.Id, P.Name, P.Barcode_Value AS Barcode, P.Price_Value AS Price, P.CategoryId " +
                                "FROM Products P "+
                                "WHERE P.Id = @ProductId ";

            var product = connection.Query<ProductDto>(sql,new {request.ProductId }).FirstOrDefault();

            return product;
        }
    }
}
