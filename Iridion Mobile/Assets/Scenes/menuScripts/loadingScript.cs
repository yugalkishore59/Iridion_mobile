using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingScript : MonoBehaviour
{
    public GameObject loading, bgMusic;
    Slider loadingSlider;
    public float loadingTime=3.2f,sliderValue=0,maxLoadingTime=3f;
    public bool isBgOn=true;

    void Start()
    {
        loadingTime=3.2f;
        maxLoadingTime=3f;
        isBgOn=true;
        sliderValue=0;
        loadingSlider=loading.GetComponent<Slider>();
    }
    void Awake(){
        //loadingTime=3.2f;
        //sliderValue=0;
        loadingSlider=loading.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        loadingTime-=Time.deltaTime;
        sliderValue+=Time.deltaTime;
        loadingSlider.value=sliderValue*(3/maxLoadingTime);
         if(loadingTime<=0){
             bgMusic.SetActive(isBgOn);
             gameObject.SetActive(false);
         }
    }
}
