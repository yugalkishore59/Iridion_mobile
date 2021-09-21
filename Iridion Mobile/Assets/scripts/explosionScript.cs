using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    float timeDestroy=.8f;
    //public AudioSource explode;
    void Start()
    {
        //explode.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position-=new Vector3(10f*Time.deltaTime,0,0);
        timeDestroy-=Time.deltaTime;
        if(timeDestroy<0){
            Destroy(gameObject);
        }
        
    }
}
