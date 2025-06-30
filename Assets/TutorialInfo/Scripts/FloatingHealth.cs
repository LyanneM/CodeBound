using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingHealth : MonoBehaviour
{
    public GameObject[] hearts; // Heart models in the scene
    public int currentHealth;
    public GameObject heartPopPrefab;

    private PlayerMovement playerMovement;

   void Start()
{
    playerMovement = FindFirstObjectByType<PlayerMovement>();
    currentHealth = hearts.Length;
}


    public void TakeDamage()
    {
        Debug.Log("Player took damage");

        currentHealth--;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHearts();

        if (currentHealth == 0)
        {
            if (playerMovement != null)
            {
                playerMovement.PlayDieAnimation();
            }

            Debug.Log("No hearts left — Game Over!");
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateHearts()
{
    for (int i = 0; i < hearts.Length; i++)
    {
        bool shouldBeVisible = i < currentHealth;

        if (!shouldBeVisible && hearts[i] != null && hearts[i].activeSelf)
        {
            Debug.Log("Popping heart " + i);

            Animator anim = hearts[i].GetComponent<Animator>();
            if (anim != null)
                anim.Play("HeartPop", 0, 0f);

            if (heartPopPrefab != null)
                Instantiate(heartPopPrefab, hearts[i].transform.position, Quaternion.identity);

            Destroy(hearts[i], 0.5f);
        }
    }
}

}
