using UnityEngine;

public class DiceToss : MonoBehaviour
{
    public CameraViewSwitch cameraViewSwitch; // Assign the cameraViewSwitch script in the Inspector
    private Rigidbody rb;
    public float torqueStrength = 10f; // Adjust the torque strength as needed
    public float upwardForceStrength = 15f; // Adjust the upward force strength to toss the Dice higher

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the spacebar is pressed and the camera is not in top-down view
        if (Input.GetKeyDown(KeyCode.Space) && !cameraViewSwitch.IsTopDownView)
        {
            TossDice();
            cameraViewSwitch.NotifyDiceThrown(); // Notify the camera controller that the dice has been thrown
        }
    }

    void TossDice()
    {
        // Ensure the Dice is not already moving significantly to prevent continuous tosses
        if (rb.velocity.magnitude < 0.1f && rb.angularVelocity.magnitude < 0.1f)
        {
            // Add a random rotation force
            rb.AddTorque(Random.Range(-1f, 1f) * torqueStrength,
                         Random.Range(-1f, 1f) * torqueStrength,
                         Random.Range(-1f, 1f) * torqueStrength,
                         ForceMode.Impulse);

            // Add a stronger upward force to toss the Dice higher into the air
            rb.AddForce(Vector3.up * upwardForceStrength, ForceMode.Impulse);
        }
    }
}