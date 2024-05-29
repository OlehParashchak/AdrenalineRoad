using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;

    [SerializeField] private Slider healthSlider;

    [SerializeField] private Health health;

    private void Start()
    {
        health.LoseGameEvent += LoseGame;
    }

    private void OnDisable()
    {
        health.LoseGameEvent -= LoseGame;
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    private void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }   
}
