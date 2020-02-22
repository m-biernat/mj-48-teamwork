using UnityEngine;
using System.Collections;

public class Whirl : MonoBehaviour
{
    public GameObject boat;
    private Rigidbody boatRb;

    private bool isDeadly;

    private int counter;

    void Start()
    {
        boatRb = boat.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (isDeadly)
        {
            Vector3 heading = boat.transform.position - transform.position;

            float distance = heading.magnitude;
            Vector3 direction = heading / distance;

            float force = 1.0f / (distance * 0.1f);

            boatRb.AddForce(-direction * force, ForceMode.Acceleration);
            
            if (distance < 0.5f)
                boatRb.AddTorque(0.0f, 30.0f, 0.0f);
        }
    }

    public IEnumerator Spawn(float delay)
    {
        StartCoroutine(Tween.Enlarge(gameObject, 50, 0.5f));

        yield return new WaitForSeconds(delay);

        StartCoroutine(Tween.Shrink(gameObject, 25, false));

        yield return new WaitForSeconds(1.0f);

        StartCoroutine(Tween.Enlarge(gameObject, 50, 1.0f));

        isDeadly = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Boat" && isDeadly)
        {
            counter++;
            
            if (counter == 50)
            {
                StartCoroutine(Tween.Shrink(boat, 50, true));
                isDeadly = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boat")
        {
            counter = 0;
        }
    }
}
