using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit, 4) && target == null)
        {
            target = hit.collider.gameObject;

            if ((target.CompareTag("box") || target.CompareTag("torch")) && target.GetComponent<Rigidbody>().mass < 10)
            {
                target.GetComponent<BoxCollider>().enabled = false;
                target.GetComponent<Rigidbody>().useGravity = false;
                target.transform.position = theDest.position;
                target.transform.parent = GameObject.Find("Destination").transform;
            }

            else
                target = null;
        }

        if (Input.GetKeyDown(KeyCode.R) && target != null)
        {
            target.transform.parent = null;
            target.GetComponent<Rigidbody>().useGravity = true;
            target.GetComponent<BoxCollider>().enabled = true;
            target = null;
        }
    }
}
