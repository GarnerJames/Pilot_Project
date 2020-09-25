using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio_Controller : MonoBehaviour
{
    public AudioSource step;
    public AudioSource ladderClimb;
    public AudioSource land;
    public AudioSource slide;
    public AudioSource run;
    public AudioSource fire;

    private void Step()
    {
        step.Play();
    }

    private void Run()
    {
        run.Play();
    }

    private void Ladder()
    {
        ladderClimb.Play();
    }

    private void Land()
    {
        land.Play();
    }

    private void Slide()
    {
        slide.Play();
    }

    private void Fire()
    {
        fire.Play();
    }
}
