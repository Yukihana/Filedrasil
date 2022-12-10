namespace Filedrasil.Integrity.Types
{
    public partial class Counter<T> where T : unmanaged
    {
        private class ElementInfo<Y>
        {
            public Y Value;
            public int Counter = 1;

            public ElementInfo(Y value)
                => Value = value;
        }
    }
}