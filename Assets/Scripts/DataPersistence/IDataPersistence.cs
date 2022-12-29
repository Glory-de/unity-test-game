using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(Gamedata data);
    void SaveData(ref Gamedata data);
}
