using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    float waitBuffer = 0.1f;
    bool doneWaiting = false;

    // Update is called once per frame
    void Update()
    {

        if (waitBuffer > 0)
        {
            waitBuffer -= Time.deltaTime;   
        }
        else
        {
            doneWaiting = true;
        }


        if (Star.isStarCollected && doneWaiting == true && Keyboard.current.kKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            waitBuffer = 0.1f;
            doneWaiting= false;
        }
    }
}
