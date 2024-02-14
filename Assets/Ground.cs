using UnityEngine;
using System.Collections.Generic;

public class Ground : MonoBehaviour
{
    public GameObject groundPlanePrefab; // Assign the plane prefab in the Inspector
    private HashSet<int> holeNumbers; // Set of unique numbers for hole positions

    void Start()
    {
        // Generate random numbers for holes
        GenerateRandomHoleNumbers(50); // Number of holes to create
        CreateGroundWithHoles();
    }

    void GenerateRandomHoleNumbers(int numberOfHoles)
    {
        holeNumbers = new HashSet<int>();
        while (holeNumbers.Count < numberOfHoles)
        {
            // Generate a random number for the hole position
            int randomNumber = Random.Range(0, 100); // Assuming a 10x10 grid with indices from 0 to 99
            holeNumbers.Add(randomNumber);
        }
    }

    void CreateGroundWithHoles()
    {
        // Calculate the number of tiles needed to cover the ground without holes
        int tilesX = 50;
        int tilesZ = 50;

        // Instantiate the ground tiles
        for (int x = -tilesX; x < tilesX; x++)
        {
            for (int z = -tilesZ; z < tilesZ; z++)
            {
                // Calculate the single number representing the position
                int tileNumber = (Mathf.Abs(x) * 10 + Mathf.Abs(z)) % 100;

                // Check if the current tile number is one of the holes
                if (tileNumber != 0 && holeNumbers.Contains(tileNumber))
                {
                    // This tile is a hole, so don't instantiate it
                    continue;
                }

                // Calculate the world position for the tile
                Vector3 tilePosition = new Vector3(x * 5, 0, z * 5);

                // Instantiate the tile
                Instantiate(groundPlanePrefab, tilePosition, Quaternion.identity, transform);
            }
        }
    }
}