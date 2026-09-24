using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject wavePanel;
    
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private ScoreManager scoreManager;

    void OnEnable()
    {
        PlayerHealth.OnPlayerHealthChange += UpdateHealthBar;
        scoreManager.OnScoreChanged += UpdateScoreUI;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerHealthChange -= UpdateHealthBar;
        scoreManager.OnScoreChanged -= UpdateScoreUI;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Game Over Panel
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void DisableGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

    // Wave Panel
    public void ShowWavePanel(int waveNumber)
    {
        wavePanel.SetActive(true);
        waveText.text = $"Wave {waveNumber+1}";
    }

    public void DisableWavePanel()
    {
        wavePanel.SetActive(false);
    }

    private void UpdateHealthBar(float newHealth)
    {
        healthBar.value = newHealth;
    }

    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = $"Score {newScore}";
    }
}
