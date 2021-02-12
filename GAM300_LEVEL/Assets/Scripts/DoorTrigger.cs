using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "box")
        {
            door.transform.position += new Vector3(0, 1, 0);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
