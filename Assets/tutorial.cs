using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public static float tutorialOpenFlag = 1f;
    public static float readFlag = -1f;
    public AudioSource bgm;
    // Use this for initialization
    void Start()
    {
        GameObject closepicture = transform.Find("close").gameObject;
        if (readFlag == 1f)
        {
            CloseTutorial();
            
        }
    }

    // Update is called once per frame

    public void CloseTutorial()
    {   bgm.Play();
        Destroy(gameObject);
        tutorialOpenFlag = -1f;
        readFlag = 1f;
        
    }
}

