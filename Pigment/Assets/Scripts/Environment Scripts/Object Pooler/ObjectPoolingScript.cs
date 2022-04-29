using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingScript : MonoBehaviour
{
    //The object pooler script used here was found in the Brackeys vide oon object pooling.
    //It allows large numbers of different objects to be instantiated and set to inactive with a list of pools and a dictionary
    //It uses a "mock singleton" to allow for only this script to be referenced, but does not have the full implementation of a singleton
    //When the SpawnFromPool is called by a generator, it find an inactive object in the pool referenced by the tag in the library, and activates it.
    //While doing so it also calls the OnObjectSpawn() in the IPooledObject interface, allowing for each individual object type to have customizable effects on activation
    //It will continuously cycle through the pool so long as the objects are not destroyed

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPoolingScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool _pool in pools)
        {
            Queue<GameObject> _objectPool = new Queue<GameObject>();

            for (int i = 0; i < _pool.size; i++)
            {
                GameObject _obj = Instantiate(_pool.prefab);
                _obj.SetActive(false);
                _objectPool.Enqueue(_obj);
            }

            poolDictionary.Add(_pool.tag, _objectPool);
        }
    }

    public GameObject SpawnFromPool(string _tag, Vector3 _position, Quaternion _rotation)
    {
        if (!poolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("Pool with tag" + _tag + "doesn't exist.");

            return null;
        }

        GameObject _objectToSpawn = poolDictionary[_tag].Dequeue();

        _objectToSpawn.SetActive(true);
        _objectToSpawn.transform.position = _position;
        _objectToSpawn.transform.rotation = _rotation;

        IPooledObject _pooledObject = _objectToSpawn.GetComponent<IPooledObject>();

        if(_pooledObject != null)
        {
            _pooledObject.OnObjectSpawn();
        }        

        poolDictionary[_tag].Enqueue(_objectToSpawn);

        return _objectToSpawn;
    }        
}