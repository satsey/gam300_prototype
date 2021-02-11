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
        
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit, 2))
        {
            target = hit.collider.gameObject;
            if (target.tag == "changable" || target.tag == "pickable")
            {
              target.GetComponent<BoxCollider>().enabled = false;
              target.GetComponent<Rigidbody>().useGravity = false;
              target.transform.position = theDest.position;
              target.transform.parent = GameObject.Find("Destination").transform;
            }

            //if(target.tag == "pickable")
            //{
            //    target.transform.position = theDest.position;
            //    target.transform.parent = GameObject.Find("Destination").transform;
            //}
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (target != null)
            { 
                target.transform.parent = null;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<Rigidbody>().useGravity = true;
                target = null;
            }
        }
    }
}
