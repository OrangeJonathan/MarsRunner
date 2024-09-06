using UnityEngine;
using System.Collections.Generic;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }
    public List<GameObject> skins;
    public int currentSkinIndex = 0;
    public GameObject currentSkin;
    public GameObject currentShowSkin;

    public Transform skinDisplayPlaceholder; // Reference to the placeholder in the menu scene

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) 
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        SetCurrentSkin();
    }

    public void NextSkin()
    {
        currentShowSkin.SetActive(false);
        currentSkinIndex++;
        if (currentSkinIndex >= skins.Count)
        {
            currentSkinIndex = 0;
        }
        SetCurrentSkin();
    }

    public void PreviousSkin()
    {
        currentShowSkin.SetActive(false);
        currentSkinIndex--;
        if (currentSkinIndex < 0)
        {
            currentSkinIndex = skins.Count - 1;
        }
        SetCurrentSkin();
    }

    private void SetCurrentSkin()
    {
        if (skinDisplayPlaceholder != null)
        {
            // Destroy the previous skin if it exists
            foreach (Transform child in skinDisplayPlaceholder)
            {
                Destroy(child.gameObject);
            }

            // Instantiate the current skin as a child of the placeholder
            currentShowSkin = Instantiate(skins[currentSkinIndex], skinDisplayPlaceholder);
            currentSkin = skins[currentSkinIndex];
            currentShowSkin.SetActive(true);

            // Set the layer of the current skin and all its children to "UI"
            SetLayerRecursively(currentShowSkin, LayerMask.NameToLayer("UI"));
        }
    }

    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child == null) continue;
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}