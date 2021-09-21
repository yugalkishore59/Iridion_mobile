using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    int click = 0;
    public GameObject confirmQuit,credits,shop,loading, bgm,settings;
    loadingScript loadingTime;
    Text highscore, cash;
    gameManagerScript gamemanager;
   // bool toQuit=false;


    int fireRateLvl=0,livesLvl=0,shootersLvl=0,money;
    int fireRatePrice=200,livesPrice=500, shootersPrice=1000;
     public GameObject noMoneyTxt,buyFRbtn,buyLBtn,buySBtn,frpTxt,lpTxt,spTxt;
     //string noMoneyString="Not enough money";
    
    Text rsShooters,rsFireRate,rsLives;
    public GameObject livesSl,shooterSl,fireRateSl;
    Slider livesSlider,shooterSlider,fireRateSlider;
    public GameObject qualityDropDown;
    Dropdown dropDown;

    public AudioClip coinFx,noMoneyFx;
    void Start()
    {
        dropDown=qualityDropDown.GetComponent<Dropdown>();
        dropDown.value=PlayerPrefs.GetInt("qualityIndex",2);
        // PlayerPrefs.SetInt ("fireRateLvl", 0);
        // PlayerPrefs.SetInt ("livesLvl", 0);
        // PlayerPrefs.SetInt ("shootersLvl", 0);
        // PlayerPrefs.SetInt ("money", 16000);
        // PlayerPrefs.Save();
        loadingTime=loading.GetComponent<loadingScript>();


        highscore=GameObject.Find("highscore").GetComponent<Text>();
        cash=GameObject.Find("amount").GetComponent<Text>();
        gamemanager=GameObject.Find("GameManager").GetComponent<gameManagerScript>();
        highscore.text=gamemanager.highScore.ToString();


        fireRateLvl = PlayerPrefs.GetInt ("fireRateLvl", 0);
        livesLvl= PlayerPrefs.GetInt ("livesLvl", 0);
        shootersLvl= PlayerPrefs.GetInt ("shootersLvl", 0);
        rsFireRate=frpTxt.GetComponent<Text>();
        rsLives=lpTxt.GetComponent<Text>();
        rsShooters=spTxt.GetComponent<Text>();
        livesSlider=livesSl.GetComponent<Slider>();
        fireRateSlider=fireRateSl.GetComponent<Slider>();
        shooterSlider=shooterSl.GetComponent<Slider>();
        money = PlayerPrefs.GetInt ("money", 0);
        updatePrice();
        

    }

     void Update()
     {
         cash.text=gamemanager.money.ToString();

         if (Input.GetKeyDown(KeyCode.Escape))
         {
             click++;
             confirmQuit.SetActive(true);
             StartCoroutine(ClickTime());
 
               if (click > 1)
               {
                  // print("Exit Game!");
                   PlayerPrefs.SetInt("IADCountdown", 0);
                   PlayerPrefs.Save();
                   Application.Quit();
               }
         }
     }
     IEnumerator ClickTime()
     {
         yield return new WaitForSeconds(1f);
         confirmQuit.SetActive(false);
         click = 0;
     }
    // public void exitDown(){
    //     click++;
    //     toQuit=true;
    //  }
    // public void exitUp(){
    //     toQuit=false;
    //  }

        public void startGame(){
            bgm.SetActive(false);
            loadingTime.isBgOn=false;
            loadingTime.loadingTime=2.5f;
            loadingTime.maxLoadingTime=2.3f;
            loadingTime.sliderValue=0;
            loading.SetActive(true);
            StartCoroutine(WaitAndStart(2.4f));
        }

        public void CloseCredits(){
           StartCoroutine(ClosetheCredits());
        }
        public void OpenCredits(){
            credits.SetActive(true);
        }
        public void OpenShop(){
            shop.SetActive(true);
            }
        public void OpenSettings(){
            settings.SetActive(true);
            }
            public void CloseShop(){
            StartCoroutine(ClosetheShop());
            //shop.SetActive(false);
        }
        public void CloseSettings(){
            StartCoroutine(ClosetheSettings());
            //shop.SetActive(false);
        }
        public IEnumerator ClosetheShop(){
            yield return new WaitForSeconds(0.1f);
            shop.SetActive(false);
            }
        public IEnumerator ClosetheCredits(){
            yield return new WaitForSeconds(0.1f);
            credits.SetActive(false);
            }
        public IEnumerator ClosetheSettings(){
            yield return new WaitForSeconds(0.1f);
            settings.SetActive(false);
            }
        


        public void updateMoney(int cash){
        int temp= PlayerPrefs.GetInt("money", money);
        int newM= temp+cash;
        PlayerPrefs.SetInt("money", newM);
        PlayerPrefs.Save();
        money=PlayerPrefs.GetInt("money", money);
        gamemanager.money=PlayerPrefs.GetInt("money", money);
    }
     public void buyFireRate(){
           if(PlayerPrefs.GetInt("money", money)>=fireRatePrice){
               updateMoney(-fireRatePrice);
               int temp= PlayerPrefs.GetInt ("fireRateLvl", 0);
               if(temp<=5){ temp+=1;}
               PlayerPrefs.SetInt ("fireRateLvl", temp);
               PlayerPrefs.Save();
               fireRateLvl=PlayerPrefs.GetInt ("fireRateLvl", 0);
              // fireRateSlider.value=PlayerPrefs.GetInt ("fireRateLvl", 0);
               updatePrice();
               AudioSource.PlayClipAtPoint(coinFx, new Vector3(-1.9f,3.948f,-5.31f), 1.0f);
           }
           else{
              // noMoneyTxt.GetComponent<Text>().text=noMoneyString;
               noMoneyTxt.SetActive(true);
               AudioSource.PlayClipAtPoint(noMoneyFx, new Vector3(-1.9f,3.948f,-5.31f), .5f);
               StartCoroutine(waitFor());
              // noMoneyTxt.SetActive(false);    
           }
    }
    public void buyShooters(){
        if(PlayerPrefs.GetInt("money", money)>=shootersPrice){
               updateMoney(-shootersPrice);
               int temp= PlayerPrefs.GetInt ("shootersLvl", 0); 
               if(temp<=5){ temp+=1;}
               PlayerPrefs.SetInt ("shootersLvl", temp);
               PlayerPrefs.Save();
               shootersLvl= PlayerPrefs.GetInt ("shootersLvl", 0); 
               //shooterSlider.value=PlayerPrefs.GetInt ("shootersLvl", 0);
               updatePrice();
               AudioSource.PlayClipAtPoint(coinFx, new Vector3(-1.9f,3.948f,-5.31f), 1.0f);
           }
           else{
              // noMoneyTxt.GetComponent<Text>().text=noMoneyString;
               noMoneyTxt.SetActive(true);
               AudioSource.PlayClipAtPoint(noMoneyFx, new Vector3(-1.9f,3.948f,-5.31f), .5f);
               //AusioSource.noMoneyFx.Play();
               StartCoroutine(waitFor());
                   
           }

    }
    public void buyLives(){
        if(PlayerPrefs.GetInt("money", money)>=livesPrice){
               updateMoney(-livesPrice);
               int temp= PlayerPrefs.GetInt ("livesLvl", 0); 
               if(temp<=4){ temp+=1;}
               PlayerPrefs.SetInt ("livesLvl", temp);
               PlayerPrefs.Save();
               livesLvl= PlayerPrefs.GetInt ("livesLvl", 0); 
              // livesSlider.value= PlayerPrefs.GetInt ("livesLvl", 0);
               updatePrice();
               AudioSource.PlayClipAtPoint(coinFx,new Vector3(-1.9f,3.948f,-5.31f), 1.0f);
           }
           else{
               //noMoneyTxt.GetComponent<Text>().text=noMoneyString;
               noMoneyTxt.SetActive(true);
               AudioSource.PlayClipAtPoint(noMoneyFx, new Vector3(-1.9f,3.948f,-5.31f), .5f);
               StartCoroutine(waitFor());
              // noMoneyTxt.SetActive(false);    
           }

    }
    IEnumerator waitFor()
     {
         yield return new WaitForSeconds(1f);
         noMoneyTxt.SetActive(false);
     }
     void updatePrice(){
          switch (fireRateLvl){
        case 1: fireRatePrice=800; break;
        case 2: fireRatePrice=1500; break;
        case 3: fireRatePrice=4000; break;
        case 4: fireRatePrice=8000; break;
        case 5: buyFRbtn.SetActive(false); break;
        default: fireRatePrice=300; break;
        }
        switch (livesLvl){
        case 1: livesPrice=5000; break;
        case 2: livesPrice=10000; break;
        case 3: livesPrice=12000; break;
        //case 4: fireRatePrice=1500; break;
        case 4: buyLBtn.SetActive(false); break;
        default: livesPrice=1000; break;
        }
        switch (shootersLvl){
        case 1: shootersPrice=5000; break;
        case 2: shootersPrice=12000; break;
        case 3: buySBtn.SetActive(false); break;
        default: shootersPrice=1500; break;
        }
        rsFireRate.text=fireRatePrice.ToString();
        rsLives.text=livesPrice.ToString();
        rsShooters.text=shootersPrice.ToString();
        livesSlider.value= PlayerPrefs.GetInt ("livesLvl", 0);
        shooterSlider.value=PlayerPrefs.GetInt ("shootersLvl", 0);
        fireRateSlider.value=PlayerPrefs.GetInt ("fireRateLvl", 0);
     }

     private IEnumerator WaitAndStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("level1");
        
    }

    public void SetQuality(int index){
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("qualityIndex",index);
        PlayerPrefs.Save();
    }
    
}
