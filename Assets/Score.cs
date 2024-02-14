using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class ScoreCalculator : MonoBehaviour
{
    public Rigidbody diceRigidbody; // Assign the dice Rigidbody in the Inspector
    public TextMeshProUGUI scoreText; // Assign the TextMeshProUGUI element in the Inspector
    private int totalScore = 0;
    private bool hasSettled = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the dice has settled
        if (!hasSettled && diceRigidbody.IsSleeping())
        {
            hasSettled = true;
            int score = CalculateScore();
            totalScore += score;
            UpdateScoreText();
        }

        // Reset the flag when the dice is tossed again
        if (hasSettled && diceRigidbody.velocity.magnitude > 0)
        {
            hasSettled = false;
        }
    }

    private int CalculateScore()
    {
        // This is a simplified way to calculate the score based on the dice's up vector
        // You will need to adjust this logic based on how your dice's numbers are oriented
        if (Vector3.Dot(transform.forward, Vector3.up) > 0.9f) return 1; // Assuming 4 is on the right face
        if (Vector3.Dot(transform.right, Vector3.up) > 0.9f) return 2; // Assuming 5 is on the front face
        if (Vector3.Dot(transform.up, Vector3.up) > 0.9f) return 3; // Assuming 3 is on the left face
        if (Vector3.Dot(transform.forward, Vector3.down) > 0.9f) return 4; // Assuming 1 is on the top face
        if (Vector3.Dot(transform.right, Vector3.down) > 0.9f) return 5; // Assuming 2 is on the back face
        if (Vector3.Dot(transform.up, Vector3.down) > 0.9f) return 6; // Assuming 6 is on the bottom face
        return 10; // Default case if no face is clearly up
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
    }
}
