using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementScore()
    {
        score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("StartScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("hightScore"))
        {
            if (score > PlayerPrefs.GetInt("hightScore"))
            {
                PlayerPrefs.SetInt("hightScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("hightScore", score);
        }
    }
}
