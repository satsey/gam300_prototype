using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Slider woodProgressBar;

    // Materials
    // Wood
    public Material mat1;
    public float mass1 = 1;
    //Metal
    public Material mat2;
    public float mass2 = 10;

    // Selected material
    public Material selectMat;
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
        selectMat = mat1;
        selectMass = mass1;
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
          string name = target.name.Substring(0,7);

          if (target.CompareTag("bar"))
            for (int i = 0; i < target.transform.childCount; ++i)
              target.transform.GetChild(i).GetComponent<ChangeMatBehaviour>().ChangeProperty();

          if (target.CompareTag("box"))
            target.GetComponent<ChangeMatBehaviour>().ChangeProperty();
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
            selectMat = mat1;
            selectMass = mass1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Select Metal");
            selectMat = mat2;
            selectMass = mass2;
        }
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
                Debug.Log(hit.collider.gameObject.name);
                if (target = hit.collider.gameObject)
                    return true;
                else
                    return false;
            }
        }

        Debug.Log("Does not see anything");
        return false;
    }
}
