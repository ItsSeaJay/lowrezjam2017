// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]

public class Lunar : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    void Start ()
	{
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            meshRenderer.enabled = false;
            boxCollider.isTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            meshRenderer.enabled = true;
            boxCollider.isTrigger = false;
        }
    } // End if
} // End public class Lunar
