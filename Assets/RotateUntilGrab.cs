using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateUntilGrab : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 30f;

    // Reference to the XR grab interactable script
    private XRGrabInteractable grabInteractable;

    // Flag to track if the object is grabbed
    private bool isGrabbed = false;

    void Start()
    {
        // Get reference to the XR grab interactable script attached to the object
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        // Rotate the object if it is not grabbed
        if (!isGrabbed)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Check if the object is grabbed
        if (grabInteractable.isSelected)
        {
            isGrabbed = true;
            // Perform any actions when the object is grabbed
            Debug.Log("Object grabbed!");
        }
    }
}


