// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider))]

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool open = false;

    private Animator animator;
    private BoxCollider boxCollider;

	void Start ()
	{
        // Get references to commponents
        animator    = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();

        // Set the door to be open/closed
        if (open)
        {
            animator.Play("Open");
        } // End if (open)
        else
        {
            animator.Play("Closed");
        } // End else (open)
	} // End void Start ()

	void Update ()
	{
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            // Allow the player to pass through the door
            boxCollider.enabled = false;
        } // End if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        else
        {
            // Stop the player going through the door
            boxCollider.enabled = true;
        } // End else (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
    } // End void Update ()

    public void Open()
    {
        open = true;
        animator.Play("Opening");
    } // End public void Open()

    public void Close()
    {
        open = false;
        animator.Play("Closing");
    } // End public void Open()
} // End public class Door
