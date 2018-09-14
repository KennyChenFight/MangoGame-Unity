using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScore : MonoBehaviour {

    public Text Score;

    public void Delte()
    {
        PlayerPrefs.DeleteKey(key: "CardPostCount");
        PlayerPrefs.DeleteKey(key: "CardtrueRate");
        PlayerPrefs.DeleteKey(key: "CardScore");
        PlayerPrefs.DeleteKey(key: "EXtrueRate1Card");
        Score.text = "\n" + PlayerPrefs.GetString("CardScore");

    }

    public void ShowScore()
    {
        Score.text = "\n"+PlayerPrefs.GetString("CardScore");
    }






}
