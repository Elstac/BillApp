using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BillAppDDD.BuildingBlocks.Infrastructure
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetDbConnection();
    }
}
