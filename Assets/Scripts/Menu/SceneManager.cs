using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject currentSkin;


    public void LoadScene()
    {
        LevelDistance.distanceRun = 0;
        CollectibleController.coinCount = 0;
        currentSkin = SkinManager.Instance.currentSkin;
        DontDestroyOnLoad(currentSkin);
        UnityEngine.SceneManagement.SceneManager.LoadScene("RunnerScene");
    }
}
