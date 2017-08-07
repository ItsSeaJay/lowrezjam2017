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

        // The door is interactable only if it is unlocked
        if (!locked)
        {
            tag = "Interactable";
        } // End if (!locked)
        else
        {
            tag = "Untagged";
        }
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
        if (locked &&
            !open)
        {
            // Show the inscription
            inscription.gameObject.SetActive(true);
        } // End if (locked)
        else
        {
            // The door is unlocked
            inscription.gameObject.SetActive(false);
        } // End else (locked)
    } // End void Update ()

    // Unlocked doors can be toggled open / shut
    public void Pry()
    {
        if (!locked)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Opening") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("Closing"))
            {
                // The door can be opened/closed
                if (open)
                {
                    Close();
                } // End if (open)
                else
                {
                    Open();
                } // End else (open)
            } // End if (animator.GetCurrentAnimatorStateInfo(0).IsName("Opening") || ...
        } // End if (!locked)
    } // End public void Pry

    private void Open()
    {
        if (!locked)
        {
            open = true;
            animator.Play("Opening");
        } // End if (!locked)
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

    public void Unlock()
    {
        locked = true;
    } // End public void Unlock()
} // End public class Door
