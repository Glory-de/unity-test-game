using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;
    }

    public event Action onCoinCollected;
    public void CoinCollected() 
    {
        if (onCoinCollected != null) 
        {
            onCoinCollected();
        }
    }

    public event Action onHealthCollected;
    public void HealthCollected() 
    {
        if (onHealthCollected != null) 
        {
            onHealthCollected();
        }
    }

    public event Action onUseCoin;
    public void useCoin() 
    {
        if (onUseCoin != null) 
        {
            onUseCoin();
        }
    }
}
