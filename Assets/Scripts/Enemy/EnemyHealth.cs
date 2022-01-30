using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    isEnemyFire isEnemyFire;
    PlayerPlaceHolder playerPlaceHolder;
    Animator anim;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject shooter;
    [SerializeField] Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        playerPlaceHolder = FindObjectOfType<PlayerPlaceHolder>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update() 
    {

        if(currentHealth < 1)
        {  
            anim.SetBool("isDead", true);
            gameObject.tag = "DeadEnemy";
            healthText.enabled = false;
            //stopcanvas 
        }

        healthText.text = currentHealth.ToString();
    }


    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Bullet")
        {
            currentHealth--;
        }
    }

    
}
