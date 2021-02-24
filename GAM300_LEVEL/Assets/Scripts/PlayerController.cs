using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public enum MatEnum
    {
        WOOD,
        METAL
    };

    public Slider woodProgressBar;

    // Materials
    // Wood
    public Material BoxWoodMat;
    public float BoxWoodMass = 1;
    //Metal
    public Material BoxMetalMat;
    public float BoxMetalMass = 10;

    // Wood
    public Material BarWoodMat;
    public float BarWoodMass = 1;
    //Metal
    public Material BarMetalMat;
    public float BarMetalMass = 10;

    // Selected material
    public MatEnum selectMat;
    public float selectMass;

    // Range
    public float range = 10; // 2 per cube, 5*2 = 10

    // Target to change
    public GameObject target;

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
        /*rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        woodProgressBar.value = 0;*/

        // Set selected material & mass to wood(mat1)
        selectMat = MatEnum.WOOD;
        selectMass = 1;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Looking at object & within range
        //CheckSee();

        if (Input.GetMouseButtonDown(0) && CheckSee() && target != null)
        {
            /*
            if (currentBallSelection == 0)
            {
                GameObject ballprefab = Instantiate(ball, transform.position, Quaternion.identity);
                ballprefab.GetComponent<Rigidbody>().AddForce(cameraPos.forward * ballforce);
            }
            else
            {
                GameObject ballprefab = Instantiate(woodball, transform.position, Quaternion.identity);
                ballprefab.GetComponent<Rigidbody>().AddForce(cameraPos.forward * ballforce);
            }    */

            // Change material
            if (target.CompareTag("bar") && GameObject.Find("Destination").transform.childCount == 0)
                target.GetComponent<ChangeMatBehaviour>().ChangeBarProperty();

            else if (target.CompareTag("bar") && GameObject.Find("Destination").transform.childCount == 1 && GameObject.Find("Destination").transform.GetChild(0).CompareTag("torch"))
                if (target.GetComponent<Rigidbody>().mass < 10)
                    Destroy(target);

            if (target.CompareTag("box"))
                target.GetComponent<ChangeMatBehaviour>().ChangeBoxProperty();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (woodProgressBar.value < 0.7f)
                return;

            if (currentBallSelection == 0)
                currentBallSelection = 1;
            else
                currentBallSelection = 0;
        }    

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Select Wood");
            selectMat = MatEnum.WOOD;
            selectMass = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Select Metal");
            selectMat = MatEnum.METAL;
            selectMass = 50.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
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
        */

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

    // Helper function to check if its looking at an object
    private bool CheckSee()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Will contain the information of which object the raycast hit
        RaycastHit hit;
        
        // if raycast hits, it checks if it hit an object with the tag changable
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.gameObject.CompareTag("bar") || hit.collider.gameObject.CompareTag("box"))
            {
                if (target = hit.collider.gameObject)
                    return true;
                else
                    return false;
            }
        }

        //Debug.Log("Does not see anything");
        return false;
    }
}