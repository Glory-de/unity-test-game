using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IDataPersistence
{
    public bool isChestOpened = false;
    public CoinCollectedText coinCollectedText;

    public void LoadData(Gamedata data){
        isChestOpened = data.chestOpen;
        if(isChestOpened){
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref Gamedata data){
        data.chestOpen = isChestOpened;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && coinCollectedText.coinsCollected >= 1)
        {
            isChestOpened = true;
            var player = collision.gameObject.GetComponent<PlayerController>();
            player.maxJumps = 2;
            GameEventsManager.instance.useCoin();
            Destroy(gameObject);
        }
    }
}
