using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class NPCTest1 : MonoBehaviour
{

    public Text m_scoreTextm_scoreText;
    public Text m_mpText;

    //public Action OnMpUp;
    private int m_xp;
    private int m_mp;
    public int m_fullMp;
    System.Random m_rd;
    const int types = 2;

    //public float m_skillCDTime = 10.0f;
    public float m_lastSkillEndTime = 5.0f;
    public float m_skillLastingTime = 5.0f;
    private float m_skillTimeNow = 0.0f;
    private bool m_skilling = false;
    public float m_skillEvoLastTime = 3.0f;

    public float m_missionCDtime = 5.0f;
    public float m_missionLastTime = 5.0f;

    public Sprite[] m_picArr;
    public SpriteRenderer m_mission;
    private int m_missionType = 0;

    //public AudioClip m_voice;
    private int[] m_fakemissionWa = { 0, 3, 7, 14, 15, 25, 27, 31, 32, 35, 36, 43 };
    private int m_fakeI = 0;

    public GameObject Evoed;
    public SpriteRenderer aimPic;

    private void Awake()
    {
        m_xp = 0;
        m_mp = 0;
        m_skillTimeNow = 0.0f;
        m_skilling = false;
    }

    void Update()
    {
        CheckSkillState();
        //Debug.Log("missiontype=" + m_missionType);
        if (m_fakeI<=11&&Spawner.instance.foodCount == m_fakemissionWa[m_fakeI])
        {//Robert Comments:change the food request according to the spawner order
           
            SetMission(Spawner.instance.currentFood);
            m_fakeI++;
        }

        m_scoreTextm_scoreText.text = "Score: " + m_xp.ToString();
        m_mpText.text = "MP: " + m_mp.ToString();
        if(m_skilling)
        {
            m_mp = 5;
        }
        //if (IsSkilling())
        //{
        //	m_skillTimeNow += Time.deltaTime;
        //	if (m_skillTimeNow >= m_skillLastingTime)
        //	{
        //		// 技能结束
        //		m_skilling = false;
        //		m_lastSkillEndTime = Time.time;
        //		Debug.Log("skill off time: "+Time.time.ToString());
        //		//Debug.Log("skill off la");
        //	}
        //}

    }


    void CheckSkillState()
    {
        if (IsSkilling())
        {
            m_skillTimeNow += Time.deltaTime;
            if (m_skillTimeNow >= m_skillLastingTime)
            {
                // 技能结束
             
                m_skilling = false;
                m_mp = 0;
                aimPic.color = new Color(255, 255, 255, 255);
                Evoed.SetActive(false);
                m_lastSkillEndTime = Time.time;
            }
        }
        else
            return;
    }


    public void SetMission(int _type)
    {
        //foreach (var obj in m_missionObj)
        //{
        //	obj.SetActive(false);
        //}
        m_mission.sprite = m_picArr[_type];
        //
        m_missionType = _type;
        // 通知打歌判定？


    }


    /// <summary>
    /// 每次击打时调用
    /// </summary>
    /// <param name="_xp"></param>
    /// <param name="_correct"></param>
    public void EatNote(int _xp, bool _correct) // int _xp,
    {
        //int _xp = 1;
        //robert question: can it just directly add?
        m_xp += _xp;
        m_mp++;
        if (IsSkilling())
            return;

        //if (_correct)
        /*{*///correct parameter is just varify the food node is the same with food hint table
        //    m_mp++;
        //    Debug.Log("eat correct la");
        //}
        if (m_mp >= m_fullMp)
        {
            // release skill?
            //m_mp = 0;
            SkillTest();
        }


    }


    public void SkillTest()
    {
        // 判定加强
        if (m_skilling)
            return;
        aimPic.color = new Color((255f/255f), (245f/255f), (0f/255f), (255f/255f));
       
        Evoed.SetActive(true);
        m_skilling = true;
        m_skillTimeNow = 0.0f;

        // sss

    }


    public void EvoTest()
    {
        // CD时间--
        //m_skillCDTime--;
        //持续时间++
        //m_skillLastingTime += m_skillEvoLastTime;

        // NPC变化？ 发出欢呼？

    }


    /// <summary>
    /// 是否正在发动技能
    /// </summary>
    /// <returns></returns>
    public bool IsSkilling()
    {
        return m_skilling;
    }

    public int GetMissiontype()
    {
        return m_missionType;
    }

    public int Getm_fakeI()
    {
        return m_fakeI;
    }
    public int GetScore()
    {
        return m_xp;
    }
    // class end
}
