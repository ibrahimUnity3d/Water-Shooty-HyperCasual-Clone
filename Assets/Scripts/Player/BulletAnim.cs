using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnim : MonoBehaviour
{
    Animator bulletAnim;
    public static bool isBulletFiring;

    // Start is called before the first frame update
    void Start()
    {
        bulletAnim = GetComponent<Animator>();
        isBulletFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
