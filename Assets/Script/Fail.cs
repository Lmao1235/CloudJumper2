using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    [SerializeField] private int SceneBuild;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fall")
        {
            SceneManager.LoadScene(SceneBuild, LoadSceneMode.Single); //เปลี่ยนไปหน้า Game Over
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Slime")
        {
            SceneManager.LoadScene(SceneBuild, LoadSceneMode.Single); //เปลี่ยนไปหน้า Game Over
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
