using UnityEngine;
using System.Collections;

public class Tween : MonoBehaviour
{
    public static IEnumerator Shrink(GameObject go, int time)
    {
        Vector3 scale = go.transform.localScale;

        float scaleFactor = 1.0f / time;
        float currScale = 1.0f;

        for (int i = 0; i < time; i ++)
        {
            yield return new WaitForSeconds(0.01f);

            currScale -= scaleFactor;
            go.transform.localScale = scale * currScale;
        }

        go.SetActive(false);
    }

    public static IEnumerator Enlarge(GameObject go, int time)
    {
        go.SetActive(true);

        Vector3 scale = go.transform.localScale;

        float scaleFactor = 1.0f / time;
        float currScale = 0.0f;

        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(0.01f);

            currScale += scaleFactor;
            go.transform.localScale = scale * currScale;
        }
    }
}
