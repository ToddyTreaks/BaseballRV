using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int score = 1;
    [SerializeField] private ScoreManager scoreManager;


    private void OnTriggerEnter(Collider other)
    {
        scoreManager.addScore(score);
    }

}
