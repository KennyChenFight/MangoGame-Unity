using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainIn : MonoBehaviour {
    public void StartGame1()
    {
        Application.LoadLevel(1);
    }
    public void StartGame2()
    {
        Application.LoadLevel(3);
    }
    public void StartGame3()
    {
        Application.LoadLevel(12);
    }
}
