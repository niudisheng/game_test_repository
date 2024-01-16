using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseNomonoManager<T> where T:class,new()
{
    public static T instance;
    public static T Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
