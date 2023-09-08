using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPool : MonoBehaviour
{
    PoolingGenerator generator;
    GameObject player;

    void Start()
    {
        generator = GameObject.FindGameObjectWithTag("ModuleGenerator").GetComponent<PoolingGenerator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distFromPlayer = (player.transform.position.x - gameObject.transform.position.x);
        Debug.Log(distFromPlayer);

        if (distFromPlayer > 150)
        {
            Debug.Log("canspawn");
            generator.canSpawn = true;
            gameObject.SetActive(false);
        }
    }
}