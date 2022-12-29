using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBuyText : MonoBehaviour, IDataPersistence
{
    [SerializeField] public int healthTotal = 0;
    private TMP_Text healthCollectedText;
    public static HealthBuyText instance { get; private set; }

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one  Health Manager in the game.");
        }
        instance = this;
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

    public void OnHealthCollected() 
    {
        healthTotal++;
    }

    public void OnHealthUsed(){
        healthTotal--;
    }
}
