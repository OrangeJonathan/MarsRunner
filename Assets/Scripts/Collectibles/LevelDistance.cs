using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelDistance : MonoBehaviour
{
    public TMP_Text distanceText;
    public static int distanceRun;
    public bool addingDistance = false;
    public float distanceDelay = 0.35f;
    void Update()
    {
        if (!addingDistance)
        {
            addingDistance = true;
            StartCoroutine(AddDistance());
        }
    }

    IEnumerator AddDistance()
    {
        distanceRun++;
        distanceText.text = "" + distanceRun;
        yield return new WaitForSeconds(distanceDelay);
        addingDistance = false;
    }
}
