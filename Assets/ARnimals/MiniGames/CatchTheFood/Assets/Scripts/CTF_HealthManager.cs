using UnityEngine;
using UnityEngine.UI;

public class CTF_HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private GameObject[] hearts;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReduceHealth(int amount)
    {
        currentHealth -= amount;
        UpdateHealthUI();
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    private void UpdateHealthUI()
    {
        // Disable hearts based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].SetActive(true); // Enable the heart
            }
            else
            {
                hearts[i].SetActive(false); // Disable the heart
            }
        }
    }
}
