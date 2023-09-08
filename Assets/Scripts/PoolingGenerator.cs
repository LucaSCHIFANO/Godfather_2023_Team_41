using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingGenerator : MonoBehaviour
{
    [SerializeField] Transform loadingPosition;

    [SerializeField] private List<GameObject> _moduleList = new List<GameObject>();
    [SerializeField] private float _moduleGapDistance;

    GameObject actualModule;
    public bool canSpawn;
    bool moduleNotUsed;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < _moduleList.Count; i++)
        {
            if (i == 0)
            {
                actualModule = _moduleList[0];
            }
            else
            {
                actualModule = _moduleList[Random.Range(0, _moduleList.Count)];
            }

            GameObject moduleCharged = Instantiate(actualModule);

            moduleCharged.transform.position = loadingPosition.position;
            loadingPosition.transform.position += new Vector3(_moduleGapDistance, 0, 0);

            moduleCharged.AddComponent<ObjectPool>();
        }
    }

    void Update()
    {
        float distFromPlayer = (loadingPosition.transform.position.x - player.transform.position.x);

        if (distFromPlayer < 70)
        {
            canSpawn = true;
        }

        if (canSpawn)
        {
            GameObject _module = _moduleList[Random.Range(0, _moduleList.Count)];

            if (_module != null)
            {
                GameObject _newModule = Instantiate(_module);

                _newModule.transform.position = loadingPosition.transform.position;
                loadingPosition.transform.position += new Vector3(_moduleGapDistance, 0, 0);

                canSpawn = false;
            }
        }
    }
}