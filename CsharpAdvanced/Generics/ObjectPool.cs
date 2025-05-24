using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class ObjectPool<T> where T : new()
    {
        private readonly Stack<T> _objects;
        public int Count {
             get => _objects.Count;
        }

        public ObjectPool(int n) {
            _objects = new Stack<T>(n);

            for (int i = 0; i < n; i++) {
                _objects.Push(new T());
            }
        }

        public T Get() {
            if (_objects.Count > 0)
            {
                return _objects.Pop();
            }
            else {
                return default(T);
            }
        }
    }
}
