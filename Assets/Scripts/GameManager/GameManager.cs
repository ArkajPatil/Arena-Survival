using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private WaveManager waveManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnDeath += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= GameOver;
    }

    private void GameOver()
    {
        waveManager.StopWaves();
        Time.timeScale = 0.0f;
        gameUI.ShowGameOverPanel();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void RestartGame()
    {
        gameUI.DisableGameOverPanel();
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1.0f;
    }
}
