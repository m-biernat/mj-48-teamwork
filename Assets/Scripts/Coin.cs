using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void OnPickUpDelegate();
    public static OnPickUpDelegate OnPickUp;

    private bool isPicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boat" && !isPicked)
        {
            isPicked = true;

            OnPickUp();
            StartCoroutine(Tween.Shrink(gameObject, 50, true));
            
            Destroy(gameObject, 1.0f);
        }
    }
}
