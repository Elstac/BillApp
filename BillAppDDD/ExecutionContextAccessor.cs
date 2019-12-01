using BillAppDDD.BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace BillAppDDD
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private IHttpContextAccessor httpContext;

        public ExecutionContextAccessor(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        public Guid GetUserId()
        {
            return Guid.Parse(
                httpContext
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        }
    }
}
