using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    public class MyDictionary
    {
        private readonly List<DictionaryItem> _items = new();

        public int Count => _items.Count;
        public bool IsEmpty => Count == 0;
        public string[] Keys => _items.Select(i => i.Key).ToArray();
        public string[] Values => _items.Select(i => i.Value).ToArray();
        public DictionaryItem[] Items => _items.ToArray();

        public string this[string key]
        {
            get => _items.First(i => i.Key == key).Value;
            set
            {
                var existing = _items.FirstOrDefault(i => i.Key == key);
                if (existing != null)
                    existing.Value = value;
                else
                    Add(key, value);
            }
        }

        public void Add(string key, string value)
        {
            if (ContainsKey(key))
                throw new System.ArgumentException("Key already exists");
            _items.Add(new DictionaryItem { Key = key, Value = value });
        }

        public bool Remove(string key)
        {
            return _items.RemoveAll(i => i.Key == key) > 0;
        }

        public bool ContainsKey(string key)
        {
            return _items.Any(i => i.Key == key);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}