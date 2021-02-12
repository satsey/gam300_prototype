using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

    public void ChangeBoxProperty()
    {
        if (player.GetComponent<PlayerController>().selectMat == PlayerController.MatEnum.WOOD)
        {
            Debug.Log("BoxWoodMat");
            //Debug.Log(AssetDatabase.GetAssetPath(player.GetComponent<PlayerController>().BoxWoodMat));
            Debug.Log(player.GetComponent<PlayerController>().BoxWoodMat);
            GetComponent<MeshRenderer>().material = player.GetComponent<PlayerController>().BoxWoodMat;
            GetComponent<Rigidbody>().mass = player.GetComponent<PlayerController>().selectMass;
        }

        else if (player.GetComponent<PlayerController>().selectMat == PlayerController.MatEnum.METAL)
        {
            Debug.Log("BoxMetalMat");
            GetComponent<MeshRenderer>().material = player.GetComponent<PlayerController>().BoxMetalMat;
            GetComponent<Rigidbody>().mass = player.GetComponent<PlayerController>().selectMass;
        }
    }

    public void ChangeBarProperty()
    {
        if (player.GetComponent<PlayerController>().selectMat == PlayerController.MatEnum.WOOD)
        {
            Debug.Log("BarWoodMat");
            GetComponent<MeshRenderer>().material = player.GetComponent<PlayerController>().BarWoodMat;
            GetComponent<Rigidbody>().mass = player.GetComponent<PlayerController>().selectMass;
        }

        else if (player.GetComponent<PlayerController>().selectMat == PlayerController.MatEnum.METAL)
        {
            Debug.Log("BarMetalMat");
            GetComponent<MeshRenderer>().material = player.GetComponent<PlayerController>().BarMetalMat;
            GetComponent<Rigidbody>().mass = player.GetComponent<PlayerController>().selectMass;
        }
    }
}
