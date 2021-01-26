using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject barrier4;

    public int[] puzzle3order = new int[] { 1, 2, 3 };

    public int currentIndex = 0;
    public float interval = 1.0f;

    public bool solved = false;

    public void puzzle3OnHit(int num)
    {
        if (solved)
            return;

        if (num == puzzle3order[currentIndex])
        {
            Debug.Log("Correct");
            currentIndex += 1;
            if (currentIndex >= 3)
            {
                Debug.Log("Solved");
                solved = true;

                Destroy(barrier1);
                Destroy(barrier2);
                Destroy(barrier3);
                Destroy(barrier4);
            }


        }
        else
        {
            currentIndex = 0;
            Debug.Log("Wrong");
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
