using UnityEngine;

public class SectionEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GenerateLevel levelGenerator = FindObjectOfType<GenerateLevel>();
            if (levelGenerator != null)
            {
                // Spawn a new section to maintain 2 segments ahead
                levelGenerator.SpawnSection();
            }

            // Destroy the current section's parent
            Destroy(transform.parent.gameObject);
        }
    }
}
