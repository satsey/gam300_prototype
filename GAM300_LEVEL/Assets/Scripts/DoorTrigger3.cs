using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger3 : MonoBehaviour
{
    public GameObject collider1;
    public GameObject collider2;
    public GameObject door;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "box" && collider1.GetComponent<BoxCollider>().enabled == false && collider2.GetComponent<BoxCollider>().enabled == false)
        {
            door.transform.position += new Vector3(0, 1, 0);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
