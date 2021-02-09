using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject board1;
    public GameObject board2;
    public GameObject board3;


    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject barrier4;

    int currentBoard;

    int numCorrect = 0;

    void Start()
    {
        currentBoard = 1;

        OffAllLight();
        board1.GetComponent<Light>().enabled = true;
    }

    public void puzzle2OnHit(int num)
    {
        if (num == currentBoard)
        {
            int number = Random.Range(0, 2);

            numCorrect += 1;
            if (numCorrect >= 3)
            {
                Debug.Log("Solved");
                Destroy(barrier1);
                Destroy(barrier2);
                Destroy(barrier3);
                Destroy(barrier4);

            }

            OffAllLight();

            switch (currentBoard)
            {
                case 1:
                    if (number == 0)
                    {
                        currentBoard = 2;
                        board2.GetComponent<Light>().enabled = true;
                    }
                    else
                    {
                        currentBoard = 3;
                        board3.GetComponent<Light>().enabled = true;
                    }
                    break;

                case 2:
                    if (number == 0)
                    {
                        currentBoard = 1;
                        board1.GetComponent<Light>().enabled = true;
                    }
                    else
                    {
                        currentBoard = 3;
                        board3.GetComponent<Light>().enabled = true;
                    }
                    break;

                case 3:
                    if (number == 0)
                    {
                        currentBoard = 2;
                        board2.GetComponent<Light>().enabled = true;
                    }
                    else
                    {
                        currentBoard = 1;
                        board1.GetComponent<Light>().enabled = true;
                    }
                    break;

            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OffAllLight()
    {
        board1.GetComponent<Light>().enabled = false;
        board2.GetComponent<Light>().enabled = false;
        board3.GetComponent<Light>().enabled = false;

    }
}
