using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyS1FireBall : MonoBehaviour
{
    public float efbSpeed=50f,timeDestroy=5f;
    int damage=5;
    void OnAwake(){

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(-efbSpeed*Time.deltaTime,0,0);
        timeDestroy-=Time.deltaTime;
        if(timeDestroy<=0){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision){
          shipSpecs damageable = collision.gameObject.GetComponent<shipSpecs>();
  
            if(damageable != null)
            {
                damageable.takeTheDamage(damage);
                Destroy(gameObject);
            }

     }
}
