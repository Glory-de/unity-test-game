using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    static public bool isStarCollected = false;

    [SerializeField] private GameObject floatingTextPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            isStarCollected = true; 
            Instantiate(floatingTextPrefab);
        }
    }
}
