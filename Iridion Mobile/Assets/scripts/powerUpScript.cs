using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float powerUpSpeed=20f,rx,ry,rz;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(-powerUpSpeed*Time.deltaTime,0,0);
        transform.Rotate (rx*Time.deltaTime,ry*Time.deltaTime,rz*Time.deltaTime);
        if(transform.position.x<-10f){
            Destroy(gameObject);
        }
    }
}
