using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public event Action<int> OnScoreChanged;

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeathStaticEvent += UpdateScore;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDeathStaticEvent -= UpdateScore;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScore()
    {
        score++;
        OnScoreChanged?.Invoke(score);
    }
}
