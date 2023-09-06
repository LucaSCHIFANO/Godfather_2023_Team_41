using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoints : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Reference<Score> scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            scoreManager.Instance.AddScore(100);
            Destroy(gameObject);
        }
    }
}
