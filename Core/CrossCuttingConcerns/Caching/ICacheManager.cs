using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration); //Cache şu kadar süreliğine ekle (dk)
        bool IsAdd(string key); //Cache'de var mı ?
        void Remove(string key); //cachedeki datayı yok et
        void RemoveByPattern(string pattern); //şunu olanları yok et
    }
}
