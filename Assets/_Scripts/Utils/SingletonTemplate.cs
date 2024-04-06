using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTemplate<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance => instance;
    protected virtual void Awake()
    {
        if (instance == null) { instance = this as T; DontDestroyOnLoad(this.gameObject);}
        else { Destroy(this.gameObject); }
    }
}
