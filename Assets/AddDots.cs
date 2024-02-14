using UnityEngine;

public class DiceDots : MonoBehaviour
{
    public GameObject dotPrefab; // Assign your flat dot prefab in the Inspector

    void Start()
    {
       CreateAllDiceDots();
    }

    void CreateAllDiceDots()
    {
        float scale = 0.5f; // Scale of the cube to place dots on the surface
        float offset = scale * 0.6f; // Offset derived from the scale (60% of the scale)

        // Face 1 (Front)
        CreateDot(Vector3.forward, Vector3.zero, scale); // Center dot

        // Face 2 (Right)
        CreateDot(Vector3.right, new Vector3(0, offset, offset), scale);
        CreateDot(Vector3.right, new Vector3(0, -offset, -offset), scale);

        // Face 3 (Top)
        CreateDot(Vector3.up, new Vector3(-offset, 0, offset), scale);
        CreateDot(Vector3.up, Vector3.zero, scale); // Center dot
        CreateDot(Vector3.up, new Vector3(offset, 0, -offset), scale);

        // Face 4 (Back)
        CreateDot(Vector3.back, new Vector3(-offset, offset, 0), scale);
        CreateDot(Vector3.back, new Vector3(offset, offset, 0), scale);
        CreateDot(Vector3.back, new Vector3(-offset, -offset, 0), scale);
        CreateDot(Vector3.back, new Vector3(offset, -offset, 0), scale);

        // Face 5 (Left)
        CreateDot(Vector3.left, new Vector3(0, offset, offset), scale);
        CreateDot(Vector3.left, new Vector3(0, offset, -offset), scale);
        CreateDot(Vector3.left, new Vector3(0, -offset, offset), scale);
        CreateDot(Vector3.left, new Vector3(0, -offset, -offset), scale);
        CreateDot(Vector3.left, Vector3.zero, scale); // Center dot

        // Face 6 (Bottom)
        CreateDot(Vector3.down, new Vector3(-offset, 0, offset), scale);
        CreateDot(Vector3.down, new Vector3(-offset, 0, -offset), scale);
        CreateDot(Vector3.down, new Vector3(offset, 0, offset), scale);
        CreateDot(Vector3.down, new Vector3(offset, 0, -offset), scale);
        CreateDot(Vector3.down, new Vector3(offset, 0, 0), scale);
        CreateDot(Vector3.down, new Vector3(-offset, 0, 0), scale);
    }

    void CreateDot(Vector3 faceNormal, Vector3 localPosition, float scale)
    {
        // Instantiate the dot prefab as a child of the cube
        GameObject dot = Instantiate(dotPrefab, transform);
        // Position the dot relative to the cube's face
        dot.transform.localPosition = localPosition + faceNormal * scale; // The scale determines how far from the center the dot is placed
        // Orient the dot to face outward
        dot.transform.localRotation = Quaternion.LookRotation(faceNormal);
    }

}