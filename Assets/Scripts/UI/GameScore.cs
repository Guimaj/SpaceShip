using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    private int score;
    private Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        this.textScore = GetComponent<Text>();
    }

    public int Score
    {
        set
        {
            this.score = value;
            updateScore();
        }
        get 
        {
            return this.score;
        }
    }

    void updateScore()
    {
        this.textScore.text = score.ToString();
    }
}
