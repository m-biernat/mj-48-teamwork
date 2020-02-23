using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private Animator animator;
    
    public static LevelChanger instance;

    private void Start()
    {
        animator = GetComponent<Animator>();
        instance = this;
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void FadeOut()
    {
        animator.SetTrigger("fadeOut");
    }
}
