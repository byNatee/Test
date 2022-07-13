using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private bool _autoExpand;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool;

    public ObjectsPool(GameObject prefab, Transform parent, bool autoExpand, int capacity)
    {
        _objectPrefab = prefab;
        _parent = parent;
        _autoExpand = autoExpand;
        _capacity = capacity;
        
        InitPool();
    }

    private void InitPool()
    {
        _pool = new List<GameObject>(_capacity);

        for (var i = 0; i < _capacity; i++)
            CreateElement();
    }

    private GameObject CreateElement(bool defaultState = false)
    {
        var item = Instantiate(_objectPrefab, _parent.position, Quaternion.identity);
        item.transform.SetParent(_parent);
        item.SetActive(defaultState);
        _pool.Add(item);
        return item;
    }

    private bool HasFreeElement(out GameObject element)
    {
        foreach (var item in _pool)
        {
            if (!item.activeInHierarchy)
            {
                element = item;
                element.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public GameObject GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;
        
        if (_autoExpand)
            return CreateElement(true);

        throw new Exception("There is no free element");
    }
}
