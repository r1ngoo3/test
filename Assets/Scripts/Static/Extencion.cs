using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extencion
{
    public static int GetRandomIndex<T>(this IList<T> collection, params int[] exclusive)
    {
        int count = collection.Count;

        if (exclusive.Length == 0)
            return Random.Range(0, count);

        int index;

        do
        {
            index = Random.Range(0, count);
        } while (exclusive.Contains(index));

        return index;
    }
}
