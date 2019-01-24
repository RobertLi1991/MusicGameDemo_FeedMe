using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour {

    [SerializeField]
    private string m_SceneToLoadOnStartClick;
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(m_SceneToLoadOnStartClick);
    }
}
