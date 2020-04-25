using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelLoaded;

    public void FadeToLevel(int indexLevel)
    {
        levelLoaded = indexLevel;
        animator.SetTrigger("fadeOut");
        Time.timeScale = 1;
    }

    public void OnFadeComplete()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(levelLoaded);
    }

    public void ExitMenu()
    {
        Application.Quit();
    }
}
