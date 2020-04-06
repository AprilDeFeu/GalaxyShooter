using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame()
    {
        if (this.tag == "Exit") anim.Play("Exit");
        else Debug.LogError("Tag not attached to \"Exit\" button, or script misplaced.");
    } 
}
