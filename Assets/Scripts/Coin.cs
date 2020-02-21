using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boat")
        {
            // GameManager AddPoint
            StartCoroutine(Tween.Shrink(gameObject, 50));
        }
    }
}
