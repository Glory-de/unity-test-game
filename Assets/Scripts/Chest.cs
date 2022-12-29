using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    static public bool isChestOpened = false;
    public CoinCollectedText coinCollectedText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && coinCollectedText.coinsCollected >= 1)
        {
            Destroy(gameObject);
        }
    }
}
