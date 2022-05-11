using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newWebAPI.Context;

namespace webAPI.test
{
    public static class ApiTestContext
    {
        public static ApiAppContext GetApiAppContext()
        {
            var options = new DbContextOptionsBuilder<ApiAppContext>().UseInMemoryDatabase(databaseName: "testDB").Options;

            var dbContext = new ApiAppContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            
            return dbContext;
        }
    }
}