using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject scene_fadeIn;
    public GameObject prompts;

    private void Start()
    {
        scene_fadeIn.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Stage_One");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main_Menu");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Shutdown()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Prompts()
    {
        if (!prompts.activeInHierarchy)
        {
            prompts.SetActive(true);
        }
        else
        {
            prompts.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) 
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Prompts();
        }

    }
}
