using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class gamemanager : MonoBehaviour
{
   
    public  player pl;
    private int score;
    public TextMeshProUGUI scoretext;
    public GameObject playbutton;
    public GameObject gameover;
    public GameObject getready;

    private SoundManager soundManager;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();

        
    }

    public void Play()
    {
        score = 0;
        
        scoretext.text=score.ToString();
        getready.SetActive(false);
        playbutton.SetActive(false);
        gameover.SetActive(false);
        Time.timeScale = 1;
        pl.enabled = true;

        pipes[] p = FindObjectsOfType<pipes>(); 
        for(int i=0;i<p.Length; i++)
        {
            Destroy(p[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pl.enabled = false;
    }
    public void IncreaseScore()
    {
        score++;
        scoretext.text=score.ToString();
    }

    public void GameOver()
    {
        gameover.SetActive(true);
        playbutton.SetActive(true);
        Pause();
       
    }


}
