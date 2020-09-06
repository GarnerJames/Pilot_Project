using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Trigger : MonoBehaviour
{

    public Animator fadeOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fadeOut.SetTrigger("Death_Fade");
            Invoke("Quit", 2f);
        }
    }

    void Quit()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
