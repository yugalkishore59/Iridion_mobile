using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

  public interface IDamageable 
 {
      void TakeDamage(float damage);
 }

public class enemyS1Script : MonoBehaviour, IDamageable
{
    public float enemyS1Speed=12f;
    public GameObject fireBall, firePoint ;
    public float nextTimeToShoot=2f;
    float tempShoot;

    float hp=20f;
    public GameObject explosion;

    Text score;
    int desScore=5;
    //public AudioSource boomFx;

    void Awake(){
        tempShoot=nextTimeToShoot;
        hp=50f;
        //score=GameObject.Find("ScoreText").GetComponent<Text>();
    }
    void Start()
    {
        tempShoot=nextTimeToShoot;
        hp=50f;
        score=GameObject.Find("ScoreText").GetComponent<Text>();
        //if(score!=null){print("found");}
    }

    // Update is called once per frame
    void Update()
    {
        nextTimeToShoot-=Time.deltaTime;
        transform.position+=new Vector3(-enemyS1Speed*Time.deltaTime,0,0);
        if(transform.position.x<-10f){
            Destroy(gameObject);
        }
        if(nextTimeToShoot<0){
            shoot();
            nextTimeToShoot=tempShoot;
        }
    }

    void shoot(){
        Instantiate(fireBall, firePoint.transform.position,Quaternion.Euler(0, -90, 0));
    }

      void IDamageable.TakeDamage(float damage)
      {
          hp -= damage;
         //Debug.Log(gameObject.name + " took " + damage + " damage.");
          if(hp <= 0)
          {
             // boomFx.Play();
              Instantiate(explosion, transform.position+new Vector3(-.6f,0,0),Quaternion.Euler(-90, 180, 90));
               string currentScore= score.text;
               int newScore=desScore+(int.Parse(currentScore));
               score.text=newScore.ToString();
               Destroy(gameObject);
          }
      }
}
