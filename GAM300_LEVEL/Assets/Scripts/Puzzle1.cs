using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;

    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject barrier4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckEqual()
    {

        if (Mathf.Abs(gameObject1.transform.position.y - gameObject2.transform.position.y) >3.0f)
            return;
        if (Mathf.Abs(gameObject1.transform.position.y - gameObject3.transform.position.y) > 3.0f)
            return;
        if (Mathf.Abs(gameObject2.transform.position.y - gameObject2.transform.position.y) > 3.0f)
            return;
        Destroy(barrier1);
        Destroy(barrier2);
        Destroy(barrier3);
        Destroy(barrier4);
    }
    public void LowerObj1()
    {
        gameObject1.transform.position = gameObject1.transform.position - new Vector3(0, 2, 0);

        CheckEqual();
    }

    public void LowerObj2()
    {
        gameObject2.transform.position = gameObject2.transform.position - new Vector3(0, 2, 0);
        CheckEqual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
