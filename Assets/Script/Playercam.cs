using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercam : MonoBehaviour
{
    public float turnX;
    public float turnY;

    public Transform orientation;


    float xRotation;
    float yRotation;    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mousX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * turnX;
        float mousY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * turnY;

        yRotation += mousX;
        xRotation -= mousY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
