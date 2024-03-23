using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Vector3 PlayerMovement;
    private Vector2 MouseInput;
    private float xRot;

    [SerializeField] private LayerMask Floormask;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float Speed;
    [SerializeField] private float Jumpforce;
    [SerializeField] private float Sensitivity;

    void Update()
    {
        PlayerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        MovePlayer();
        MoveCamera();

    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovement) * Speed;
        rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(FeetTransform.position, 0.1f, Floormask))
            {
                rb.AddForce(Vector3.up * Jumpforce, ForceMode.Force); 
            }
            
        }




    }

    private void MoveCamera()
    {
        xRot -= MouseInput.y * Sensitivity;

        transform.Rotate(0f, MouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

}
