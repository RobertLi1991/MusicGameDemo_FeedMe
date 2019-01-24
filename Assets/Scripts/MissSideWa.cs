using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissSideWa : MonoBehaviour
{
    public AudioSource m_missVoice;
    public SpriteRenderer misspicture1;
    private void Awake()
    {

        m_missVoice.loop = false;
       
      
    }
    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.tag == "Note")
        {
            m_missVoice.Play();
            misspicture1.enabled = true;
            Invoke("DisableMissPicture", 0.2f);
            //Debug.Log("Miss la");
            Destroy(_other.gameObject, 1.0f);
        }
    }
    private void DisableMissPicture()
    {
        misspicture1.enabled = false;
    }

    // class end
}
