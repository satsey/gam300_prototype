using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public GameObject GameController;
    public Puzzle3 puzzle3;
    public Puzzle2 puzzle2;
    public Puzzle1 puzzle1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, 15f);
        GameController = GameObject.FindGameObjectWithTag("GameController");
        puzzle3 = GameController.GetComponent<Puzzle3>(); 
        puzzle2 = GameController.GetComponent<Puzzle2>(); 
        puzzle1 = GameController.GetComponent<Puzzle1>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("puzzle1box1"))
        {
            puzzle3.puzzle3OnHit(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("puzzle1box2"))
        {
            puzzle3.puzzle3OnHit(2);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("puzzle1box3"))
        {
            puzzle3.puzzle3OnHit(3);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("puzzle2box1"))
        {
            puzzle2.puzzle2OnHit(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("puzzle2box2"))
        {
            puzzle2.puzzle2OnHit(2);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("puzzle2box3"))
        {
            puzzle2.puzzle2OnHit(3);
            Destroy(gameObject);
        }


        if (collision.gameObject.CompareTag("puzzle3box1"))
        {
            puzzle1.LowerObj1();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("puzzle3box2"))
        {
            puzzle1.LowerObj2();
            Destroy(gameObject);
        }
    }

}
