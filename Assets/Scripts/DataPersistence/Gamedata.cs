using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gamedata 
{
    public SerializableDictionary<string, bool> coins;
    public int healths;
    public int usedCoins;
    public Gamedata(){
        coins = new SerializableDictionary<string, bool>();
        this.healths = 3;
        this.usedCoins = 0;
    }
}
