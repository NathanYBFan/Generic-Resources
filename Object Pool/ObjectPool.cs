using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Nathan Fan
/// Description: Creates a object pool of unity game objects
///
/// </summary>
public class ObjectPool<T> : Behaviour where T : Behaviour
{
    public T DefaultObjectType { get => defaultObjectType; }
        protected T defaultObjectType;

    public Transform SpawnLocation { get => spawnLocation; }
        [SerializeField] protected Transform spawnLocation;

    public int CurrentPoolSize { get => currentPoolSize; }
        protected int currentPoolSize;

    public int MaxPoolSize { get => maxPoolSize; }
        protected int maxPoolSize;

    public bool PoolSizeCanGrow { get => poolSizeCanGrow; }
        protected bool poolSizeCanGrow;

    public List<T> ObjectPoolList;

    public ObjectPool(int numberOfObjectsToSpawn, Transform spawnLocation, bool objectPoolCanGrow, T defaultObject)
    {
        maxPoolSize = numberOfObjectsToSpawn;
        this.spawnLocation = spawnLocation;
        poolSizeCanGrow = objectPoolCanGrow;
        defaultObjectType = defaultObject;

        ObjectPoolList = new List<T>();

        SpawnObjects();
    }

    public T GetObject()
    {
        if (ObjectPoolList.Count <= 0)
        {
            DarkDebug.LogError("ERROR: OBJECT POOL IS EMPTY, CANNOT GET OBJECT OF TYPE: " + typeof(T));
            return null;
        }

        foreach (T obj in ObjectPoolList)
        {
            if (obj.isActiveAndEnabled) continue;

            obj.gameObject.SetActive(true);
            return obj;
        }

        DarkDebug.LogWarning("WARNING: Could not find an available object in object pool");
        if (poolSizeCanGrow)
        {
            DarkDebug.LogWarning("WARNING: poolSizeCanGrow = true; therefore a new object of type " + typeof(T) + " was created");
            return SpawnAObject();
        }
        return null;
    }

    public void ReturnObject(T usedObject)
    {
        usedObject.gameObject.SetActive(false);
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < maxPoolSize; i++)
        {
            if (currentPoolSize < maxPoolSize)
            {
                SpawnAObject();
            }
        }
    }

    private T SpawnAObject()
    {
        T newObject = Instantiate(defaultObjectType, spawnLocation);
        newObject.gameObject.SetActive(false);
        currentPoolSize++;
        ObjectPoolList.Add(newObject);

        return newObject;
    }
}