using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rupeeEarned : MonoBehaviour
{
    public int cash,tempCash;
    Text score,cashMade,rupeeScreen;
    public GameObject gameOverCash;
    gameManagerScript gameManager;
    void Start()
    {   
        tempCash=cash;
        score=GameObject.Find("ScoreText").GetComponent<Text>();
        rupeeScreen=gameOverCash.GetComponent<Text>();
        cashMade=gameObject.GetComponent<Text>();
        gameManager=GameObject.Find("GameManager").GetComponent<gameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        cashMade.text=(int.Parse(score.text)/5).ToString();
        rupeeScreen.text=cashMade.text;
        cash=(int.Parse(score.text)/5);
        if(tempCash<cash){
            gameManager.updateMoney(cash-tempCash);
            tempCash=cash;
        }


    }
    public void updateCash(int money){
        gameManager.updateMoney(money);
        //rupeeScreen.text=(money*2).ToString();
    }
}
