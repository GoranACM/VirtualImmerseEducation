using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPanel;
    
    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            videoPanel.SetActive(false);
        }
        else
        {
            videoPlayer.Play();
            videoPanel.SetActive(true);
        }
    }
}
