using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSwitchSpeed, cameraRotateSpeed, mouseSensivity;
    public Transform fps, tps, transition;
    public static bool camera1, camera2,camera3;
    public Vector2 turn;
    float randomx,randomy;
    Component shooter;
    

    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<Shooter>();

        transform.position = tps.position;
        camera1 = true;
        camera2 = false;
        camera3 = false;

        Cursor.lockState = CursorLockMode.Locked; 

    }


    void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Randomize Spread
            randomx = Random.Range(-7,3);
            randomy = Random.Range(-6,3);
            turn.x += randomx;
            turn.y += randomy;
        }

        if(Input.GetMouseButton(0))
        {
        turn.x += Input.GetAxis("Mouse X") *mouseSensivity;
        turn.y += Input.GetAxis("Mouse Y") * mouseSensivity;
        transform.localRotation = Quaternion.Euler(-turn.y,turn.x,0);
        }

        if(Input.GetMouseButtonUp(0))
        {
            turn.x = 0;
            turn.y = 0;
        }
    }



    void LateUpdate()
    {
        CameraSwitcher();
    }



    void CameraSwitcher()
    {
        if (camera3)
        {
            transform.position = Vector3.Lerp(transform.position,
            transition.position, cameraSwitchSpeed * Time.deltaTime);

            transform.localRotation = Quaternion.Lerp(Quaternion.identity,
            Quaternion.Euler(0, 90, 0), cameraRotateSpeed);
        }

        else if (camera1 & !camera2 & !camera3)
        {
            transform.position = Vector3.Lerp(transform.position,
            tps.position, cameraSwitchSpeed * Time.deltaTime);

            transform.localRotation = Quaternion.Lerp(Quaternion.identity,
            Quaternion.Euler(0, 0, 0), cameraRotateSpeed);
        }

        else if (camera2 & !camera1 & !camera3)
        {
            transform.position = Vector3.Lerp(transform.position,
            fps.position, cameraSwitchSpeed * Time.deltaTime);
        }
    }
}
