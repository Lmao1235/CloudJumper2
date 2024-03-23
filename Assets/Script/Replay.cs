using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    [SerializeField] private int Replayg;
    
    public void Replaygame()
    {
        SceneManager.LoadScene(Replayg, LoadSceneMode.Single); //Replay ¡Á
    }

   

    public void Exitgame()
    {
        Application.Quit(); //ÍÍ¡à¡Á
    }
}
