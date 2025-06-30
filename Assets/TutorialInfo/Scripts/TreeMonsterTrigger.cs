using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeMonsterTrigger : MonoBehaviour
{
    public GameObject tree;
    public GameObject treeMonster;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            tree.SetActive(false);        // Hide tree
            treeMonster.SetActive(true);  // Reveal monster

            Debug.Log("Tree Monster awakened! Game Over.");
            SceneManager.LoadScene("GameOver"); // Replace with your GameOver scene name
        }
    }
}

