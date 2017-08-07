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
    [SerializeField]
    private bool locked = false;
    [SerializeField]
    private Inscription inscription;

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
        // Only allow the player to walk through the door if it is open
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

        // If the door is locked, enable the inscription
        if (locked)
        {
            // Enable the inscription
            inscription.gameObject.SetActive(true);
        }
        else
        {
            // The door is unlocked
            // Disable the inscription

        }
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

    public void Lock()
    {
        locked = true;
    } // End public void Lock()

    public void Unlocked()
    {
        locked = true;
    } // End public void Unlock()
} // End public class Door
