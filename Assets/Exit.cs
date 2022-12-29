using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void AppExit(){
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        Application.Quit();
    }
}
