using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject liveCoins;
    public GameObject liveDistance;
    public int endCoins;
    public TMP_Text endCoinText;
    public int endDistance;
    public TMP_Text endDistanceText;

    void Start()
    {
        endCoins = CollectibleController.coinCount;
        endDistance = LevelDistance.distanceRun;
        StartCoroutine(EndRun());
    }

    IEnumerator EndRun()
    {
        yield return new WaitForSeconds(0.5f);
        endScreen.SetActive(true);
        endCoinText.text = "" + endCoins;
        endDistanceText.text = "" + endDistance;
        liveCoins.SetActive(false);
        liveDistance.SetActive(false);
        this.enabled = false;
    }

    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        LevelDistance.distanceRun = 0;
        CollectibleController.coinCount = 0;
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
