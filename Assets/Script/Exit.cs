using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public void GameQuit()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        Application.LoadLevel(0);
        //Application.Quit();
    }
    public void StartGame1()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score"); 
        PlayerPrefs.DeleteKey(key: "trueCount");
        Application.LoadLevel(4);
        //Application.LoadLevel(1);
    }
    public void StartGame2()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        Application.LoadLevel(5);
        //Application.LoadLevel(2);
    }
    public void StartGame3()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        //Application.LoadLevel(3);
        Application.LoadLevel(6);
    }
    public void StartGame4()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        //Application.LoadLevel(4);
        Application.LoadLevel(7);
    }
    public void StartGame5()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        //Application.LoadLevel(5);
        Application.LoadLevel(8);
    }
    public void StartGame6()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        //Application.LoadLevel(6);
        Application.LoadLevel(9);
    }
    public void StartGame7()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        //Application.LoadLevel(7);
        Application.LoadLevel(10);
    }
    public void StartMain()
    {
        PlayerPrefs.DeleteKey(key: "PostCount");
        PlayerPrefs.DeleteKey(key: "trueRate");
        PlayerPrefs.DeleteKey(key: "Score");
        PlayerPrefs.DeleteKey(key: "trueCount");
        //Application.LoadLevel(0);
        Application.LoadLevel(3);
    }


}
