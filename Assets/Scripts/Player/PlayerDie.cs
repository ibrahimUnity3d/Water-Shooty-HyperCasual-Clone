using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
   void OnTriggerEnter(Collider other) 
   {
       if(other.gameObject.tag == "EnemyBullet")
       {
           if(Input.GetMouseButton(0))
           {
            Debug.Log("İ m dead as your soul");
            SoundEffect.PlaySound("playerDeath");
            SceneManager.LoadScene(0);
           }
       }
   }



   void PauseGame ()
    {
        Time.timeScale = 0;
    }
}
