using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int value = 0;

    void Start()
    {
        Load();
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            value = PlayerPrefs.GetInt("highScore");
        }
    }

    public static void Save(int score)
    {
        value = score;
        PlayerPrefs.SetInt("highScore", value);
    }
}
