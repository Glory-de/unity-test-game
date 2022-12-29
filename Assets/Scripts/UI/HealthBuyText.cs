using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBuyText : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int healthTotal = 0;
    private TMP_Text healthCollectedText;

    private void Awake() 
    {
        healthCollectedText = this.GetComponent<TMP_Text>();
    }

    public void LoadData(Gamedata data){
        this.healthTotal = data.healths;
    }

    public void SaveData(ref Gamedata data){
        data.healths = this.healthTotal;
    }

    void Start()
    {
        GameEventsManager.instance.onHealthCollected += OnHealthCollected;
    }
    void Update()
    {
        healthCollectedText.text = healthTotal.ToString();
    }

    private void OnDestroy() 
    {
        GameEventsManager.instance.onHealthCollected -= OnHealthCollected;
    }

    private void OnHealthCollected() 
    {
        healthTotal++;
    }
}
