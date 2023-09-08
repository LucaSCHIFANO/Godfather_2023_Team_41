using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] Transform _loadingPosition;
    [SerializeField] private List<GameObject> moduleList = new List<GameObject>();
    [SerializeField] private List<GameObject> usedModule = new List<GameObject>();
    GameObject actualModule;
    public bool canSpawn;
    bool moduleNotUsed;

    void Start()
    {
        for (int i = 0; i < moduleList.Count; i++)
        {
            moduleNotUsed = false;
            while (!moduleNotUsed)
            {
                actualModule = moduleList[Random.Range(0, moduleList.Count)];
                if (!usedModule.Contains(actualModule))
                {
                    moduleNotUsed = true;
                }
            }

            usedModule.Add(actualModule);
            GameObject moduleCharged = Instantiate(actualModule);
            BackgroundPooler.instance.pooledObjects.Add(moduleCharged);
            moduleCharged.transform.position = _loadingPosition.position;
            _loadingPosition.transform.position = _loadingPosition.transform.position + new Vector3(190f, 0, 0);
            BackgroundPooler.instance.modulePrefab.Add(moduleCharged);
            moduleCharged.AddComponent<ModuleObject>();

        }
    }

    void Update()
    {
        if (canSpawn)
        {
            GameObject module = BackgroundPooler.instance.GetPooledObject();

            if (module != null)
            {
                module.transform.position = _loadingPosition.transform.position;
                _loadingPosition.transform.position = _loadingPosition.transform.position + new Vector3(190f, 0, 0);
                module.SetActive(true);
                canSpawn = false;
            }
        }
    }
}