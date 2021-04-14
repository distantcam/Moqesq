using System;

namespace Moqesq
{
    public class MockAct<T, TResult> where T : notnull
    {
        private readonly Action<MockContainer<T>> arrange;
        private readonly Func<T, TResult> act;

        public MockAct(Action<MockContainer<T>> arrange, Func<T, TResult> act)
        {
            this.arrange = arrange;
            this.act = act;
        }

        public void Assert(Action<TResult, MockContainer<T>> assert)
        {
            if (assert == null)
            {
                throw new ArgumentNullException(nameof(assert), $"{nameof(assert)} is null.");
            }

            var mockContainer = Ext.FromCtors<T>();
            arrange?.Invoke(mockContainer);

            var response = act(mockContainer.Instance);

            assert(response, mockContainer);
        }
    }
}
