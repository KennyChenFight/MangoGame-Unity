using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCCard : MonoBehaviour {
    public GameObject ScoreObject;

    //關閉查看成績欄位
    public void CloseScore()
    {
        ScoreObject.SetActive(false);
    }
    //開啟查看成績欄位
    public void OpenScore()
    {
        ScoreObject.SetActive(true);
    }
}
