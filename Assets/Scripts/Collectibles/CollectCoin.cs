using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        CollectibleController.coinCount++;
        this.gameObject.SetActive(false);
    }


}
