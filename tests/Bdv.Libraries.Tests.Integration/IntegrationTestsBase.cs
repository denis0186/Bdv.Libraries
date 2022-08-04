using System;

namespace Bdv.Libraries.Tests.Integration
{
    public abstract class IntegrationTestsBase : IDisposable
    {
        protected IntegrationTestsBase()
        {
        }

        public void Dispose()
        {
            TearDown();
        }

        protected abstract void TearDown();
    }
}
