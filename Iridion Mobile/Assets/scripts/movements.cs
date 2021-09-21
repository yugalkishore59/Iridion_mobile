using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{
    public float movementSpeed=4f;
    public bool left=false,hasPlaced=false;
    public float rotSpeed=5f,speed=3f;
    //float startIn=2f;
    public GameObject fireBall,firePoint,firePoint1,firePoint2,firePoint3,firePoint4,firePoint5;
    public float nextTimeToShoot= 0.15f;
    float tempTimeToShoot;
    bool hasShoot=false;
    public Joystick joystick;
    public float minJsMove=.2f;
    public bool isShooting=false;
    public AudioSource shootFx;



    void Awake(){
        hasPlaced=false;
        transform.position=new Vector3(0f,3.16f,-4.51f);
        transform.rotation=Quaternion.Euler(-90f, 90f, 0);
        tempTimeToShoot=nextTimeToShoot;
        //transform.position=Vector3.Lerp(transform.position, new Vector3(3.86f,3.16f,-4.51f), speed);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.86f,3.16f,-4.51f), speed);
    }

    void Start()
    {
        nextTimeToShoot=.2f;
        for(int x=0;x<PlayerPrefs.GetInt ("fireRateLvl", 0);x++){
            nextTimeToShoot-=0.01f;
        }
        hasPlaced=false;
        tempTimeToShoot=nextTimeToShoot;
        transform.position=new Vector3(0f,3.16f,-4.51f);
        transform.rotation=Quaternion.Euler(-90f, 90f, 0);
        //transform.position=Vector3.Lerp(transform.position, new Vector3(3.86f,3.16f,-4.51f), speed);
       // transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.86f,3.16f,-4.51f), speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasPlaced==false){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.86f,3.16f,-4.51f), Time.deltaTime*speed);
                if(transform.position.x==3.86f){
                    hasPlaced=true;
                }
        }

        //if(startIn>0){
       // startIn-=Time.deltaTime;}

        if(hasPlaced==true){
            move();
            

                if(transform.position.y<4.8 && Input.GetKey("w")){
                //(Input.GetKey("w")||joystick.Vertical>minJsMove)){
                    transform.position+=new Vector3(0,movementSpeed*Time.deltaTime,0);
                }
                if(transform.position.y>2 && Input.GetKey("s")){
                //(Input.GetKey("s")||joystick.Vertical<-minJsMove)){
                    transform.position-=new Vector3(0,movementSpeed*Time.deltaTime,0);
                }
                if(transform.position.z<-2.2 && Input.GetKey("a")){
                //(Input.GetKey("a")||joystick.Horizontal<-minJsMove)){
                    left=true;
                    transform.position+=new Vector3(0,0,movementSpeed*Time.deltaTime);
                    var targetRotation=Quaternion.Euler(-60, 0, 90);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
                }
                if(transform.position.z>-6.7 && Input.GetKey("d")){
                //(Input.GetKey("d")||joystick.Horizontal>minJsMove)){
                    left=true;
                    transform.position-=new Vector3(0,0,movementSpeed*Time.deltaTime);
                    var targetRotation=Quaternion.Euler(-120, 0, 90);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
                }
                if(Input.GetKeyUp("d")||(joystick.Vertical<minJsMove&&joystick.Vertical>-minJsMove&&joystick.Horizontal<minJsMove&&joystick.Horizontal>-minJsMove)){
                    left=false;
                }
                if(Input.GetKeyUp("a")){
                    left=false;
                }
                if(left==false&&transform.rotation!=Quaternion.Euler(-90, 90, 0)){
                        var targetRotation=Quaternion.Euler(-90, 90, 0);
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
                    }


                nextTimeToShoot-=Time.deltaTime;
                if(nextTimeToShoot<=0){
                    nextTimeToShoot=tempTimeToShoot;
                    hasShoot=false;
                }

                if((Input.GetKey("p")||isShooting==true)&& hasShoot==false){
                    shoot();
                }
        }
    }

    public void shoot(){
        shootFx.Play();

        int shootersLvl= PlayerPrefs.GetInt ("shootersLvl", 0);
        if(shootersLvl==0){
            Instantiate(fireBall, firePoint.transform.position,Quaternion.Euler(0, -90, 0));
        }
        else if(shootersLvl==1){
           // Instantiate(fireBall, firePoint.transform.position,Quaternion.Euler(0, -90, 0));
           // Instantiate(fireBall, firePoint1.transform.position,Quaternion.Euler(0, -90, 0));
           Instantiate(fireBall, firePoint2.transform.position,Quaternion.Euler(0, -90, 0));
           Instantiate(fireBall, firePoint3.transform.position,Quaternion.Euler(0, -90, 0));
        }
        else if(shootersLvl==2){
           Instantiate(fireBall, firePoint2.transform.position,Quaternion.Euler(0, -90, 0));
           Instantiate(fireBall, firePoint3.transform.position,Quaternion.Euler(0, -90, 0));
           Instantiate(fireBall, firePoint4.transform.position,Quaternion.Euler(0, -90, 0));
        }
        else if(shootersLvl==3){
           Instantiate(fireBall, firePoint2.transform.position,Quaternion.Euler(0, -90, 0));
           Instantiate(fireBall, firePoint3.transform.position,Quaternion.Euler(0, -90, 0));
           Instantiate(fireBall, firePoint4.transform.position,Quaternion.Euler(0, -90, 0));
           Instantiate(fireBall, firePoint5.transform.position,Quaternion.Euler(0, -90, 0));
        }
        // else if(shootersLvl==4){
        //     Instantiate(fireBall, firePoint.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint1.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint2.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint3.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint4.transform.position,Quaternion.Euler(0, -90, 0));
        // }
        // else if(shootersLvl==5){
        //     Instantiate(fireBall, firePoint.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint1.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint2.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint3.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint4.transform.position,Quaternion.Euler(0, -90, 0));
        //     Instantiate(fireBall, firePoint5.transform.position,Quaternion.Euler(0, -90, 0));
        // }
        
        hasShoot=true;
    }
    public void shooting(){
        isShooting=true;
    }
    public void notShooting(){
        isShooting=false;
    }
    void move(){
            if(transform.position.y<4.8&&joystick.Vertical>0){
              transform.position+=new Vector3(0,movementSpeed*Time.deltaTime*joystick.Vertical,0);
             }
             if(transform.position.y>2&&joystick.Vertical<0){
              transform.position+=new Vector3(0,movementSpeed*Time.deltaTime*joystick.Vertical,0);
             }
             if(transform.position.z<-2.2&&joystick.Horizontal<0){
              transform.position+=new Vector3(0,0,-movementSpeed*Time.deltaTime*joystick.Horizontal);
              if(joystick.Horizontal<-minJsMove){
                   left=true;
                    var targetRotation=Quaternion.Euler(-60, 0, 90);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
              }
             }
             if(transform.position.z>-6.7&&joystick.Horizontal>0){
              transform.position+=new Vector3(0,0,-movementSpeed*Time.deltaTime*joystick.Horizontal);
              if(joystick.Horizontal>minJsMove){
                   left=true;
                    var targetRotation=Quaternion.Euler(-120, 0, 90);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
              }
             }
    }
    }
