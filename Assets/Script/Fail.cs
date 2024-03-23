using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    [SerializeField] private int SceneBuild;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sea")
        {
            SceneManager.LoadScene(SceneBuild, LoadSceneMode.Single); //เปลี่ยนไปหน้า Game Over
        }


    }
}
