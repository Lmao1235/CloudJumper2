using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Movement : MonoBehaviour
{
    

    [SerializeField] private float speed;

    Vector3 movement;

    float HorizonInput;
    float VertaicalInput;


    public Rigidbody rb;

   

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * VertaicalInput);
        //transform.Translate(-Vector3.forward * Time.deltaTime * HorizonInput);
        transform.Rotate(Vector3.up * HorizonInput * speed * Time.deltaTime);


    }
}
