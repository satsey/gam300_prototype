using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{


    public Slider woodProgressBar;
    

    // player movement variables
    public float speed = 10.0f;
    private Rigidbody rb;

    public float jumpForce = 100.0f;


    // throwing ball
    public GameObject ball;
    public GameObject woodball;


    public float ballforce = 30.0f;
    public Transform launchPos;
    public Transform cameraPos;
    // Start is called before the first frame update

    public int currentBallSelection = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        woodProgressBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentBallSelection == 0)
            {
                GameObject ballprefab = Instantiate(ball, transform.position, Quaternion.identity);
                ballprefab.GetComponent<Rigidbody>().AddForce(cameraPos.forward * ballforce);
            }
            else
            {
                GameObject ballprefab = Instantiate(woodball, transform.position, Quaternion.identity);
                ballprefab.GetComponent<Rigidbody>().AddForce(cameraPos.forward * ballforce);
            }    
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (woodProgressBar.value < 0.7f)
                return;

            if (currentBallSelection == 0)
                currentBallSelection = 1;
            else
                currentBallSelection = 0;
        }    

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v) * speed * Time.deltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPosition);

        // jumping

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }



        //rb.MovePosition(new Vector3(transform.position.z + straffe, transform.position.y, 
        //    transform.position.x + translation));
    }

   
    private void OnTriggerEnter(Collider other)
    {

        // when player touches a collectable

        // check for other type 
        if (other.CompareTag("Collectable"))
        {

            

            Destroy(other.gameObject);
            woodProgressBar.value += 0.25f;
        }
    }

}
