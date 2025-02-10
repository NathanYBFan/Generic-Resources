using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Author: Nathan Fan
/// Description: Base singleton, can inherit from Behaviour instead too
///</summary>
public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public void Awake()
    {
        instance = this as T; //This is a thing?
    }
    public static T Instance
    {
        get {
            if (instance != null) return instance;
            instance = GameObject.FindAnyObjectByType<T>();
            if (instance == null)
            {
                Debug.LogWarning("You are trying to reference an instanced class that hasn't been initalized!");
                Debug.LogWarning($"Cannot find object of type {typeof(T)}.");
            }
            return instance;
        } 
    }
}
