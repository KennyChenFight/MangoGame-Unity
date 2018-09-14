using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIn : MonoBehaviour {

    public void StartMain()
    {
        Application.LoadLevel(1);
    }
    public void StartGame()
    {
        Application.LoadLevel(2);
    }
    public void StartGame0()
    {
        Application.LoadLevel(15);
    }
    public void StartGame1()
    {
        Application.LoadLevel(16);
    }
    public void ComeMain()
    {
        Application.LoadLevel(0);
    }
}
