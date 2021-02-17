using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Text mat_Text;
    public Image mat_img;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().selectMat == PlayerController.MatEnum.WOOD)
        {
            mat_img.color = new Color32(200, 100, 0, 255);
            //Debug.Log(mat_img.color.ToString());
            mat_Text.text = PlayerController.MatEnum.WOOD.ToString();
            mat_Text.color = mat_img.color;
        }
        else if (player.GetComponent<PlayerController>().selectMat == PlayerController.MatEnum.METAL)
        {
            mat_img.color = new Color32(133, 133, 133,255);
           // Debug.Log(mat_img.color.ToString());
            mat_Text.text = PlayerController.MatEnum.METAL.ToString();
            mat_Text.color = mat_img.color;
        }
    }
}
