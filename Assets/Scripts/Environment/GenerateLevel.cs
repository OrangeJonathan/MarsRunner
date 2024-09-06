using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sectionsLevel1;  
    public GameObject[] sectionsLevel2;
    public GameObject[] sectionsLevel3;
    private Vector3 nextSpawnPoint = new(0,0,50);  // Initial spawn position
    private int initialSegments = 3;  // Number of segments to pre-load

    void Start()
    {
        // Spawn the initial segments
        for (int i = 0; i < initialSegments; i++)
        {
            Debug.Log("Spawning initial segments");
            SpawnSection(sectionsLevel1);
        }
    }

    public void SpawnSection()
    {
        // Check the distance run and spawn the appropriate sections
        if (LevelDistance.distanceRun < 250)
        {
            Debug.Log("Level 1");
            SpawnSection(sectionsLevel1);
        }
        else if (LevelDistance.distanceRun < 750)
        {
            Debug.Log("Level 2");
            SpawnSection(sectionsLevel2);
        }
        else
        {
            Debug.Log("Level 3");
            SpawnSection(sectionsLevel3);
        }
    }

    public void SpawnSection(GameObject[] sections)
    {
        Console.WriteLine("Spawning section");
        // Randomly select a section to spawn
        int sectionNumber = UnityEngine.Random.Range(0, sections.Length);
        GameObject newSection = Instantiate(sections[sectionNumber], nextSpawnPoint, Quaternion.identity);

        // Get the end point of the new section to set the next spawn point
        Transform endPoint = newSection.transform.Find("SectionEndTrigger");
        if (endPoint != null)
        {
            nextSpawnPoint = endPoint.position + new Vector3(0, 0, 25);
        }
        else
        {
            // If no EndPoint is found, assume the section is 50 units long
            nextSpawnPoint += new Vector3(0, 0, 50);
        }
    }
}
