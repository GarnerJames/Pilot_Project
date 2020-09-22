using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   // public GameObject pauseMenu;
    public GameObject scene_fadeIn;
    public GameObject player;
    public GameObject endImage;
   // public GameObject prompts;

    private void Start()
    {
        scene_fadeIn.SetActive(true);
        //endImage.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Final_Demo");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Final_Demo_Main_Menu");
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Shutdown()
    {
        Application.Quit();
    }

    public void End()
    {
        Invoke("EndImage", 4f);
    }

    void EndImage()
    {
        //player.GetComponent<PlayerController>().canMove = false;
        endImage.SetActive(true);
        Invoke("Quit", 6f);
    }
    
}
