using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "changable")
        {
            door.transform.position += new Vector3(0, 4, 0);
        }
    }
}
