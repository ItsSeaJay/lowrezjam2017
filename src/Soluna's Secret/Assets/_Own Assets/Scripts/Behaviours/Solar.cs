// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Solar : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private Rigidbody solarRigidbody;

    public List<GameObject> lightsList = new List<GameObject>();

    void Start()
    {
        // Get the necessary References
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        solarRigidbody = GetComponent<Rigidbody>();

        // Fix the rigidbody settings
        solarRigidbody.useGravity = false;
        solarRigidbody.isKinematic = true;
    } // End void Start ()

    void Update()
    {
        // This is a 'Solar' object
        // It is enabled only if it is lit
        if (lightsList.Count > 0)
        {
            meshRenderer.enabled = true;
            boxCollider.isTrigger = false;
        }
        else
        {
            meshRenderer.enabled = false;
            boxCollider.isTrigger = true;
        }

        CleanupLightsList();
    } // End void Update ()

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light" &&
            !lightsList.Contains(other.gameObject))
        {
            lightsList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            lightsList.Remove(other.gameObject);
        }
    } // End void OnTriggerExit

    private void CleanupLightsList()
    {
        // Check for stray lights
        for (int i = 0; i < lightsList.Count; ++i)
        {
            // If a light in the list is no longer available
            if (!lightsList[i].activeInHierarchy ||
                lightsList[i] == null ||
                !lightsList[i].GetComponent<SphereCollider>().enabled)
            {
                // Remove that item from the list
                lightsList.Remove(lightsList[i]);
            } // End if (!go.activeInHierarchy || ..
        } // End foreach(GameObject go in lightsList)
    } // End private void CleanupLightsList()
} // End public class Solar
