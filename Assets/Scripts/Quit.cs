using UnityEngine;

public class Quit : MonoBehaviour
{
    private void Start()
    {
#if UNITY_STANDALONE
        DontDestroyOnLoad(gameObject);
#else
        enabled = false;
#endif
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
