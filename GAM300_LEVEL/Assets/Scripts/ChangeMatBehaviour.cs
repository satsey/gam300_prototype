using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatBehaviour : MonoBehaviour
{
    //Material SphereMaterial;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        /*
        SphereMaterial = Resources.Load<Material>("SphereMaterial");
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // Get the current material applied on the GameObject
        Material oldMaterial = meshRenderer.material;
        Debug.Log("Applied Material: " + oldMaterial.name);
        // Set the new material on the GameObject
        meshRenderer.material = SphereMaterial;*/

        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeProperty()
    {
        if(!CompareTag("bar"))
            GetComponent<MeshRenderer>().material = player.GetComponent<PlayerController>().selectMat;

        GetComponent<Rigidbody>().mass = player.GetComponent<PlayerController>().selectMass;
    }
}
