using System;

namespace Bdv.Libraries.Tests.Integration
{
    public abstract class IntegrationTestsBase : IDisposable
    {
        protected IntegrationTestsBase()
        {
            SetUp();
        }

        public void Dispose()
        {
            TearDown();
        }

        protected abstract void SetUp();

        protected abstract void TearDown();
    }
}
