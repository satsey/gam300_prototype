using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxes : MonoBehaviour
{
    public GameObject Trigger1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Trigger1.GetComponent<Trigger01>().type == MaterialType.wood)
            {
                Debug.Log("Wood");
                Trigger1.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
