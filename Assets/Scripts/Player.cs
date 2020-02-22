using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float range = 5.0f;

    private float clampMin, clampMax;

    private Rigidbody rb;

    private bool isReady = true;

    public GameObject boat;
    private Rigidbody boatRb;

    private void Start()
    {
        float z = transform.position.z;
        clampMin = z - range;
        clampMax = z + range;

        rb = GetComponent<Rigidbody>();
        boatRb = boat.GetComponent<Rigidbody>();
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
        if (!isReady)
        {
            isReady = true;
            OnSplash();
        }
    }

    private void OnSplash()
    {
        Vector3 heading = boat.transform.position - transform.position;

        float distance = heading.magnitude;
        Vector3 direction = heading / distance;

        float force = 1.0f / (distance * 0.04f);

        //float angle = Vector3.Angle(direction, boat.transform.position);
        float angle = Random.Range(30.0f, 90.0f);

        boatRb.AddForce(direction * force, ForceMode.Impulse);
        boatRb.AddTorque(0.0f, angle, 0.0f);
    }
}
