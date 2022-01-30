using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletsPool : MonoBehaviour
{
    Queue<GameObject>pooledObjects;
   [SerializeField] GameObject objectPrefab, playerBulletParent;
   [SerializeField] int poolSize;



    void Awake() 
    {
        pooledObjects = new Queue<GameObject>();

        for(int i=0; i < poolSize; i++)
        {
            GameObject obj= Instantiate(objectPrefab);
            obj.transform.parent= playerBulletParent.transform;
            obj.SetActive(false);

            pooledObjects.Enqueue(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);
        
        return obj ;
    }
}
