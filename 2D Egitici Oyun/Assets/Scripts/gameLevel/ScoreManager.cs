using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    int score;
    int scoreIncrease;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void addScore(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                scoreIncrease = 5;
                    break;
            case "Normal":
                scoreIncrease = 10;
                break;
            case "Hard":
                scoreIncrease = 15;
                break;
        }
        score += scoreIncrease;
        scoreText.text = score.ToString();
    }
 
}
