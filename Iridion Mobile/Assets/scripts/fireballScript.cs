using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour
{
    public float fbSpeed=100f,timeDestroy=2f;
    float damage=10f;
    void OnAwake(){

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(fbSpeed*Time.deltaTime,0,0);
        timeDestroy-=Time.deltaTime;

        if(timeDestroy<=0){
            Destroy(gameObject);
        }
    }

     private void OnCollisionEnter(Collision collision){
          IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
  
            if(damageable != null)
            {
                damageable.TakeDamage(damage);
                Destroy(gameObject);
            }

     }
}
