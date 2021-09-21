using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newTunnelScript : MonoBehaviour
{
    public float tunnelSpeed=10f;
    public GameObject newTunnel;
    float timeToDestroy=10f;
    bool spawnNew=false;

    void OnAwake(){
        timeToDestroy=10f;
        
    }
    void Start()
    {
       // transform.position=new Vector3(1f,4f,-4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position-=new Vector3(tunnelSpeed*Time.deltaTime,0,0);
        
        if(transform.position.x<-31&& spawnNew==false){
        Instantiate(newTunnel, new Vector3(77.35f,3.45f,-4.52f),Quaternion.Euler(0, -90, 90));
        //Quaternion.LookRotation(new Vector3(0,0,0)));
        spawnNew=true;
        }
        if(spawnNew==true){
            timeToDestroy-=Time.deltaTime;
        }
        if(timeToDestroy<=0){
            Destroy(gameObject);
        } 

    }
}
