using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool killed; 
    public GameObject player;
    public GameObject respawnPoint;

    private void Update()
    {
        if (killed == true)
        {
            player.transform.position = respawnPoint.transform.position;
            Debug.Log("TEST");
            killed = false;
            Physics.SyncTransforms();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            killed = true;
        }
        else if (col.gameObject.tag == "torch" || col.gameObject.tag == "box")
        {
            col.transform.GetComponent<Object_Respawn>().RespawnObject();
        }
    }

}
