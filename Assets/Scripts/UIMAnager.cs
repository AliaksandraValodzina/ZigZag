using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject ZigZagPanel;
    public GameObject GameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScoreOne;
    public Text highScoreTwo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScoreOne.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        ZigZagPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScoreTwo.text = PlayerPrefs.GetInt("highScore").ToString();
        GameOverPanel.SetActive(true);
    }

    public void ResetFunction()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
