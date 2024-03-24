using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete : MonoBehaviour
{
    [SerializeField] private int Endgame;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Exit")
        {
            SceneManager.LoadScene(Endgame, LoadSceneMode.Single); //เปลี่ยนไปหน้า Game Over
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
