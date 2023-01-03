using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IDataPersistence
{
    public void LoadData(Gamedata data){
        SceneManager.LoadScene(data.SceneName);
    }

    public void SaveData(ref Gamedata data){
       
    }
}
