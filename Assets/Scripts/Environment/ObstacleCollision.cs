using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject levelController;
    
    void OnTriggerEnter(Collider other)
    {
        levelController.GetComponent<GenerateLevel>().enabled = false;
        player.GetComponent<PlayerMove>().enabled = false;
        levelController.GetComponent<LevelDistance>().enabled = false;
        levelController.GetComponent<EndRunSequence>().enabled = true;
    }

}
