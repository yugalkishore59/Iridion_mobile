using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    int clicks=0;
    public GameObject PauseMenu,gameOverMenu,backGroundSound;
    bool isGameMenu=false;
    //Score,ScoreInGameOver;
    Text score,scoreInGameOver;
    gameManagerScript gamemanager;
    public AudioSource clickFx,bgSound,backClickFx;

    
    void Start()
    {
        bgSound=backGroundSound.GetComponent<AudioSource>();
        gamemanager=GameObject.Find("GameManager").GetComponent<gameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            clickFx.Play();
            clicks++;
            if(clicks==1){
              bgSound.Pause();
              PauseMenu.SetActive(true);
              Time.timeScale=0f;
            }
            if(clicks==2){
                bgSound.Play();
                PauseMenu.SetActive(false);
                clicks=0;
                Time.timeScale=1f;
            }
        }

        if(gameOverMenu.active&&isGameMenu==false){
           bgSound.Pause();
           Time.timeScale=0f;
           scoreInGameOver=GameObject.Find("scorePoints").GetComponent<Text>();
           score=GameObject.Find("ScoreText").GetComponent<Text>();
           scoreInGameOver.text=score.text;
           if(int.Parse(scoreInGameOver.text)>gamemanager.highScore){
               gamemanager.setHighScore(int.Parse(scoreInGameOver.text));
           }
           isGameMenu=true;
        }
    }

    public void goToMenu(){
        backClickFx.Play();
        Time.timeScale=1f;
        SceneManager.LoadScene("gameMenu");
        
    }
    public void resumeGame(){
        bgSound.Play();
        backClickFx.Play();
        PauseMenu.SetActive(false);
        clicks=0;
        Time.timeScale=1f;
    }
    public void restartGame(){
       // clickFx.Play();
        gameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale=1f;
        SceneManager.LoadScene("level1");  
    }
}
