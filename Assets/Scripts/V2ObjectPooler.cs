using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class V2ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string _tag;
        public GameObject _prefab;
        public int _size;
    }

    public List<Pool> _pools;
    public Dictionary<string, Queue<GameObject>> _poolDictionnary;

    void Start()
    {
        _poolDictionnary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool._size; i++)
            {
                //GameObject moduleToInstantiate = _poolDictionnary[Random.Range(0, _pools.Count)];
                GameObject _module = Instantiate(pool._prefab);
                _module.SetActive(false);
                objectPool.Enqueue(_module);
            }

            _poolDictionnary.Add(pool._tag, objectPool);
        }
    }

    void Update()
    {
        
    }
}
