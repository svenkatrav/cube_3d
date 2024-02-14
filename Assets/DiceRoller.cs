using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    private Rigidbody rb;
    public float initialTorqueStrength = 0.5f; // Base strength for rolling the dice
    public float torqueAcceleration = 0.01f; // Acceleration rate for the torque
    public float torqueDeceleration = 2f; // Deceleration rate for the torque
    private float currentTorqueStrength; // Current torque strength

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentTorqueStrength = initialTorqueStrength;
        rb.maxAngularVelocity = 40;

    }

    void Update()
    {
        bool isRolling = false;

        // Apply torque based on arrow key input to roll the dice
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(Vector3.back * currentTorqueStrength, ForceMode.Force);
            isRolling = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(Vector3.forward * currentTorqueStrength, ForceMode.Force);
            isRolling = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddTorque(Vector3.right * currentTorqueStrength, ForceMode.Force);
            isRolling = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddTorque(Vector3.left * currentTorqueStrength, ForceMode.Force);
            isRolling = true;
        }

        // If any arrow key is pressed, increase the torque strength (accelerate)
        if (isRolling)
        {
            currentTorqueStrength += torqueAcceleration * Time.deltaTime;
        }
        else // If no arrow key is pressed, decrease the torque strength (decelerate)
        {
            currentTorqueStrength -= torqueDeceleration * Time.deltaTime;
            // Clamp the torque strength to not go below the initial strength
            currentTorqueStrength = Mathf.Max(currentTorqueStrength, initialTorqueStrength);
        }
    }
}