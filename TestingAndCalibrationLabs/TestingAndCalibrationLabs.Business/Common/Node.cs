using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Common
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public IList<Node<T>> subs { get; private set; }

        public Node(T value, IEnumerable<Node<T>> subs)
        {
            this.Value = value;
            this.subs = new List<Node<T>>(subs);
        }

    }
}