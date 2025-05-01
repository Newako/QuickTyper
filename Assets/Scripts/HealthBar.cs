using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healthFill;
    public float maxHealth = 100f;
    public float currentHealth;

    public float decreaseRate = 5f;

    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;

    private bool gameOverShown = false;

    void Start()
    {
        currentHealth = maxHealth;
        gameOverText.enabled = false;
        restartButton.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            currentHealth -= decreaseRate * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthFill.fillAmount = currentHealth / maxHealth;
        }
        else if (!gameOverShown)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        gameOverShown = true;
        gameOverText.enabled = true;
        restartButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void ModifyHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthFill.fillAmount = currentHealth / maxHealth;
    }
}
