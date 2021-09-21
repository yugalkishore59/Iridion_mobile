using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuShip : MonoBehaviour
{
    public float timeGap=3f,shotGap=0.15f;
    float tempTimeGap,tempShotGap;
    public GameObject fireball,firePoint;
    //bool hasShot=false;
    bool isShooting=false;
    int nos=3;

    void Start()
    {
        tempShotGap=shotGap;
        tempTimeGap=timeGap;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooting==false){
            nos=5;
            timeGap-=Time.deltaTime;
            if(timeGap<0){
                isShooting=true;  
                //timeGap=tempTimeGap; 
            }
             
        }
        else{
           // for(int i=0;i<3;i++){
                shotGap-=Time.deltaTime;
                if(shotGap<0){
                    shoot(); nos--;shotGap=tempShotGap;
                    }
                
            //}
            if(nos<=0){
                timeGap=tempTimeGap; 
                isShooting=false;
            }
            
        }
        // timeGap-=time.deltaTime;
        
        // if(timeGap<0){
        //     shoot();
        //     timeGap=tempTimeGap;
        // }
        
        
    }
    void shoot(){
        // for(int i=0;i<3;i++){
        //     shotGap-=time.deltaTime;
        //     if(shotGap<0){
        //     shotGap=tempShotGap;
        //     }
           Instantiate(fireball, firePoint.transform.position,Quaternion.Euler(0, -90, 0));
        // }
         
        //  hasShot=true;
    }
}
