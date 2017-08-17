﻿// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private AudioClip igniteClip, extinguishClip;
    [SerializeField]
    private bool isLit = true;
    [SerializeField]
    private SphereCollider haloCollider;
    [SerializeField]
    private Light lanternLight;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        haloCollider.enabled = isLit;
        lanternLight.enabled = isLit;

        if (isLit)
        {
            animator.Play("Lit");
        } // End if (isLit)
        else
        {
            animator.Play("Unlit");
        } // End else (isLit)
    } // End void OnEnable

    void Start ()
	{
        // Get references to attatched components
        animator = GetComponent<Animator>();

        tag = "Interactable";
	} // End void Start ()

    void Update ()
	{
        HandleAnimations();

        haloCollider.enabled = isLit;
        lanternLight.enabled = isLit;
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

    // Accessors / Mutators
    public SphereCollider HaloCollider
    {
        get
        {
            return haloCollider;
        }
    }

    public Light LanternLight
    {
        get
        {
            return lanternLight;
        }
    }

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
