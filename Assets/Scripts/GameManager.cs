using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject Passlevel;
    public float pauseFlag = -1;
    
    private void Awake()
    {
        GameManager.instance = this;
        
    }
    
	// Use this for initialization
	void Start () {
        if (tutorial.readFlag == 1)
        {
            GameObject.Find("No title").GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update () {

        //Debug.Log(tutorial.readFlag);
            if ( !GameObject.Find("No title").GetComponent<AudioSource>().isPlaying&& this.pauseFlag != 1&& tutorial.readFlag == 1)
        {
            Passlevel.SetActive(true);
            Passlevel.GetComponent<Passlevelmenu>().ShowPassLevelMenu();
        }
            
	}
    
}
