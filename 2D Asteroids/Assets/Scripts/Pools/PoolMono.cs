using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T _prefab { get; }
    public bool autoExpand { get; set; }
    public Transform _container { get; }

    private List<T> _pool;

    public PoolMono(T prefab, int capacity)
    {
        _prefab = prefab;
        _container = null;

        CreatePool(capacity);
    }

    public PoolMono(T prefab, int capacity, string poolName)
    {
        _prefab = prefab;
        _container = new GameObject(poolName).transform;
        CreatePool(capacity);
    }
    
    private void CreatePool(int capacity)
    {
        _pool = new List<T>();

        for (int i=0; i< capacity; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(_prefab,_container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElenet(out T element)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                mono.gameObject.SetActive(true);
                element = mono;
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElenet(out var element))
            return element;

        if (autoExpand)
            return CreateObject(true);

        throw new Exception($"Нет свободных элементов {typeof(T)}");
    }

}

