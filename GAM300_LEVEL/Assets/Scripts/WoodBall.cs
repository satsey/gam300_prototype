using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {

            // set door property to wood
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
