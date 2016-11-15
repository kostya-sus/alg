using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algor1Final
{
    public class MyDictionary
    {
        private class DictionaryEntry
        {
            //354969
            public int Key { get; set; }
            public string Value { get; private set; }
          
            public DictionaryEntry(string val)
            {
               
                Value = val;
            }
            public DictionaryEntry(int key,string val)
            {

                Value = val;
                Key = key;
            }
        }
        private FileStream _stream;
        private StreamReader _reader;
        private LinkedList<DictionaryEntry>[] _array;
        private int _capacity;
        private int _size;
        private const double LoadFactor = 0.75;

        public MyDictionary(int size, string path)
        {
            _capacity = size;
            _array = new LinkedList<DictionaryEntry>[_capacity];
            _stream = File.OpenRead(path);
            _reader = new StreamReader(_stream);
        }

        public void Load()
        {
           
            while (!_reader.EndOfStream)
            {
                string word = _reader.ReadLine();
               
                if (word != "")
                {
                    Add(word);

                }

            }
        }
        public MyDictionary()
        {
            _capacity = 5;
            _array = new LinkedList<DictionaryEntry>[_capacity];
        }
        private int Hash(string key)
        {

            return Math.Abs(key.GetHashCode()) % _capacity;
        }

        private double GetLoadFactor()
        {
            return _size / _capacity;
        }

        private void Resize()
        {
            _capacity = _capacity * 2;
            var oldArray = _array;
            _size = 0;
            _array = new LinkedList<DictionaryEntry>[_capacity];

            foreach (var item in oldArray)
            {
                if (item != null)
                {
                    foreach (var pair in item)
                    {
                        if (pair != null)
                            Add(pair.Value);
                    }
                }
            }
        }

       
        public void Add( string val)
        {
            if (GetLoadFactor() >= LoadFactor)
            {
                Resize();
            }

            var index = Hash(val);

            if (_array[index] == null)
            {
                _array[index] = new LinkedList<DictionaryEntry>();
            }

            var hashTableItem = new DictionaryEntry(index, val);

            var listNode = new LinkedListNode<DictionaryEntry>(hashTableItem);

            _array[index].AddFirst(listNode);

            _size++;
        }

       
        public bool Contains(string value)
        {
            int index = Hash(value);
            if (_array[index] != null)
            {
               var buf=   _array[index].Where(m => m.Value == value);
                if (buf.FirstOrDefault() != null)
                    return true;
            }
            return false;
        }
       
    }
}
