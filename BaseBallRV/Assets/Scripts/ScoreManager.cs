using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private int _maxDisplayedScore = 1000000;
    private int score = 0;

    private void Start()
    {
        
    }

    public void addScore(int score)
    {
        this.score += score;
        UpdateUI();
    }

    public int getScore() {  return score; }

    public void removeScore(int score) {  
        this.score -= score;
        UpdateUI();
    }

    public void Reset()
    {
        score = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_scoreDisplay != null) {
            _scoreDisplay.text = (this.score % _maxDisplayedScore).ToString();
        }
        
    }
}
