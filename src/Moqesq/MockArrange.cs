using System;

namespace Moqesq
{
    public class MockArrange<T> where T : notnull
    {
        private readonly Action<MockContainer<T>> arrange;

        public MockArrange(Action<MockContainer<T>> arrange)
        {
            this.arrange = arrange;
        }

        public MockAct<T, TResult> Act<TResult>(Func<T, TResult> act) => new MockAct<T, TResult>(arrange, act);
    }
}
