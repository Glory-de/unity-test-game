using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            var player = col.gameObject;
            if(HealthBuyText.instance.healthTotal > 0){
                GameEventsManager.instance.onHealthCollected -= HealthBuyText.instance.OnHealthCollected;
                GameEventsManager.instance.onHealthCollected += HealthBuyText.instance.OnHealthUsed;
                GameEventsManager.instance.HealthCollected();
                GameEventsManager.instance.onHealthCollected -= HealthBuyText.instance.OnHealthUsed;
                GameEventsManager.instance.onHealthCollected += HealthBuyText.instance.OnHealthCollected;
                DataPersistenceManager.instance.SaveGame();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }else if(HealthBuyText.instance.healthTotal <= 0){
                SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
            }
        }
    }
}
