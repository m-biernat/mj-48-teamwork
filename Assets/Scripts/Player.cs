using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float range = 5.0f;

    private float clampMin, clampMax;

    private Rigidbody rb;

    private bool isReady = false;

    private void Start()
    {
        float z = transform.position.z;
        clampMin = z - range;
        clampMax = z + range;

        rb = GetComponent<Rigidbody>();
    }

    public void Move(float input)
    {
        Vector3 position = transform.position;
        position.z += input;

        position.z = Mathf.Clamp(position.z, clampMin, clampMax);

        transform.position = position;
    }

    public void Splash(float force)
    {
        if (isReady)
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private void OnCollisionExit(Collision collision)
    {
        isReady = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isReady = true;
    }
}
