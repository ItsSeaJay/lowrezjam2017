// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Light))]

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private bool isLit = true;

    private Animator animator;
    private Light light;

	void Start ()
	{
        // Get references to attatched components
        animator = GetComponent<Animator>();
        light = GetComponent<Light>();

        tag = "Interactable";
	} // End void Start ()

	void Update ()
	{
        HandleAnimations();
    } // End void Update ()

    private void HandleAnimations ()
    {
        // Handle animations depending on light status
        if (isLit)
        {
            // Play the lantern lighting animation
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Lighting Up") &&
                !animator.GetCurrentAnimatorStateInfo(0).IsName("Lit"))
            {
                animator.Play("Lighting Up");
            } // End if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Lighting Down") && ...
        } // End if (isLit)
        else 
        {
            // It is unlit
            // Play the lantern extinguishing animation
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Lighting Down") &&
                !animator.GetCurrentAnimatorStateInfo(0).IsName("Unlit"))
            {
                animator.Play("Lighting Down");
            } // End if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Lighting Down") && ...
        } // End else (isLit)
    } // End private void HandleAnimations

    public void Pickup()
    {

    } // End if 

    // Accessors / Mutators
    public bool IsLit
    {
        get
        {
            return isLit;
        } // End get
        set
        {
            isLit = value;
        } // End set
    } // End public bool IsLit
} // End public class Lantern
