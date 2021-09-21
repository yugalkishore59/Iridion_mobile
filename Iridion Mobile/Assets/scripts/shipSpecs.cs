using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shipSpecs : MonoBehaviour
{
    public int health=100,maxHealth=100,lives=2;
    public Slider hb;
    public Image fill;
    GameObject l0,l1,l2,l3,l4,l5;
    int[] index={0,1,2,3,4,5};
    public movements moves;
   // public GameObject[] life=new GameObject[6];
    //int currentLifeIndex=2;
    public AudioSource powerUpFx;

    public GameObject gameOverMenu;

    void Start()
    {
       lives=PlayerPrefs.GetInt ("livesLvl", 1)+1;
       // moves=GetComponent<movements>;
        hb=GameObject.Find("healthBar").GetComponent<Slider>();
        fill=GameObject.Find("fill").GetComponent<Image>();
        hb.value=maxHealth;
        health=maxHealth;
        fill.color=new Color32(00,255,20,255);
        l0=GameObject.Find("l0");
        l1=GameObject.Find("l1");
        l2=GameObject.Find("l2");
        l3=GameObject.Find("l3");
        l4=GameObject.Find("l4");
        l5=GameObject.Find("l5");
        // for(int i=0;i<=5;i++){
        //     string name= "l"+i;
        //     print(name);
        //     life[i]=GameObject.Find(name);
        // }
        // life=new GameObject[5];
        // life[0]=GameObject.Find("l0");
        // life[1]=GameObject.Find("l1");
        // life[2]=GameObject.Find("l2");
        // life[3]=GameObject.Find("l3");
        // life[4]=GameObject.Find("l4");
        // life[5]=GameObject.Find("l5");
        // for(int j=5;j>currentLifeIndex;j--){
        //       life[j].SetActive(false);
        //   }
    }
    void Awake(){
      hb=GameObject.Find("healthBar").GetComponent<Slider>();
        fill=GameObject.Find("fill").GetComponent<Image>();
      hb.value=maxHealth;
        health=maxHealth;
        fill.color=new Color32(00,255,20,255);
    }

    // Update is called once per frame
    void Update()
    {
        hb.value=health;
        if(health<25){
          fill.color=new Color32(255,0,0,255);
        }
        if(health<50&&health>=25){
          fill.color=new Color32(255,255,0,255);
        }
        if(health>=50){
          fill.color=new Color32(00,255,20,255);
        }

        if(index[0]>lives){
          l0.SetActive(false);
        }
        if(index[0]<lives){
          l0.SetActive(true);
        }
        if(index[1]>lives){
          l1.SetActive(false);
        }
        if(index[1]<lives){
          l1.SetActive(true);
        }if(index[2]>lives){
          l2.SetActive(false);
        }
        if(index[2]<lives){
          l2.SetActive(true);
        }if(index[3]>lives){
          l3.SetActive(false);
        }
        if(index[3]<lives){
          l3.SetActive(true);
        }if(index[4]>lives){
          l4.SetActive(false);
        }
        if(index[4]<lives){
          l4.SetActive(true);
        }if(index[5]>lives){
          l5.SetActive(false);
        }
        if(index[5]<lives){
          l5.SetActive(true);
        }

        if(lives==-1){
          gameOverMenu.SetActive(true);
          //Time.timeScale=0f;
        }
        
    }
    public void takeTheDamage(int damage){
     if(moves.hasPlaced==true){
      health-=damage;
      //hb.value-=damage;
      if(health<=0){
          //Destroy
        //   for(int i=5;i>currentLifeIndex;i--){
        //       life[i].SetActive(false);
          //}
          lives--;
      }
      }
    }

    void OnCollisionEnter(Collision collision) {
 
        if (collision.gameObject.tag == "enemyLvl1"){

              takeTheDamage(8);
        }
        if (collision.gameObject.tag == "powerUp"){
          powerUpFx.Play();

              health=100;
              Destroy(collision.gameObject);
        }
       }
       

      // void OnTriggerEnter(Collider other) {
      //   if (other.gameObject.CompareTag("enemyLvl1")) {
      //     takeTheDamage(10);
      //     }
      //  }
}
