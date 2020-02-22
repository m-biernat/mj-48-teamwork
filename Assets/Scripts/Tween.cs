using UnityEngine;
using System.Collections;

public class Tween : MonoBehaviour
{
    public static IEnumerator Shrink(GameObject go, int time, bool deactivate)
    {
        Vector3 scale = go.transform.localScale;

        float scaleFactor = 1.0f / time;
        float currScale = 1.0f + scaleFactor;

        for (int i = 0; i < time; i ++)
        {
            yield return new WaitForSeconds(0.01f);

            currScale -= scaleFactor;
            go.transform.localScale = scale * currScale;
        }

        if (deactivate)
        {
            go.SetActive(false);
            go.transform.localScale = scale;
        }
    }

    public static IEnumerator Enlarge(GameObject go, int time, float toScale)
    {
        go.SetActive(true);

        Vector3 scale = Vector3.one * toScale;

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
