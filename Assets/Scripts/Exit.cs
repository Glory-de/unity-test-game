using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void AppExit(){
        Debug.Log("Tapping");
        DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.SaveGame();
        Invoke("QuitApplication", 3);
    }

    void QuitApplication(){
        Application.Quit();
    }
}
