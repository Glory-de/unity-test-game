using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowColliderLevelLoader : MonoBehaviour
{
    public LevelLoader LL;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //Ensures only contact with player object will cause next scene to laod
            LL.LoadNextLevel();

        }

    }
}
