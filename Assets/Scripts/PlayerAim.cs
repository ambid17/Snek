using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    //The rotation of the camera
    private Vector3 cameraRotation;

    private float minYRotation = -90f;
    private float maxYRotation = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxisRaw("Mouse X") * 10;
        float yMovement = -Input.GetAxisRaw("Mouse Y") * 10;

        // Calculate rotation from input
        cameraRotation = new Vector3(Mathf.Clamp(cameraRotation.x + yMovement, minYRotation, maxYRotation), cameraRotation.y + xMovement, cameraRotation.z);
        cameraRotation.z = Mathf.Lerp(cameraRotation.z, 0f, Time.deltaTime * 3f);
        
        transform.eulerAngles = cameraRotation;
    }
}
