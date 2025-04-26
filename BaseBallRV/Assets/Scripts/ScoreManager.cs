using System;
using System.Collections;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticsUtility;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private int _maxDisplayedScore = 1000000;
    [SerializeField] private float vibrationDuration = 0.2f;  // seconds
    [SerializeField] private int _maxScoreGiven = 5;
    [SerializeField] private int pointsForCheers = 3;
    private int score = 0;


    public void addScore(int score)
    {
        if (score > this._maxScoreGiven){ 
            Debug.LogError(score + " is higher than the max score to be given at a time : " + this._maxScoreGiven);
            score = this._maxScoreGiven;
        }
        this.score += score;

        StartCoroutine(scoringFeedbacks(score));

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

    IEnumerator scoringFeedbacks(int score)
    {
        var controllers = FindObjectsByType<XRBaseInputInteractor>(FindObjectsSortMode.None);

        if(score >= pointsForCheers) AudioManager.Instance.PlaySFX("Cheers");
        for (int i = 1; i < score+1; i++)
        {
            AudioManager.Instance.PlaySFX("Ding");
            foreach (var controller in controllers)
            {
                controller.SendHapticImpulse((float) i/_maxScoreGiven, vibrationDuration);
            }
            yield return new WaitForSeconds(vibrationDuration);
        }
    }
}
