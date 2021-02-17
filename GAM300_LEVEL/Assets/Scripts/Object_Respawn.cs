using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Respawn : MonoBehaviour
{
    bool killed;
    public GameObject obj;
    public GameObject respawnPoint;

    private void Update()
    {
        if (killed == true)
        {
            obj.transform.position = respawnPoint.transform.position;
            Debug.Log("Object Respawned");
            killed = false;
            Physics.SyncTransforms();
        }
    }

    public void RespawnObject()
    {
        
         killed = true;
        
    }
}
