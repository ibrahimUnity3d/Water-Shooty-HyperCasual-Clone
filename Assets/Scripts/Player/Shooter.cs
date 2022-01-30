using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public LayerMask IgnoreMe;
    [SerializeField] private PlayerBulletsPool playerBulletsPool = null;
    [SerializeField] private float spawnInterval;
    [SerializeField] Transform attackPoint;
    [SerializeField] Camera fpsCam;
    [SerializeField] float speed;
    private float timer;


    // Start is called before the first frame update

    void OnEnable()
    {
        timer = spawnInterval;
    }


    // Update is called once per frame
    void Update()
    {
        CalculateShootTime();
    }


    private void CalculateShootTime()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        else
        {
            timer = spawnInterval;
            Shoot();
        }
    }



    private void Shoot()
    {
        var obj = playerBulletsPool.GetPooledObject();

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit, ~IgnoreMe))
            targetPoint = hit.point;

        else
            targetPoint = ray.GetPoint(75);
        Vector3 direction = targetPoint - attackPoint.position;

        obj.transform.position = attackPoint.position;

        Rigidbody bulletRigidbody = obj.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.AddForce(direction.normalized * speed);
        SoundEffect.PlaySound("splash");
    }
}
