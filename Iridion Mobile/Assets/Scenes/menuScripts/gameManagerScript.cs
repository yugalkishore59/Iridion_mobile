using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    //i have to change button function to mainmenu script
    public int highScore=0,money=20;
    public int lives=2,shooters=1;
    public float fireRate=1.5f;
    // int fireRateLvl=0,livesLvl=0,shootersLvl=0;
    // int fireRatePrice=200,livesPrice=500, shootersPrice=1000;
    public static gameManagerScript instance;
    // public GameObject noMoneyTxt,buyFRbtn,buyLBtn,buySBtn,frpTxt,lpTxt,spTxt;
    
    // Text rsShooters,rsFireRate,rsLives;
    // public GameObject livesSl,shooterSl,fireRateSl;
    // Slider livesSlider,shooterSlider,fireRateSlider;

    void Awake(){

        // updateMoney(100000);
        // PlayerPrefs.SetInt("fireRateLvl", 0);
        // PlayerPrefs.SetInt("shootersLvl", 0);
        // PlayerPrefs.SetInt("livesLvl", 0);
        // PlayerPrefs.Save();



        MakeSingolton();
        highScore = PlayerPrefs.GetInt ("highscore", 0);
        // fireRateLvl = PlayerPrefs.GetInt ("fireRateLvl", 0);
        // livesLvl= PlayerPrefs.GetInt ("livesLvl", 0);
        // shootersLvl= PlayerPrefs.GetInt ("shootersLvl", 0);
        money = PlayerPrefs.GetInt ("money", 0);
        // rsFireRate=frpTxt.GetComponent<Text>();
        // rsLives=lpTxt.GetComponent<Text>();
        // rsShooters=spTxt.GetComponent<Text>();
        // livesSlider=livesSl.GetComponent<Slider>();
        // fireRateSlider=fireRateSl.GetComponent<Slider>();
        // shooterSlider=shooterSl.GetComponent<Slider>();
        // updatePrice();
        //PlayerPrefs.Save();
    }
    private void MakeSingolton(){
        if(instance!=null){
            Destroy(gameObject);
            
        }
        else
            {
                instance=this;
                DontDestroyOnLoad(gameObject);
            }
    }

    public void setHighScore(int score){
        PlayerPrefs.SetInt ("highscore", score);
        highScore = PlayerPrefs.GetInt ("highscore", highScore);
        PlayerPrefs.Save();
    }

    public void updateMoney(int cash){
        int temp= PlayerPrefs.GetInt("money", money);
        int newM= temp+cash;
        PlayerPrefs.SetInt("money", newM);
        PlayerPrefs.Save();
        money=PlayerPrefs.GetInt("money", money);
    }

    // public void buyFireRate(){
    //        if(money>=fireRatePrice){
    //            updateMoney(-fireRatePrice);
    //            int temp= PlayerPrefs.GetInt ("fireRateLvl", 0);
    //            if(temp<=5){ temp+=1;}
    //            PlayerPrefs.SetInt ("fireRateLvl", temp);
    //            PlayerPrefs.Save();
    //            fireRateLvl=PlayerPrefs.GetInt ("fireRateLvl", 0);
    //           // fireRateSlider.value=PlayerPrefs.GetInt ("fireRateLvl", 0);
    //            updatePrice();
    //        }
    //        else{
    //            noMoneyTxt.SetActive(true);
    //            StartCoroutine(waitFor());
    //           // noMoneyTxt.SetActive(false);    
    //        }
    // }
    // public void buyShooters(){
    //     if(money>=shootersPrice){
    //            updateMoney(-shootersPrice);
    //            int temp= PlayerPrefs.GetInt ("shootersLvl", 0); 
    //            if(temp<=5){ temp+=1;}
    //            PlayerPrefs.SetInt ("shootersLvl", temp);
    //            PlayerPrefs.Save();
    //            shootersLvl= PlayerPrefs.GetInt ("shootersLvl", 0); 
    //            //shooterSlider.value=PlayerPrefs.GetInt ("shootersLvl", 0);
    //            updatePrice();
    //        }
    //        else{
    //            noMoneyTxt.SetActive(true);
    //            StartCoroutine(waitFor());
                   
    //        }

    // }
    // public void buyLives(){
    //     if(money>=livesPrice){
    //            updateMoney(-livesPrice);
    //            int temp= PlayerPrefs.GetInt ("livesLvl", 0); 
    //            if(temp<=4){ temp+=1;}
    //            PlayerPrefs.SetInt ("livesLvl", temp);
    //            PlayerPrefs.Save();
    //            livesLvl= PlayerPrefs.GetInt ("livesLvl", 0); 
    //           // livesSlider.value= PlayerPrefs.GetInt ("livesLvl", 0);
    //            updatePrice();
    //        }
    //        else{
    //            noMoneyTxt.SetActive(true);
    //            StartCoroutine(waitFor());
    //           // noMoneyTxt.SetActive(false);    
    //        }

    // }
    // IEnumerator waitFor()
    //  {
    //      yield return new WaitForSeconds(1f);
    //      noMoneyTxt.SetActive(false);
    //  }
    //  void updatePrice(){
    //       switch (fireRateLvl){
    //     case 1: fireRatePrice=400; break;
    //     case 2: fireRatePrice=800; break;
    //     case 3: fireRatePrice=1200; break;
    //     case 4: fireRatePrice=1500; break;
    //     case 5: buyFRbtn.SetActive(false); break;
    //     default: fireRatePrice=200; break;
    //     }
    //     switch (livesLvl){
    //     case 1: livesPrice=1000; break;
    //     case 2: livesPrice=2000; break;
    //     case 3: livesPrice=5000; break;
    //     //case 4: fireRatePrice=1500; break;
    //     case 4: buyLBtn.SetActive(false); break;
    //     default: livesPrice=500; break;
    //     }
    //     switch (shootersLvl){
    //     case 1: shootersPrice=1500; break;
    //     case 2: shootersPrice=2500; break;
    //     case 3: shootersPrice=5000; break;
    //     case 4: shootersPrice=10000; break;
    //     case 5: buySBtn.SetActive(false); break;
    //     default: shootersPrice=1000; break;
    //     }
    //     rsFireRate.text=fireRatePrice.ToString();
    //     rsLives.text=livesPrice.ToString();
    //     rsShooters.text=shootersPrice.ToString();
    //     livesSlider.value= PlayerPrefs.GetInt ("livesLvl", 0);
    //     shooterSlider.value=PlayerPrefs.GetInt ("shootersLvl", 0);
    //     fireRateSlider.value=PlayerPrefs.GetInt ("fireRateLvl", 0);
    //  }


}
