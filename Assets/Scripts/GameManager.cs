using System;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject playerCharacter;

    void Start()
    {
        Debug.Log("Getting Skin");
        // Get the selected skin from the SkinManager
        GameObject selectedSkin = SkinManager.Instance.currentSkin;
        Debug.Log("Selected Skin: " + selectedSkin);

        // Find the current skin child object of the player character
        Transform currentSkinTransform = playerCharacter.transform.Find("CurrentSkin");

        if (currentSkinTransform != null)
        {
            // Destroy the current skin child object
            Destroy(currentSkinTransform.gameObject);
        }

        // Instantiate the selected skin as a child of the player character
        GameObject newSkin = Instantiate(selectedSkin, playerCharacter.transform);
        newSkin.name = "CurrentSkin"; // Name it for future reference

        // Set the new skin as the playerObject in the PlayerMove script
        if (playerCharacter.TryGetComponent<PlayerMove>(out var playerMove))
        {
            playerMove.playerObject = newSkin;
        }
    }
}