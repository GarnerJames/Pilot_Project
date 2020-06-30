using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadScene("Character");
    }

    public void Play()
    {
        SceneManager.LoadScene("Exposition");
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Update()
    {
       
    }
}
