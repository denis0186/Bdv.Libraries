using Bdv.DataAccess;
using Bdv.DataAccess.Impl.EntityFramework;
using Bdv.Libraries.Tests.Integration.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bdv.Libraries.Tests.Integration.DataAccess
{
    public class DbContextTests : RepositoryAndCrudServiceTestsBase
    {
        public DbContextTests(
            IntegrationTestsContext context,
            IDbContextFactory<IntegrationTestsContext> contextFactory) 
            : base(
                  new DbContextRepository<IntegrationTestsContext>(context),
                  new DbContextCrudService<IntegrationTestsContext>(contextFactory))
        {
        }
    }
}
