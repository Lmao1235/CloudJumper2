using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string VideoFileName;
    void Start()
    {
        PlayVideo();
    }

    

    public void PlayVideo() //��� video
    { 
        VideoPlayer VP = GetComponent<VideoPlayer>();

        if (VP)
        {
            string videopath = System.IO.Path.Combine(Application.streamingAssetsPath, VideoFileName);
            Debug.Log(videopath);
            VP.url = videopath;
            VP.Play();
        }

    }
}
