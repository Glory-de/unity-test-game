using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid(){
        id = System.Guid.NewGuid().ToString();
    }

    private SpriteRenderer visual;
    private bool collected = false;

    private void Awake() {
        visual = this.GetComponentInChildren<SpriteRenderer>();
    }

    public void LoadData(Gamedata data){
        data.coins.TryGetValue(id, out collected);
        if(collected){
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref Gamedata data){
        if(data.coins.ContainsKey(id)){
            data.coins.Remove(id);
        }
        data.coins.Add(id, collected);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && !collected){
            CollectCoin();
        }
    }

    private void CollectCoin(){
        collected = true;
        visual.gameObject.SetActive(false);
        GameEventsManager.instance.CoinCollected();
    }
}
