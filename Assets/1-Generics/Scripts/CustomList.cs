using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomList<T>
{
    private T[] data;
    public int amount = 0;
    public CustomList() { amount = 0; }

    public void Add(T item)
    {
        // Create a new array of amount + 1
        T[] cache = new T[amount + 1];
        if (data != null) { }
        {
            for (int i = 0; i < data.Length; i++)
            {
                cache[i] = data[i];
            }
        }
        // Set end element to new item
        cache[amount] = item;
        data = cache;
        amount++;
    }
}
