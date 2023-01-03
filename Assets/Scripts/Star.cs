using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour, IDataPersistence
{

    static public bool isStarCollected = false;

    [SerializeField] private GameObject floatingTextPrefab;

    public void LoadData(Gamedata data){
        isStarCollected = data.StarUsed;
        if(isStarCollected){
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref Gamedata data){
        data.StarUsed = isStarCollected;
    }
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
