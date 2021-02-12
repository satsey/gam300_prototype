using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger2 : MonoBehaviour
{
    public GameObject collider1;
    public GameObject door;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "box" && collider1.GetComponent<BoxCollider>().enabled == false)
        {
            if (col.gameObject.GetComponent<Rigidbody>().mass >= 10)
            {
                door.transform.position += new Vector3(0, 1, 0);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
