using UnityEngine;

public class Boat : MonoBehaviour
{
    public GameManager gameManager;

    public void Kill()
    {
        gameManager.GameOver();
        StartCoroutine(Tween.Shrink(gameObject, 50, true));
    }
}
