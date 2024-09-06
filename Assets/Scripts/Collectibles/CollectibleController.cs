using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour
{
    public static int coinCount = 0;
    public TMP_Text coinCountText;

    void Update()
    {
        coinCountText.text = "" + coinCount;
    }
}
