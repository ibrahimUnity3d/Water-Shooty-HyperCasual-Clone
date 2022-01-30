using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private EnemyBulletPool enemyBulletsPool = null;
    [SerializeField] private float spawnInterval ;
    [SerializeField] Transform targetFPS,targetTPS,attackPoint;
    [SerializeField] float speed;
    
    
    Transform target;


    // Start is called before the first frame update
   
    void Start()  

    {
        
        target= targetTPS;
    }

    private void OnEnable() 
    {
        StartCoroutine(nameof(SpawnRoutine));
    }
        
     


    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
       {
           target = targetFPS;
       }
       else
       {
           target= targetTPS;
       }

        
    }


     private IEnumerator SpawnRoutine()
    {
        while(true)
        {     
            yield return new WaitForSeconds(spawnInterval);       
            var obj = enemyBulletsPool.GetPooledEnemyObject();

            Vector3 direction = target.position - attackPoint.position;

            obj.transform.position = attackPoint.position;

            Rigidbody bulletRigidbody = obj.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = Vector3.zero;
            bulletRigidbody.AddForce(direction.normalized * speed);
        }
    }
}
