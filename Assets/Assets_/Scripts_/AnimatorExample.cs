using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorExample : MonoBehaviour
{
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator.Play("AnimationStateName");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button was clicked.");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W key is being held down.");
        }
    }
}
