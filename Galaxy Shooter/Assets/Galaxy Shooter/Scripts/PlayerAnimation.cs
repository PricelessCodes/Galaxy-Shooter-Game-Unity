using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator PlayerAnimator;

	// Use this for initialization
	void Start ()
    {
        PlayerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerAnimator.SetBool("TurnLeft", true);
            PlayerAnimator.SetBool("TurnRight", false);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayerAnimator.SetBool("TurnLeft", false);
            PlayerAnimator.SetBool("TurnRight", false);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerAnimator.SetBool("TurnRight", true);
            PlayerAnimator.SetBool("TurnLeft", false);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerAnimator.SetBool("TurnRight", false);
            PlayerAnimator.SetBool("TurnLeft", false);
        }



    }
}
