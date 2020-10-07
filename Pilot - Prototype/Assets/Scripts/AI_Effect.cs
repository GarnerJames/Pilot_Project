using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI_Effect : MonoBehaviour
{
    public GameObject effect;
    public GameObject blackImage;
    public AudioSource aiVoice;
    public AudioSource sensors;
    public AudioSource wabwab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            aiVoice.Play();
            Invoke("Effect", 4f);
            
        }
    }

    void Effect()
    {
        effect.SetActive(true);
        Invoke("Sound", 2f);
        Invoke("Black", 10f);
    }

    void Sound()
    {
        sensors.Play();
    }

    void Black()
    {
        blackImage.SetActive(true);
        wabwab.enabled = false;
        Invoke("EndScene", 4f);
    }

    void EndScene()
    {
        SceneManager.LoadScene("Final_Demo_Second_Scene_A");
    }
}
