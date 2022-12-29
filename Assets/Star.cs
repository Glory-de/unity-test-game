using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    static public bool isStarCollected = false;
    [SerializeField] private GameObject floatingTextPrefab;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            isStarCollected = true;
            Instantiate(floatingTextPrefab);
        }

    }
}
