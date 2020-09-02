using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class DesignHashSet : IRunnable
    {
        public void Run()
        {
            var obj = new MyHashSet();
            obj.Add(1);
            obj.Add(3);
            obj.Add(5);
            obj.Add(9);
            obj.Add(89);

            Logger.LogLine($"HashSet.Count before remove: {obj.Count()}");
            obj.Remove(5);
            Logger.LogLine($"HashSet.Count after remove: {obj.Count()}");
            Logger.LogLine($"HashSet contains (3): {obj.Contains(3)}");

            Logger.LogLine($"DONE");
        }
    }

    class MyHashSet : IMyHashSet
    {
        const int DefaultSize = 4;
        private IList<int>[] _buckets = null;
        private int _elementCount = 0;

        public MyHashSet()
        {
            _buckets = new IList<int>[DefaultSize];
        }

        public void Add(int key)
        {
            if (Contains(key))
                return;

            if (_elementCount >= _buckets.Length)
                ExtendBuckets();

            var bucket = GetOrCreateBucket(GetHash(key));
            bucket.Add(key);
            _elementCount++;
        }

        public void Remove(int key)
        {
            var bucket = _buckets[GetHash(key)];
            if (bucket == null)
                return;

            bucket.Remove(key);
            _elementCount--;
        }

        public bool Contains(int key)
        {
            var bucket = _buckets[GetHash(key)];
            return bucket != null && bucket.Contains(key);
        }

        public int Count()
        {
            return _elementCount;
        }

        private int GetHash(int key)
        {
            return key % _buckets.Length;
        }

        private void ExtendBuckets()
        {
            var oldBuckets = _buckets;
            _buckets = new IList<int>[_buckets.Length * 2];

            foreach (var key in oldBuckets.Where(b => b != null).SelectMany(b => b))
            {
                var bucket = GetOrCreateBucket(GetHash(key));
                bucket.Add(key);
            }
        }

        private IList<int> GetOrCreateBucket(int key)
        {
            if (_buckets[key] == null)
                _buckets[key] = new List<int>();

            return _buckets[key];
        }
    }

    class MySimpleHashSet : IMyHashSet
    {
        private const int MaxSize = 1000000;
        private bool[] _buckets = null;
        private int _elementCount = 0;

        public MySimpleHashSet()
        {
            _buckets = new bool[MaxSize];
        }

        public void Add(int key)
        {
            _buckets[key] = true;
            _elementCount++;
        }

        public void Remove(int key)
        {
            _buckets[key] = false;
            _elementCount--;
        }

        public bool Contains(int key)
        {
            return _buckets[key];
        }

        public int Count()
        {
            return _elementCount;
        }
    }

    interface IMyHashSet
    {
        void Add(int key);
        void Remove(int key);
        bool Contains(int key);
        int Count();
    }

    /**
     * Your MyHashSet object will be instantiated and called as such:
     * MyHashSet obj = new MyHashSet();
     * obj.Add(key);
     * obj.Remove(key);
     * bool param_3 = obj.Contains(key);
     */
}

