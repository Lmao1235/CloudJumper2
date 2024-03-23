using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Rigidbody rb;

    void Update()
    {
        if (Input.GetButtonDown("Jump")) // Change "Jump" to whatever input you want to use for jumping (e.g., "Space")
        {
            Jumpf();
        }
    }

    void Jumpf()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

}
