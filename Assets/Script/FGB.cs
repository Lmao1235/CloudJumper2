using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FGB : MonoBehaviour
{
    [SerializeField] private int SceneBuild;
    public void Goback()
    {
        SceneManager.LoadScene(SceneBuild, LoadSceneMode.Single); //กลับไปหน้า Menu
    }
}
