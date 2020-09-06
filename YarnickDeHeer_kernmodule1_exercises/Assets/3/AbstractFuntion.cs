using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFuntion<T>
{
    public static Dictionary<T,string> myDictionary = new Dictionary<T, string>();

    public static string Find(T SomeVar)
    {
        myDictionary.TryGetValue(SomeVar, out string value);
        return (value);
    }
}
