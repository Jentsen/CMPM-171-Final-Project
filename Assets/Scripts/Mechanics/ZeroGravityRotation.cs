using UnityEngine;

public class ZeroGravityRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the object around its Y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
