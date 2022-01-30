using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
   [SerializeField] ParticleSystem bulletParticle;

   

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag!="EnemyBullet")
        {
            bulletParticle.Play();
        }
    }
}
