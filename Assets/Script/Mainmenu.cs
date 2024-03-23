using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    [SerializeField] private int StartG;
    [SerializeField] private int AboutG;
    public void Startgame()
    {
        SceneManager.LoadScene(StartG, LoadSceneMode.Single);
    }

    public void Aboutgame()
    {
        SceneManager.LoadScene(AboutG, LoadSceneMode.Single);
    }

    public void Exitgame()
    {
        Application.Quit();
    }
}
