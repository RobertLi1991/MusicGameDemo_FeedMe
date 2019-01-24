using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour {

    public GameObject ingameMenu;
    public AudioSource music;

    public void OnPause()//点击“暂停”时执行此方法
    {
        GameManager.instance.pauseFlag = 1;
        ingameMenu.SetActive(true);
        Time.timeScale = 0;
        music.Pause();
    }

    public void OnResume()//点击“回到游戏”时执行此方法
    {
        ingameMenu.SetActive(false);
        GameManager.instance.pauseFlag = -1;
        Time.timeScale = 1;
        music.Play();
    }
    public void BacktoStartMenu()
    {
       SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
    public void OnRestart()//点击“重新开始”时执行此方法
    {
     
      SceneManager.LoadScene("SampleScene01");
        Time.timeScale = 1;

    }
    public void OnQuest()//点击“重新开始”时执行此方法
    {

        Application.Quit();
    }

}
