using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitScoree : MonoBehaviour {
    public GameObject panelMain;
    public GameObject panelSCORE;
    public void OnBtnShowClickMain()
    {
        panelMain.SetActive(true);
        panelSCORE.SetActive(false);

    }

    public void OnBtnShowClickSCORE()
    {
        panelMain.SetActive(false);
        panelSCORE.SetActive(true);

    }

    //-------------------------------------------------------
    public Text Score;

    public void Delte()
    {
        PlayerPrefs.DeleteKey(key: "trueRateScore1");
        PlayerPrefs.DeleteKey(key: "trueRateScore2");
        PlayerPrefs.DeleteKey(key: "trueRateScore3");
        PlayerPrefs.DeleteKey(key: "trueRateScore4");
        PlayerPrefs.DeleteKey(key: "trueRateScore5");
        PlayerPrefs.DeleteKey(key: "trueRateScore6");
        PlayerPrefs.DeleteKey(key: "trueRateScore7");
        PlayerPrefs.DeleteKey(key: "EXtrueRate1");
        PlayerPrefs.DeleteKey(key: "EXtrueRate2");
        PlayerPrefs.DeleteKey(key: "EXtrueRate3");
        PlayerPrefs.DeleteKey(key: "EXtrueRate4");
        PlayerPrefs.DeleteKey(key: "EXtrueRate5");
        PlayerPrefs.DeleteKey(key: "EXtrueRate6");
        PlayerPrefs.DeleteKey(key: "EXtrueRate7");
        Score.text = "\n" + PlayerPrefs.GetString("trueRateScore1") + PlayerPrefs.GetString("trueRateScore2") + PlayerPrefs.GetString("trueRateScore3") + PlayerPrefs.GetString("trueRateScore4") + PlayerPrefs.GetString("trueRateScore5") + PlayerPrefs.GetString("trueRateScore6") + PlayerPrefs.GetString("trueRateScore7");
}

    public void ShowScore()
    {
        Score.text = "\n" + PlayerPrefs.GetString("trueRateScore1")+ PlayerPrefs.GetString("trueRateScore2") + PlayerPrefs.GetString("trueRateScore3") + PlayerPrefs.GetString("trueRateScore4") + PlayerPrefs.GetString("trueRateScore5") + PlayerPrefs.GetString("trueRateScore6") + PlayerPrefs.GetString("trueRateScore7");
    }




}
