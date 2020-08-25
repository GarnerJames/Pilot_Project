using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Down_Trigger : MonoBehaviour
{

    public GameObject elevator;
    public GameObject button;

    public Material buttonPushMaterial;
    public Material buttonMaterial;

    public float elevatorLevel;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Fire3"))
        {
            elevator.transform.position = new Vector3 (elevator.transform.position.x, elevatorLevel, elevator.transform.position.z);
            button.GetComponent<MeshRenderer>().material = buttonPushMaterial;
            Invoke("ButtonColour", 4f);
        }
    }

    void ButtonColour()
    {
        button.GetComponent<MeshRenderer>().material = buttonMaterial;
    }
}
