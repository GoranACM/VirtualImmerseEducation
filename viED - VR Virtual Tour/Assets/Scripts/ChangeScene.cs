using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public GameObject ThisPanorama;
    public GameObject TargetPanorama;

    public void ChangeHotSpot()
    {
        if (TourManager.SetCameraPosition != null)
            TourManager.SetCameraPosition(TargetPanorama.transform.position, ThisPanorama.transform.position);
        TargetPanorama.gameObject.SetActive(true);
        ThisPanorama.gameObject.SetActive(false);
    }

    public void StartTour()
    {
        SceneManager.LoadScene("viEDVirtualTour");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
