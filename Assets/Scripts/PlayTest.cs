using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTest : MonoBehaviour
{

    public Transform m_note;
    public Transform m_myselfWa;

    public float m_goodFar = 0.5f;
    public float m_greatFar = 0.2f;

    private int m_stupidCunt = 0;

    public AudioSource m_voicej;
    public AudioSource m_voicek;
    public GameObject okhit;
    public GameObject goodhit;
    //private float closePictureTimeCount = 0f;
    // Robert Comment where is the sound resource
    private void Awake()
    {
        m_stupidCunt = 0;
        m_voicej.loop = false;
        m_voicek.loop = false;
    }

    public NPCTest1 m_npc;

    //// Use this for initialization
    //void Start()
    //{
    //}

    /// <summary>
    ///  0 eat, 1 no eat
    /// </summary>
    int hitWa = 3;//
    // Update is called once per frame
    void Update()
    {

        hitWa = 3;
        //Input.GetButtonDown()

        if (Input.GetKeyDown(KeyCode.J)) // eat
        {
            hitWa = 0;
            if (m_voicej.clip)
            {
                m_voicej.Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.K)) // no eat
        {
            hitWa = 1;
            if (m_voicek.clip)
            {
                m_voicek.Play();
            }
        }

        if (hitWa == 1 || hitWa == 0)
        {
            HitTest(hitWa);
        }
    }

    /// <summary>
    /// _eat  0 eat, 1 no eat
    /// </summary>
    /// <param name="_eat"></param>
    public void HitTest(int _eat)
    {

        if (!m_note)
        {
            //Debug.Log("No note");
            return;
        }

        //m_note.position.x
        float temp = Mathf.Abs(m_note.position.x - m_myselfWa.position.x);
        //Robert Comment if temp is larger than goodfar ,what will do
        if (temp < m_goodFar)
        {// up is just to varify the distance ,not the food type
            //Robert decide to delete if(_eat==1)sentence
            //if (_eat == 1)
            //{
            //    //no eat
            //    Destroy(m_note.gameObject);
            //    return;
            //}
            //？？？？？？？why
            m_stupidCunt++;
            int score;
            var foodtype = m_note.GetComponent<Food>();
            if (temp < m_greatFar || m_npc.IsSkilling())
            {//skill wrong:directly get great distance score
                score = 3;
                //m_npc.EatNote(3,);
                // score ++
            }
            else
            {
                score = 1;
                //m_npc.EatNote(1,);
                // score ++
            }
            if (foodtype)
            {

                if (foodtype.typeOfFood == m_npc.GetMissiontype() && _eat == 0)
                { m_npc.EatNote(score, true);
                    //if (_eat == 0)
                    if (score == 1)
                    {
                        ShowJudgementPicture(okhit);
                        Invoke("CloseOKPicture", 0.3F);
                    }
                    else if (score == 3)
                    {
                        ShowJudgementPicture(goodhit);
                        Invoke("CloseGoodPicture", 0.3F);
                    }
                }
                else if (foodtype.typeOfFood != m_npc.GetMissiontype() && _eat == 1)
                {
                    //if (_eat == 1)
                    m_npc.EatNote(score, false);
                    if (score == 1)
                    {
                        ShowJudgementPicture(okhit);
                        Invoke("CloseOKPicture", 0.3F);
                    }
                    else if (score == 3)
                    {
                        ShowJudgementPicture(goodhit);
                        Invoke("CloseGoodPicture", 0.3F);
                    }
                } 
            }
           
        }
        Destroy(m_note.gameObject);
        m_note = null;
    }
        private void OnTriggerEnter2D(Collider2D _other)
        {
            if (_other.tag == "Note")
                m_note = _other.transform;
        }
        private void ShowJudgementPicture(GameObject picture)
        {
            picture.GetComponent<SpriteRenderer>().enabled = true;

        }
        private void CloseOKPicture()
        {
            okhit.GetComponent<SpriteRenderer>().enabled = false;
        }
        private void CloseGoodPicture()
        {
            goodhit.GetComponent<SpriteRenderer>().enabled = false;
        }

    
} 
    //private void OnMouseDown()
    //{
    //	//player click?
    //	HitTest();
    //}

    //private void OnTriggerExit2D(Collider2D _other)
    //{
    //    if (m_note)
    //    {
    //        if (_other != m_note.GetComponent<CircleCollider2D>())
    //        {
    //            Debug.Log("Miss la");
    //        }
    //        else
    //        {
    //            // note miss
    //            Debug.Log("Miss la");
    //            m_note = null;
    //        }
    //    }

    //}

    // class end

