using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEnemyFire : MonoBehaviour
{
    PlayerPlaceHolder playerPlaceHolder;
    public GameObject enemyShooter;
    Animator anim;
    bool isFiring, isDead;
    float onEnableTime, canFireTime;

    // Start is called before the first frame update
    void Start()
    {
        playerPlaceHolder = FindObjectOfType<PlayerPlaceHolder>();
        anim= GetComponent<Animator>();
        enemyShooter.SetActive(false);
        StartCoroutine(Firing());
    }

    void OnEnable() 
    {
        onEnableTime = Time.time;
        canFireTime = onEnableTime + 3;
    }

    void Update() 
    {
        isFiring = anim.GetBool("isFiring");
        isDead= anim.GetBool("isDead");
    }


   
    IEnumerator Firing()
    {
        while(true)
        { 
            ActivateFiring();
            yield return new WaitForSeconds(2);

            DeactivateFiring();
            yield return new WaitForSeconds(5);
        }

    }

    


    void ActivateFiring()
    {
        if(!isDead && !playerPlaceHolder.isRunning && Time.time > canFireTime)
        {
        anim.SetBool("isFiring",true);
        enemyShooter.SetActive(true);
        }
    }

    void DeactivateFiring()
    {
        anim.SetBool("isFiring",false);
        enemyShooter.SetActive(false);
    }
}
