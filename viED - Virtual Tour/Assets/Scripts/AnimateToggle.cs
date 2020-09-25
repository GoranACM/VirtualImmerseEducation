using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateToggle : MonoBehaviour
{

    public Animator anim;
    public Button button;

    private void Start()
    {
        anim.enabled = true;
       //anim = gameObject.GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        anim.enabled = false;
    }
    void Update()
    {
        
    }
}
