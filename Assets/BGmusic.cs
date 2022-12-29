
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
    private static BGmusic instance = null;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
