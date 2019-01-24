using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passlevelmenu : MonoBehaviour {

    public  GameObject passlevelMenu;
    public GameObject NPCTest;
    public Image starpicture;
    public Image failpicture;
    public Text scoretext;
    public Text WinOrFail;
 
    public void ShowPassLevelMenu()
    {
        
        //passlevelMenu.SetActive(true);
        showstar(NPCTest.GetComponent<NPCTest1>().GetScore());
        showscore(NPCTest.GetComponent<NPCTest1>().GetScore());
    }
    private void ShowFail()
    {
        WinOrFail.text = "You Failed!";
        failpicture.enabled = true;
    }
    public void BacktoStartMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnRestart()
    {
       SceneManager.LoadScene("SampleScene01");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void showstar(int score)
    {
        if(score < 20)
        {
            starpicture.fillAmount = 0;
            this.ShowFail();
        }
        if (score >= 20 && score < 30)
        {
            starpicture.fillAmount = 0.33f;
        }
        if (score >= 30 && score < 60)
        {
            starpicture.fillAmount = 0.67f;
        }
        if (score >= 60)
        {
            starpicture.fillAmount = 1;
        }
        

    }
    public void showscore(int score)
    {
        scoretext.text = "Score:" + score;
    }
}
