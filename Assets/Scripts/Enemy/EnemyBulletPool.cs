using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public EnemyShooter enemyShooter;
    Queue<GameObject>pooledEnemyObjects;
   [SerializeField] GameObject objectPrefab, enemyBulletParent;
   [SerializeField] int poolSize;
   public bool isEnemyShooting;



    void Awake() 
    {
        pooledEnemyObjects = new Queue<GameObject>();

        for(int i=0; i < poolSize; i++)
        {
            GameObject obj= Instantiate(objectPrefab);
            obj.transform.parent = enemyBulletParent.transform;
            obj.SetActive(false);

            pooledEnemyObjects.Enqueue(obj);
        }
    }


    public GameObject GetPooledEnemyObject()
    {
        GameObject obj = pooledEnemyObjects.Dequeue();
        obj.SetActive(true);
        pooledEnemyObjects.Enqueue(obj);
        
        return obj ;
    }

}
