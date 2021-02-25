using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip changeMat, burning;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        changeMat = Resources.Load<AudioClip>("MatChange");
        burning = Resources.Load<AudioClip>("FireBurn");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "MatChange":
                audioSrc.PlayOneShot(changeMat);
                break;
            case "FireBurn":
                audioSrc.PlayOneShot(burning);
                break;
        }
    }
}
