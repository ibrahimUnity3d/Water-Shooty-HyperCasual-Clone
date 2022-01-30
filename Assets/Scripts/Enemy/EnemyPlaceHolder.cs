using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaceHolder : MonoBehaviour
{
     GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player PlaceHolder");
    }




    // Update is called once per frame
    void Update()
    {
        EnemyRotation();
    }

    
    void EnemyRotation()
    {
        transform.LookAt(player.transform.position);
    }

}
