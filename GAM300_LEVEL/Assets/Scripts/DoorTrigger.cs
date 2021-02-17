using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    public GameObject lamp;
    public Material newMat;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "box")
        {
            if (col.gameObject.GetComponent<Rigidbody>().mass >= 10)
            {
                door.transform.position -= new Vector3(0, 2, 0);
                Debug.Log("DT_1");
                gameObject.GetComponent<BoxCollider>().enabled = false;
                lamp.GetComponent<MeshRenderer>().material = newMat;
            }
        }
    }
}
