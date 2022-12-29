using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollectedText : MonoBehaviour, IDataPersistence
{
    [SerializeField] public int coinsCollected = 0;
    [SerializeField] public int usedCoins = 0;
    private TMP_Text coinsCollectedText;

    private void Awake() 
    {
        coinsCollectedText = this.GetComponent<TMP_Text>();
    }

    public void LoadData(Gamedata data){
        this.usedCoins = data.usedCoins;
        foreach(KeyValuePair<string, bool> pair in data.coins){
            if(pair.Value){
                this.coinsCollected++;
            }
        }
        this.coinsCollected -= this.usedCoins;
    }

    public void SaveData(ref Gamedata data){
        data.usedCoins = this.usedCoins;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameEventsManager.instance.onCoinCollected += OnCoinCollected;
        GameEventsManager.instance.onUseCoin += OnUseCoin;
    }

    private void OnDestroy() 
    {
        GameEventsManager.instance.onCoinCollected -= OnCoinCollected;
        GameEventsManager.instance.onUseCoin -= OnUseCoin;
    }

    // Update is called once per frame
    void Update()
    {
        coinsCollectedText.text = coinsCollected.ToString();
    }

    private void OnCoinCollected() 
    {
        coinsCollected++;
    }

    private void OnUseCoin(){
        coinsCollected--;
        usedCoins++;
    }
}
