using System;

namespace Bdv.Libraries.Tests.Integration
{
    public abstract class TestsBase : IDisposable
    {
        protected TestsBase()
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
