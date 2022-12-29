using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    private CoinCollectedText CCT;

    private void Start(){
        CCT = GameObject.Find("CoinTextUI").GetComponent<CoinCollectedText>();
    }


    public void onHealthBuy(){
        if(CCT.coinsCollected >= 1){
            GameEventsManager.instance.HealthCollected();
            GameEventsManager.instance.useCoin();
        }else{
            Debug.LogError("Not enough coins to buy health.");
        }
    }
}
