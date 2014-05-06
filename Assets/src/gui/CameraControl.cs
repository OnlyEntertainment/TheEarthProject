using UnityEngine;
using System.Collections;


public class CameraControl : MonoBehaviour {


    Vector3 camPos;
    Vector3 camRotation;

    float scrollSpeed = 1.0f;
    
    float zoomSpeed = 1.5f;

    float posXMin = -5;
    float posXMax = 5;

    float posYMin = -5;
    float posYMax = 5;

    public float rotateDelay = 1.0f;
    public float rotateTimer;
    
    public GameObject worldGen;

	// Use this for initialization
	void Start () 
    {

        rotateTimer = rotateDelay;
	}
	
	// Update is called once per frame
	void Update () 
    {
        camPos = camera.transform.position;
        camRotation = camera.transform.localEulerAngles;

        if (rotateTimer > 0)
        {
            rotateTimer -= 1.0f * Time.deltaTime;
        }


        if (Input.GetMouseButton(1))
        {
            

            camPos.x = Mathf.Clamp(camPos.x + scrollSpeed * Input.GetAxis("Mouse X"), posXMin, posXMax);
            camPos.y = Mathf.Clamp(camPos.y + scrollSpeed * Input.GetAxis("Mouse Y"), posYMin, posYMax);

            camera.transform.position = camPos;
        }
        else if (Input.GetMouseButton(2))
        {

            if (rotateTimer <= 0)
            {
                
                if (Input.GetAxis("Mouse X") > 0) worldGen.transform.Rotate(0, 0, -(360 / 20), 0);
                if (Input.GetAxis("Mouse X") < 0) worldGen.transform.Rotate(0, 0, (360 / 20), 0);
                rotateTimer = rotateDelay;
            }
            //camRotation.z = camRotation.z + scrollSpeed * Input.GetAxis("Mouse X");

            //camera.transform.localEulerAngles = camRotation;

        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        { 
            
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize + -(zoomSpeed * Input.GetAxis("Mouse ScrollWheel")), 3, 8);
            
        }

	}
}
