using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public GameObject scene_fadeIn;
    public GameObject player;
    public GameObject endImage;


    private void Start()
    {
        scene_fadeIn.SetActive(true);
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
        SceneManager.LoadScene("Final_Demo_A");
    }

    public void VersionB()
    {
        SceneManager.LoadScene("Final_Demo_B");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Shutdown()
    {
        Application.Quit();
    }
}
