using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public GameObject woodProgressBar;
    public Slider slider;
    

    // player movement variables
    public float speed = 10.0f;
    private Rigidbody rb;

    public float jumpForce = 100.0f;


    // throwing ball
    public GameObject ball;
    public float ballforce = 30.0f;
    public Transform launchPos;
    public Transform cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ballprefab = Instantiate(ball, transform.position, Quaternion.identity);
            ballprefab.GetComponent<Rigidbody>().AddForce(cameraPos.forward * ballforce);
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
        if(other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }

}
