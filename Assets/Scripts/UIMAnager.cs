using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMAnager : MonoBehaviour
{
    public static UIMAnager instance;
    public GameObject zigZagPanel;
    public GameObject gameOverPanel;
    public GameObject tabText;
    public Text score;
    public Text highScoreOne;
    public Text highScoreTwo;

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {
        tabText.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);

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
