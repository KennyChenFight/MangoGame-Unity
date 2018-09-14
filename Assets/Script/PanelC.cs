using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelC : MonoBehaviour {
    public GameObject cont;
    public GameObject reset;
    public GameObject exit;
    public Text score;
    int s = 0;



    //-----------------------------------------------------------
    //切換panel
    public void OnBtnCloseClickSet()
    {//遊戲中按下設定
        cont.SetActive(true);
        reset.SetActive(true);
        exit.SetActive(true);


    }
    public void OnBtnCloseClickCon()
    {//繼續遊戲
        cont.SetActive(false);
        reset.SetActive(false);
        exit.SetActive(false);



    }
    public void OnBtnresetClick()
    {//重來一次
        cont.SetActive(false);
        reset.SetActive(false);
        exit.SetActive(false);

        gameObject.SetActive(false);

        score.text = s + "";


    }


    public void OnBtnCloseClick()
    {//關閉遊戲
        gameObject.SetActive(true);

        gameObject.SetActive(false);
        cont.SetActive(false);
        reset.SetActive(false);
        exit.SetActive(false);
 
        s = 0;
        score.text = s + "";



    }
}
