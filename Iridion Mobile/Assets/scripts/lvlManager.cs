using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlManager : MonoBehaviour
{
    public GameObject enemys1,ship,explosion;
    public GameObject powerUp;
    shipSpecs specs; movements moves;
    public float nextSpawn=2f,minNextSpawn=.5f,incSpawn=10f;
    float currentSpawn,incSpawnCurrent;
    bool hasExploaded=false;
    // public GameObject scoreInGameOver;
    public AudioSource shipExplode;
    
    public int puWave=0;
     public float nextPU=30f,maxNextPU=30f;

    void Start()
    {
        currentSpawn=nextSpawn;
        incSpawnCurrent=incSpawn;
        ship=GameObject.Find("ship");
        specs=ship.GetComponent<shipSpecs>();
        moves=ship.GetComponent<movements>();
    }

    // Update is called once per frame
    void Update()
    {
        nextPU-=Time.deltaTime;
        if(nextPU<0){
            spawnPowerUp();
            puWave++;
            if(puWave>=3){
                maxNextPU+=60f;
                puWave=0;
            }
            nextPU=maxNextPU;
        }
        
        incSpawn-=Time.deltaTime;
        if(incSpawn<0){
            if(currentSpawn>=minNextSpawn){
                currentSpawn-=0.125f;
            }
            incSpawn=incSpawnCurrent;
        }

        nextSpawn-=Time.deltaTime;
        if(nextSpawn<0){
            spawnES1(); 
            nextSpawn=currentSpawn;
        }

        if(specs.health<=0&& hasExploaded==false){
            shipExplode.Play();
            
            Instantiate(explosion, ship.transform.position,Quaternion.Euler(-90, 180, 90));
            //ship.SetActive(false);
            hasExploaded=true; moves.hasPlaced=false;
            ship.transform.position=new Vector3(0f,3.16f,-4.51f);
            ship.transform.rotation=Quaternion.Euler(-90f, 90f, 0);
            specs.health=100;
           
        }
        if(moves.hasPlaced==true){
            hasExploaded=false; 
        //     float t=1f;
        //     t-=Time.deltaTime;
        //     if(t<0){
        //     ship.SetActive(true);
        //     hasExploaded=false;
        //    }
            
        }
        
    }

    void spawnES1(){
        float x,y,z;
        x=Random.Range(50f,70f);
        y=Random.Range(2.3f,4.6f);
        z=Random.Range(-6.4f,-2.9f);
        Instantiate(enemys1, new Vector3(x,y,z),Quaternion.Euler(-90, 180, 90));
    }
    void spawnPowerUp(){
        float x,y,z;
        x=Random.Range(50f,70f);
        y=Random.Range(2.3f,4.6f);
        z=Random.Range(-6.4f,-2.9f);
        Instantiate(powerUp, new Vector3(x,y,z),Quaternion.Euler(0, 0, 0));
    }
}
