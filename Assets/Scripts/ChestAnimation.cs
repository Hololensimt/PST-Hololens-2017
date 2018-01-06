using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour {

    private bool isOpen = false;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnSelect()
    {
        animator.SetTrigger("Move");
        if (isOpen)
            isOpen = false;

        else
            isOpen = true;

        animator.SetBool("isOpen", isOpen);
        // animator.ResetTrigger("Move");
    }
}
