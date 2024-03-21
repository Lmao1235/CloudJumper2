using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    

    [SerializeField] private float speed;

    [SerializeField] private float gravity;
    [SerializeField] private float jumpforce;

    private CharacterController controller;
    private Transform cameraTransform;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform; 
    }

    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        Vector3 direction = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        direction.y = 0f; 

        
        controller.Move(direction * speed * Time.deltaTime);

        Vector3 gravityVector = Vector3.up * gravity;
        controller.Move(gravityVector * Time.deltaTime);

        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 Jumpheight = Vector3.up * jumpforce;
            controller.Move(Jumpheight * Time.deltaTime);
        }

    }
}
