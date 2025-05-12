using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class logicscript : MonoBehaviour
{
    public int playerscore;
    public Text scoretext;
    public AudioSource point;


    public void addscore(int scoreToAdd)
    {
        playerscore += scoreToAdd;
        scoretext.text = playerscore.ToString();
        if (playerscore == 10){
            scoretext.color = Color.green;
        }
        else if (playerscore >= 5){
            scoretext.color = Color.yellow;
        }
        else if (playerscore >= 0){
            scoretext.color = Color.red;
        }
    }
    /////////////////////////////////////////////////

    public void pointplay()
    {
        point.Play();
    }



    // Start is called before the first frame update
    void Start_()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    ///////////////////////////////////////////

    public void nextlevel()
    {
        SceneManager.LoadScene("Level2");
    }

/////////////////////////////////////////////////

    private bool isPaused = false;

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}
