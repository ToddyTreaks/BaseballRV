using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;

    public void addScore(int score)
    {
        this.score += score;
    }

    public int getScore() {  return score; }

    public void removeScore(int score) {  this.score -= score; }

    public void Reset()
    {
        score = 0; 
    }
}
