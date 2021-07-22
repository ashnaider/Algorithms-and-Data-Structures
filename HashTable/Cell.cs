using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class Cell<T>
    {
        public T Value { get; set; }
        public string Key { get; set; }
        public Cell(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}
