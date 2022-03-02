using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Utils
{
    public static class ListUtils
    {
        public static T GetRandomElement<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                throw new Exception("List is empty!");
            }
            
            var randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }
    }
}
