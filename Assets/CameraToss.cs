using UnityEngine;
using System.Collections;

public class CameraViewSwitch : MonoBehaviour
{
    public Transform dice; // Assign the dice transform in the Inspector
    public Rigidbody diceRigidbody; // Assign the dice Rigidbody in the Inspector
    public CameraFollow cameraFollow; // Assign the CameraFollow script in the Inspector
    public float settledThreshold = 0.01f; // Velocity threshold to consider the dice as settled
    public bool IsTopDownView { get; private set; } // Public property to track the camera view state

    private Vector3 initialPosition = new Vector3(0, 4, -10); // Initial camera position during the toss
    private bool diceThrown = false; // Flag to check if the dice has been thrown
    private float delayBeforeReset = 2f; // Time in seconds before resetting the camera view

    void Start()
    {
        // Set the initial camera position
        transform.position = initialPosition;
        // Make the camera look at the dice
        transform.LookAt(dice.position);
        IsTopDownView = false;
    }

    void Update()
    {
        // Check if the dice has been thrown and has settled on the ground
        if (diceThrown && diceRigidbody.velocity.y < 0 && diceRigidbody.velocity.magnitude < settledThreshold && diceRigidbody.angularVelocity.magnitude < settledThreshold)
        {
            // Move the camera to top-down view after the dice has settled
            MoveToTopDownView();
            // Reset the diceThrown flag
            diceThrown = false;
            // Start the coroutine to reset the camera view after a delay
            StartCoroutine(ResetCameraViewAfterDelay(delayBeforeReset));
        }
    }

    public void NotifyDiceThrown()
    {
        diceThrown = true;
    }

    void MoveToTopDownView()
    {
        // Calculate a position above the dice
        Vector3 topDownPosition = dice.position + Vector3.up * 10f; // Adjust the multiplier to set the desired height

        // Set the camera position and rotation for a top-down view
        transform.position = topDownPosition;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Look straight down
        IsTopDownView = true;

        // Disable the CameraFollow script
        if (cameraFollow != null)
        {
            cameraFollow.enabled = false;
        }
    }

    public void ResetCameraPosition()
    {
        // Reset the camera to the initial position
        transform.position = initialPosition;
        // Make the camera look at the dice again
        transform.LookAt(dice.position);
        IsTopDownView = false;

        // Re-enable the CameraFollow script
        if (cameraFollow != null)
        {
            cameraFollow.enabled = true;
        }
    }

    IEnumerator ResetCameraViewAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        ResetCameraPosition();
    }
}