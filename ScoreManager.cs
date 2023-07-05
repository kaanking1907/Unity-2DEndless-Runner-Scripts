using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    void Start()
    {
        
    }

    void Update()
    {
        
        scoreText.text = "Score: " + scoreCount;
        hiScoreCount.text = "High Score: " + hiScoreCount;

    }
}
