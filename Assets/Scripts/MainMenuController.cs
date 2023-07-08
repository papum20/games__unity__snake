using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    public Text highScore;




    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetSceneByName("GameScene").name == "GameScene")
            SceneManager.UnloadScene("GameScene");


        HighScoreFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void Play()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void HighScoreFunction()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Exit()
    {
        Application.Quit();
    }

}
