using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int score = 1;
    [SerializeField] private ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        LifeTimeScript lifeScript = other.GetComponent<LifeTimeScript>();

        if (lifeScript != null)
        {
            scoreManager.addScore(score);
            Destroy(other.gameObject);
        }
    }
}
