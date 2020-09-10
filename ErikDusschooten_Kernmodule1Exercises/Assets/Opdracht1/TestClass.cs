using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestClass<T>
{
    Dictionary<T, float> myDictionary = new Dictionary<T, float>();

    public T someGenericVariable;
    public T someGenericFunction<T>()
    {
        return default(T);
    }

    public float FindValue(T key)
    {
        return myDictionary[key];
    }

    public static void someGenereicFuntion()
    {

    }
}
