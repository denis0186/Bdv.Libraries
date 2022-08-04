using Bdv.DataAccess;
using Bdv.Libraries.Tests.Integration.DataAccess.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Bdv.Libraries.Tests.Integration.DataAccess.Models;

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

        protected override void TearDown()
        {
            var tables = _repository.GetAllAsync<InformationSchemaTables>(
                "SELECT table_name TableName FROM information_schema.tables WHERE table_schema = 'public' AND table_name <> 'VersionInfo'")
                .GetAwaiter().GetResult().Select(x => x.TableName);
            
            if (tables.Any())
            {
                _crudService.ExecuteAsync($"TRUNCATE {string.Join(',', tables.ToArray())} RESTART IDENTITY CASCADE").Wait();
            }

        }

        [Fact]
        public async Task InsertAndGetSingleTest()
        {
            var user = new User { Name = Guid.NewGuid().ToString() };
            await _crudService.InsertAsync(user);
            var actual = await _repository.GetAsync<User>(x => x.Name == user.Name);

            actual.Should().BeEquivalentTo(user);
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

            actual.Should().BeEquivalentTo(users);
        }

        [Fact]
        public async Task UpdateGetByKeySingleTest()
        {
            var user = new User { Name = Guid.NewGuid().ToString() };
            await _crudService.InsertAsync(user);
            user.Name = Guid.NewGuid().ToString();
            await _crudService.UpdateAsync(user);
            var actual = await _repository.GetByKeyAsync<User, int>(user.Id);

            actual.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task UpdateGetByKeyManyTest()
        {
            var users = new[]
            {
                new User { Name = Guid.NewGuid().ToString() },
                new User { Name = Guid.NewGuid().ToString() },
                new User { Name = Guid.NewGuid().ToString() },
            };

            await _crudService.InsertAsync(users);
            foreach (var user in users)
            {
                user.Name = Guid.NewGuid().ToString();
            }

            await _crudService.UpdateAsync(users);

            var actual = await _repository.GetAllByKeysAsync<User, int>(users.Select(x => x.Id).ToArray());

            actual.Should().BeEquivalentTo(users);
        }
    }
}
