using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPlaceHolder : MonoBehaviour
{
    Animator anim;
    [SerializeField] Transform[] targetPlaceTransforms;
    [SerializeField] GameObject[] enemies;
    [SerializeField] float speed;
    [SerializeField] int IndexLenght = 5;
    public GameObject bullet, shooter,gunTPS, enemy;
    GameObject crosshair,gun,body;  
    Vector3 targetPlacePosition;
    public bool isRunning;    
    int currentIndex, newIndex, deadEnemyNumber;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        SetGun();

        currentIndex = 0;

    }

   


    // Update is called once per frame
    void Update()
    {
        CurrentEnemyandTarget();
        MouseDownUp();
        CurrentIndex();
        CongratProcess();
    }


   
    void FixedUpdate()
    {
        if(deadEnemyNumber !=5)
        {
        Walking();
        }
    }


void MouseDownUp()
    {
        if (Input.GetMouseButtonDown(0) && !CameraController.camera3)
        {
            CameraController.camera1 = false;
            CameraController.camera2 = true;

            StartFiring();
        }

        if ((Input.GetMouseButton(0) && CameraController.camera3))
        {
            anim.SetBool("isRunning", true);

            StopFiring();
        }

        if (Input.GetMouseButtonUp(0))
        {
            CameraController.camera1 = true;
            CameraController.camera2 = false;

            StopFiring();
        }
    }

   

    private void Walking()
    {
        Vector3 a = transform.position;
        Vector3 b = targetPlacePosition;
        transform.position = Vector3.MoveTowards(a, b, speed);

        if (transform.position == targetPlacePosition)
        {
            anim.SetBool("isRunning", false);
            isRunning = false;
            CameraController.camera3 = false;
            transform.LookAt(enemy.transform.position);
        }
        else
        {
            anim.SetBool("isRunning", true);
            isRunning = true;
            CameraController.camera3 = true;
            transform.LookAt(targetPlacePosition);
        }
    }

    

    IEnumerator CrossHairAppearence(float seconds, GameObject obj)
    {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(true);
    }

   public void CurrentEnemyandTarget()
    {
        targetPlacePosition = targetPlaceTransforms[currentIndex].position;
        enemy = enemies[currentIndex];
        enemy.SetActive(true);
    }


     void CurrentIndex()
    {
        deadEnemyNumber = GameObject.FindGameObjectsWithTag("DeadEnemy").Length;
        newIndex = deadEnemyNumber;

        if(currentIndex < 4)
       {
            if(newIndex > currentIndex)
        {
           Invoke("IndexPlus", 1.5f);
        }
       }
    }


    void IndexPlus()
    {
        currentIndex = newIndex;
        SoundEffect.PlaySound("enemyDeath");
    }


    void CongratProcess()
    {
        if(deadEnemyNumber == 5)
        {
            SoundEffect.PlaySound("congrat");
            anim.SetTrigger("Congrat");
        }
    }



     private void SetGun()
    {
        crosshair = GameObject.FindGameObjectWithTag("CrossHair");
        gun = GameObject.FindGameObjectWithTag("Gun");
        body = GameObject.FindGameObjectWithTag("Body");

        crosshair.SetActive(false);
        gun.SetActive(false);
        bullet.SetActive(false);
        shooter.SetActive(false);
    }


     void StartFiring()
    {
        anim.SetBool("isFiring", true);

        StartCoroutine(CrossHairAppearence(0.3f, crosshair));
        gun.SetActive(true);
        bullet.SetActive(true);
        shooter.SetActive(true);
        gunTPS.SetActive(false);
    }



    void StopFiring()
    {
        anim.SetBool("isFiring", false);

        crosshair.SetActive(false);
        gun.SetActive(false);
        bullet.SetActive(false);
        shooter.SetActive(false);
        gunTPS.SetActive(true);
    }
}
