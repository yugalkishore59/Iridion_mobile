using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMovements : MonoBehaviour
{
    // Start is called before the first frame update
   public float ymovementSpeed=2f;
   public float zmovementSpeed=2.2f;
   movements shipMoves;

   //float startIn=2f;
   public Joystick joystick;
    void Start()
    {
        transform.position=new Vector3(1f,4f,-4.5f);
        shipMoves=GameObject.Find("ship").GetComponent<movements>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(startIn>0){
        // startIn-=Time.deltaTime;}
        
        if(shipMoves.hasPlaced==true){
            move();
                if(transform.position.y<4.5 && Input.GetKey("w")){
                    transform.position+=new Vector3(0,ymovementSpeed*Time.deltaTime,0);
                }
                if(transform.position.y>3.5 && Input.GetKey("s")){
                    transform.position-=new Vector3(0,ymovementSpeed*Time.deltaTime,0);
                }
                if(transform.position.z<-3.5 && Input.GetKey("a")){
                    transform.position+=new Vector3(0,0,zmovementSpeed*Time.deltaTime);
                }
                if(transform.position.z>-5.5 && Input.GetKey("d")){
                    transform.position-=new Vector3(0,0,zmovementSpeed*Time.deltaTime);
                } 
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1f,4f,-4.5f), Time.deltaTime*3);
            //transform.position=new Vector3(1f,4f,-4.5f);
        }
    }

    
    void move(){
            if(transform.position.y<4.5&&joystick.Vertical>0){
                transform.position+=new Vector3(0,ymovementSpeed*Time.deltaTime*joystick.Vertical,0);
              //transform.position+=new Vector3(0,movementSpeed*Time.deltaTime*joystick.Vertical,0);
             }
             if(transform.position.y>3.5&&joystick.Vertical<0){
                 transform.position+=new Vector3(0,ymovementSpeed*Time.deltaTime*joystick.Vertical,0);
              //transform.position+=new Vector3(0,movementSpeed*Time.deltaTime*joystick.Vertical,0);
             }
             if(transform.position.z<-3.5&&joystick.Horizontal<0){
                 transform.position+=new Vector3(0,0,-zmovementSpeed*Time.deltaTime*joystick.Horizontal);
              //transform.position+=new Vector3(0,0,-movementSpeed*Time.deltaTime*joystick.Horizontal);
             }
             if(transform.position.z>-5.5&&joystick.Horizontal>0){
                 transform.position+=new Vector3(0,0,-zmovementSpeed*Time.deltaTime*joystick.Horizontal);
              //transform.position+=new Vector3(0,0,-movementSpeed*Time.deltaTime*joystick.Horizontal);
             }
    }
}
