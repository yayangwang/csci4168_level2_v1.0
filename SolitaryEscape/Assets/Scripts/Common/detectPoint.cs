using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPoint : MonoBehaviour
{
    public Door door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "box")
        {
            other.GetComponent<BoxMove>().check = true;
            door.OpenDoor();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "box")
        {
            other.GetComponent<BoxMove>().check = false;
        }
    }
}
