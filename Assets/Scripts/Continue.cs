﻿using UnityEngine;

public class Continue : MonoBehaviour
{
    public enum Mode
    {
        None,
        Continue,
        Play,
    };

    public Mode currentMode;

    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Execute(currentMode);
        }
    }

    private void Execute(Mode mode)
    {
        switch (mode)
        {
            case Mode.None:
                break;

            case Mode.Continue:
                animator.SetTrigger("continue");
                break;

            case Mode.Play:
                LevelChanger.instance.FadeOut();
                break;
        }
    }
}
