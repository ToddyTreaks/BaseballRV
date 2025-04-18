using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private int _maxDisplayedScore = 1000000;
    [SerializeField] private float vibrationDuration = 0.1f;  // seconds
    private int score = 0;

    private void Start()
    {
        
    }

    public void addScore(int score)
    {
        this.score += score;
        var controllers = FindObjectsByType<XRBaseInputInteractor>(FindObjectsSortMode.None);

        foreach (var controller in controllers)
        {
            // Send haptic impulse to each controller
            controller.SendHapticImpulse(1, vibrationDuration);
        }
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
