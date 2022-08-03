using Bdv.DataAccess;
using Bdv.Libraries.Tests.Integration.DataAccess.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Bdv.Libraries.Tests.Integration.DataAccess
{
    public abstract class RepositoryAndCrudServiceTestsBase : IntegrationTestsBase, IClassFixture<DatabaseFixture>
    {
        private readonly IRepository _repository;
        private readonly ICrudService _crudService;

        public RepositoryAndCrudServiceTestsBase(IRepository repository, ICrudService crudService)
        {
            _repository = repository;
            _crudService = crudService;
        }

        protected override void SetUp()
        {
        }

        protected override void TearDown()
        {
        }

        [Fact]
        public async Task InsertAndGetSingleTest()
        {
            var user = new User { Name = Guid.NewGuid().ToString() };
            await _crudService.InsertAsync(user);
            var actual = await _repository.GetAsync<User>(x => x.Name == user.Name);

            Assert.NotNull(actual);
            Assert.Equal(user.Id, actual!.Id);
            Assert.Equal(user.Name, actual.Name);
        }

        [Fact]
        public async Task InsertAndGetManyTest()
        {
            var users = new[]
            {
                new User { Name = Guid.NewGuid().ToString() },
                new User { Name = Guid.NewGuid().ToString() },
                new User { Name = Guid.NewGuid().ToString() },
            };

            await _crudService.InsertAsync(users);
            var actual = await _repository.GetAllAsync<User>(x => users.Select(y => y.Id).Contains(x.Id));

            Assert.NotNull(actual);
            actual.Should().BeEquivalentTo(users);
            
        }
    }
}
