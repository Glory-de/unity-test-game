using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gamedata 
{
    [Header("Player Settings")]

    public int Jumps;
    public string SceneName;

    public SerializableDictionary<string, bool> coins;
    public int healths;
    public int usedCoins;
    public bool chestOpen;
    public bool StarUsed;
    public Gamedata(){
        //Player Properties
        this.Jumps = 1;
        this.SceneName = "SampleScene";


        coins = new SerializableDictionary<string, bool>();
        this.healths = 3;
        this.usedCoins = 0;
        this.StarUsed = false;
        this.chestOpen = false;
    }
}
