using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class l1AdManagerScript : MonoBehaviour, IUnityAdsListener
{
    string GooglePlayID="4139498";
    string interstitialAD="Interstitial_Android",rewardedAD="Rewarded_Android";
    public GameObject adButton,cashAmt,cashAmtclone;
    Text cashAmtCloneTxt;
    bool testMode = false;
    //bool testMode = true;
    rupeeEarned cashScript;
    // Start is called before the first frame update
    void Start()
    {
        cashAmtCloneTxt=cashAmtclone.GetComponent<Text>();
        Advertisement.AddListener (this);
        Advertisement.Initialize (GooglePlayID, testMode);
        cashScript=GameObject.Find("earned").GetComponent<rupeeEarned>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ShowRewardedVideo() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(rewardedAD)) {
            Advertisement.Show(rewardedAD);
        } 
        else {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

     // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string surfacingId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
           // gameManager.updateMoney(500);
           cashScript.updateCash(cashScript.cash);
           adButton.SetActive(false);
           cashAmt.SetActive(false);
           cashAmtCloneTxt.text=((cashScript.cash)*2).ToString();
           cashAmtclone.SetActive(true);

        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.


        } else if (showResult == ShowResult.Failed) {

            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string surfacingId) {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == rewardedAD) {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
             // adButton.SetActive(true);

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
}
