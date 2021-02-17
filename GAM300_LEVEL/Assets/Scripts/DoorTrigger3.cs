using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger3 : MonoBehaviour
{
    public GameObject collider1;
    public GameObject collider2;
    public GameObject door;
    public GameObject lamp;
    public GameObject lamp2;
    public GameObject lamp3;
    public Material newMat;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "box" && collider1.GetComponent<BoxCollider>().enabled == false && collider2.GetComponent<BoxCollider>().enabled == false)
        {
            if (col.gameObject.GetComponent<Rigidbody>().mass >= 10)
            {
                door.transform.position -= new Vector3(0, 3, 0);
                Debug.Log("DT_3");
                gameObject.GetComponent<BoxCollider>().enabled = false;
                lamp.GetComponent<MeshRenderer>().material = newMat;
                lamp2.GetComponent<MeshRenderer>().material = newMat;
                lamp3.GetComponent<MeshRenderer>().material = newMat;
            }
        }
    }
}
