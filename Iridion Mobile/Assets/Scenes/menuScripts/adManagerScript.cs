using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class adManagerScript : MonoBehaviour, IUnityAdsListener
{
   // public static adManagerScript instance;
    string GooglePlayID="4139498";
    string interstitialAD="Interstitial_Android",rewardedAD="Rewarded_Android";
    public GameObject adButton,adNotReadyTxt;
    gameManagerScript gameManager;
    int interstitialCountDown=0;
    string adNotreadyString= "Ad not ready yet.\nAre you connected to internet?";
    string youSkippedString= "you skipped the Ad.\nToo bad :(";
    string rewordString="yay! you got ₹500";
    

    bool testMode = false;
    //bool testMode = true;

    void Start()
    {
        interstitialCountDown= PlayerPrefs.GetInt("IADCountdown", 0);
        interstitialCountDown++;
        PlayerPrefs.SetInt("IADCountdown", interstitialCountDown);
        PlayerPrefs.Save();
        Advertisement.AddListener (this);
        Advertisement.Initialize (GooglePlayID, testMode);
        gameManager=GameObject.Find("GameManager").GetComponent<gameManagerScript>();
        if(PlayerPrefs.GetInt("IADCountdown", 0)>=3){
            ShowInterstitialAd();
            PlayerPrefs.SetInt("IADCountdown", 0);
            PlayerPrefs.Save();
        }
    }
    void Awake(){
       // MakeSingolton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // private void MakeSingolton(){
    //     if(instance!=null){
    //         Destroy(gameObject);
            
    //     }
    //     else
    //         {
    //             instance=this;
    //             DontDestroyOnLoad(gameObject);
    //         }
    // }

    public void ShowInterstitialAd() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady()) {
            Advertisement.Show(interstitialAD);
         // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
        } 
        else {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    public void ShowRewardedVideo() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(rewardedAD)) {
            Advertisement.Show(rewardedAD);
        } 
        else {
            adNotReadyTxt.GetComponent<Text>().text=adNotreadyString;
            adNotReadyTxt.SetActive(true);
            StartCoroutine(waitFor());
            //Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

     // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string surfacingId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
            gameManager.updateMoney(500);
            adNotReadyTxt.GetComponent<Text>().text=rewordString;
            adNotReadyTxt.SetActive(true);
            StartCoroutine(waitFor());

        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
            adNotReadyTxt.GetComponent<Text>().text=youSkippedString;
            adNotReadyTxt.SetActive(true);
            StartCoroutine(waitFor());


        } else if (showResult == ShowResult.Failed) {

            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string surfacingId) {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == rewardedAD) {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
              adButton.SetActive(true);

        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string surfacingId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }

    IEnumerator waitFor()
     {
         yield return new WaitForSeconds(1f);
         adNotReadyTxt.SetActive(false);
     }
}
