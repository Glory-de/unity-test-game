using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{

    public GameObject shop;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.B) && !shop.activeSelf){
            shop.SetActive(true);
        }else if(Input.GetKeyDown(KeyCode.B) && shop.activeSelf){
            shop.SetActive(false);
        }
    }
}
