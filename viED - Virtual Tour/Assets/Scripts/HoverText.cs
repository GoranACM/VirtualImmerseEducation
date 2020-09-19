using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverText : MonoBehaviour
{
    public GameObject textHover;

    // Start is called before the first frame update
    void Start()
    {
        textHover.SetActive(false);
    }

    void OnMouseOver()
    {
        textHover.SetActive(true);
    }

    void OnMouseExit()
    {
        textHover.SetActive(false);
    }

    
}
