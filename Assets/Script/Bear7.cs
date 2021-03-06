﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bear7 : MonoBehaviour {
    //float startTime = Time.time;//計時時間

    public GameObject[] pet = new GameObject[9];//點擊物件
    public GameObject[] PetImage = new GameObject[9];//物件
    public GameObject PetImageObject;

    //成績相關
    public GameObject ScoreObject;
    public Text ScoreShow;//顯示成績


    //題目
    int ans1;
    int ans2;
    int ans3;
    int ans4;
    int ans5;
    int ans6;
    int ans7;
    int ans8;

    //使用者答案
    int res1;
    int res2;
    int res3;
    int res4;
    int res5;
    int res6;
    int res7;
    int res8;

    public int clickCount = 0;//已點擊按鈕數量
    public Text TF;//正確或錯誤
    public GameObject Next;//下一關按鈕

    public int trueCount = 0;//正確次數
    public int PostCount = 0;//闖關次數
    public float trueRate = 0;//正確率
    public Text TtrueRateData;//顯示正確率
    public Text TimeShow;//顯示時間
    float timer = 0f;//時間
    bool start_Time = false;//
    public float EXtrueRate = 0;//正確率
    public int FeedCount;//



    public Button Button, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8;

    public GameObject DesButton;//說明按下鈕
    public Text Chat;//說明顯示
    public GameObject Chat1;//說明顯示
    public GameObject DesButton1;//說明顯示1

    string scoreOpen;



    private void Start()
    {
        //隨機選取按鈕位置
        ans1 = Random.Range(0, 8);
        while (ans2 == ans1)
        {
            ans2 = Random.Range(0, 8);
        }
        while (ans3 == ans1 || ans3 == ans2)
        {
            ans3 = Random.Range(0, 8);
        }
        while (ans4 == ans1 || ans4 == ans2 || ans4 == ans3)
        {
            ans4 = Random.Range(0, 8);
        }
        while (ans5 == ans1 || ans5 == ans2 || ans5 == ans3 || ans5 == ans4)
        {
            ans5 = Random.Range(0, 8);
        }
        while (ans6 == ans1 || ans6 == ans2 || ans6 == ans3 || ans6 == ans4 || ans6 == ans5)
        {
            ans6 = Random.Range(0, 8);
        }
        while (ans7 == ans1 || ans7 == ans2 || ans7 == ans3 || ans7 == ans4 || ans7 == ans5 || ans7 == ans6)
        {
            ans7 = Random.Range(0, 8);
        }
        while (ans8== ans1 || ans8 == ans2 || ans8 == ans3 || ans8== ans4 || ans8 == ans5 || ans8 == ans6 || ans8 == ans7)
        {
            ans8 = Random.Range(0, 8);
        }

        Debug.Log("(1)" + ans1 + " (2)" + ans2 + " (3)" + ans3 + " (4)" + ans4 + " (5)" + ans5 + " (6)" + ans6 + " (7)" + ans7 + " (8)" + ans8);

        StartCoroutine(Des());//說明開始
    }

    private void Update()
    {
        if (start_Time)
        {
            timer += Time.deltaTime;

        }
        TtrueRateData.text = "正確率 : " + PlayerPrefs.GetFloat("trueRate").ToString("f2") + " %";
        TimeShow.text = "時間 :　" + timer.ToString("f2");
    }

    public void TORF()
    {
        if (ans1 == res1 && ans2 == res2 && ans3 == res3 && ans4 == res4 && ans5 == res5 && ans6 == res6 && ans7 == res7 && ans8 == res8)
        {

            Debug.Log("正確");
            TF.text = "答對了";
            PostCount = PlayerPrefs.GetInt("PostCount") + 1;
            trueCount = PlayerPrefs.GetInt("trueCount") + 1;
            PlayerPrefs.SetInt("PostCount", PostCount);
            PlayerPrefs.SetInt("trueCount", trueCount);
            ScoreShow.text = PlayerPrefs.GetString("Score") + "關卡" + PostCount + " : " + "花費時間 : " + timer.ToString("f2") + "  " + TF.text + "\n\n";
            PlayerPrefs.SetString("Score", ScoreShow.text);


            trueRate = (((float)PlayerPrefs.GetInt("trueCount")) / ((float)PlayerPrefs.GetInt("PostCount"))) * 100;
            PlayerPrefs.SetFloat("trueRate", trueRate);


        }
        else
        {
            Debug.Log("錯誤");
            TF.text = "答錯了";
            PostCount = PlayerPrefs.GetInt("PostCount") + 1;
            PlayerPrefs.SetInt("PostCount", PostCount);
            ScoreShow.text = PlayerPrefs.GetString("Score") + "關卡" + PostCount + " : " + "花費時間 : " + timer.ToString("f2") + "  " + TF.text + "\n\n";
            PlayerPrefs.SetString("Score", ScoreShow.text);

            trueRate = (((float)PlayerPrefs.GetInt("trueCount")) / ((float)PlayerPrefs.GetInt("PostCount"))) * 100;
            PlayerPrefs.SetFloat("trueRate", trueRate);


        }
        if (PlayerPrefs.GetInt("PostCount") < 10)
        {
            Next.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PostCount") >= 10)
        {
            scoreOpen += PlayerPrefs.GetString("trueRateScore7") + "Level 7:　 正確率:" + trueRate + "%" + "\n\n";
            PlayerPrefs.SetString("trueRateScore7", scoreOpen);
            if (PlayerPrefs.GetFloat("EXtrueRate7") <= (trueRate + 10))
            {
                FeedCount = PlayerPrefs.GetInt("FeedCount") + 7;
                PlayerPrefs.SetInt("FeedCount", FeedCount);
                Debug.Log(PlayerPrefs.GetInt("FeedCount"));
            }
            EXtrueRate = trueRate;
            PlayerPrefs.SetFloat("EXtrueRate7", EXtrueRate);
        }

    }

    public void NextPost()
    {
        StartCoroutine(ReloadScene());
    }

    public void Score()
    {
        ScoreObject.SetActive(true);

    }

    public void CloseScore()
    {
        ScoreObject.SetActive(false);
    }

    //-------------------------------------------------------------
    //0
    public void set0()
    {
        if (clickCount == 0)
        {
            res1 = 0;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 0;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 0;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 0;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 0;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 0;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 0;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 0;
            clickCount++;
            TORF();
        }
    }
    //1
    public void set1()
    {
        if (clickCount == 0)
        {
            res1 = 1;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 1;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 1;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 1;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 1;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 1;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 1;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 1;
            clickCount++;
            TORF();
        }
    }
    //2
    public void set2()
    {
        if (clickCount == 0)
        {
            res1 = 2;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 2;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 2;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 2;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 2;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 2;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 2;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 2;
            clickCount++;
            TORF();
        }
    }
    //3
    public void set3()
    {
        if (clickCount == 0)
        {
            res1 = 3;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 3;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 3;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 3;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 3;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 3;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 3;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 3;
            clickCount++;
            TORF();
        }
    }
    //4
    public void set4()
    {
        if (clickCount == 0)
        {
            res1 = 4;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 4;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 4;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 4;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 4;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 4;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 4;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 4;
            clickCount++;
            TORF();
        }
    }
    //5
    public void set5()
    {
        if (clickCount == 0)
        {
            res1 = 5;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 5;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 5;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 5;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 5;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 5;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 5;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 5;
            clickCount++;
            TORF();
        }
    }
    //6
    public void set6()
    {
        if (clickCount == 0)
        {
            res1 = 6;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 6;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 6;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 6;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 6;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 6;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 6;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 6;
            clickCount++;
            TORF();
        }
    }
    //7
    public void set7()
    {
        if (clickCount == 0)
        {
            res1 = 7;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 7;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 7;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 7;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 7;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 7;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 7;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 7;
            clickCount++;
            TORF();
        }
    }
    //8
    public void set8()
    {
        if (clickCount == 0)
        {
            res1 = 8;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            res2 = 8;
            clickCount++;
        }
        else if (clickCount == 2)
        {
            res3 = 8;
            clickCount++;
        }
        else if (clickCount == 3)
        {
            res4 = 8;
            clickCount++;
        }
        else if (clickCount == 4)
        {
            res5 = 8;
            clickCount++;
        }
        else if (clickCount == 5)
        {
            res6 = 8;
            clickCount++;
        }
        else if (clickCount == 6)
        {
            res7 = 8;
            clickCount++;
        }
        else if (clickCount == 7)
        {
            start_Time = false;
            res8 = 8;
            clickCount++;
            TORF();
        }
    }

    public void StopDes()
    {
        DesButton.SetActive(false);
        Chat1.SetActive(false);
        Chat.text = "";
        StartCoroutine(aa1());//第一轉
        StartCoroutine(StopSomeTime());//第二轉

    }

    public void StopDes1()
    {
        DesButton1.SetActive(false);
        Chat1.SetActive(false);
        Chat.text = "";
        StartCoroutine(OpenButton());
        start_Time = true;

    }
    //-------------------------------------------------------------
    //說明
    IEnumerator Des()
    {

        DesButton.SetActive(true);
        DesButton1.SetActive(false);
        Chat1.SetActive(true);
        PetImageObject.SetActive(true);
        yield return new WaitForSeconds(0f);
        Chat.text = "螢幕上有九隻小熊，請你仔細看，有些小熊會動，有些小熊不會動。請你記得是哪些小熊在動，然後，請依照小熊動的順序依序點出來。(點下右邊按鈕後開始)";

    }

    //-------------------------------------------------------------


    //---------------------------------------------------
    IEnumerator aa1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans1].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(aa2());
    }
    IEnumerator aa2()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans1].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(aa3());
    }
    IEnumerator aa3()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans1].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(aa4());
    }
    IEnumerator aa4()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans1].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
    }
    //------------------------------------------------
    IEnumerator bb1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans2].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(bb2());
    }
    IEnumerator bb2()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans2].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(bb3());
    }
    IEnumerator bb3()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans2].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(bb4());
    }
    IEnumerator bb4()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans2].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(StopSomeTime1());
    }
    //-----------------------------------------------------
    //------------------------------------------------
    /*IEnumerator cc1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans3].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(cc2());
    }
    IEnumerator cc2()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans3].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(cc3());
    }
    IEnumerator cc3()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans3].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(cc4());
    }*/
    IEnumerator cc4()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans3].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans3].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans3].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans3].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(StopSomeTime2());
    }
    //-----------------------------------------------------

    //------------------------------------------------
    IEnumerator dd1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans4].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(dd2());
    }
    IEnumerator dd2()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans4].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(dd3());
    }
    IEnumerator dd3()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans4].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(dd4());
    }
    IEnumerator dd4()
    {
        yield return new WaitForSeconds(0.1f);
        PetImage[ans4].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(StopSomeTime3());
    }
    //-----------------------------------------------------
    IEnumerator ee1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans5].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans5].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans5].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans5].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(StopSomeTime4());
    }
    //-----------------------------------------------------
    //-----------------------------------------------------
    IEnumerator ff1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans6].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans6].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans6].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans6].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(StopSomeTime5());
    }
    //-----------------------------------------------------
    //-----------------------------------------------------
    IEnumerator gg1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans7].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans7].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans7].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans7].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(StopSomeTime6());
    }
    //-----------------------------------------------------
    //-----------------------------------------------------
    IEnumerator hh1()
    {
        yield return new WaitForSeconds(1f);
        PetImage[ans8].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans8].transform.localScale += new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans8].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        yield return new WaitForSeconds(0.1f);
        PetImage[ans8].transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        StartCoroutine(DesOpenButton());
    }
    //-----------------------------------------------------

    IEnumerator DesOpenButton()
    {
        yield return new WaitForSeconds(0f);
        DesButton1.SetActive(true);
        Chat1.SetActive(true);
        Chat.text = "點下右邊按鈕後開始";

    }
    //-----------------------------------------------------
    //開始可以按
    IEnumerator OpenButton()
    {
        yield return new WaitForSeconds(0f);
        PetImageObject.SetActive(false);
        Button.interactable = true;
        Button1.interactable = true;
        Button2.interactable = true;
        Button3.interactable = true;
        Button4.interactable = true;
        Button5.interactable = true;
        Button6.interactable = true;
        Button7.interactable = true;
        Button8.interactable = true;
    }

    //-----------------------------------------------------

    //----------------------------------------------------

    //-----------------------------------------------------
    IEnumerator StopSomeTime()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(bb1());
    }

    //-----------------------------------------------------
    IEnumerator StopSomeTime1()
    {
        yield return new WaitForSeconds(0f);
        StartCoroutine(cc4());
    }
    //----------------------------------------------------
    //-----------------------------------------------------
    IEnumerator StopSomeTime2()
    {
        yield return new WaitForSeconds(0f);
        StartCoroutine(dd1());
    }
    //----------------------------------------------------
    //-----------------------------------------------------
    IEnumerator StopSomeTime3()
    {
        yield return new WaitForSeconds(0f);
        StartCoroutine(ee1());
    }
    //----------------------------------------------------
    //-----------------------------------------------------
    IEnumerator StopSomeTime4()
    {
        yield return new WaitForSeconds(0f);
        StartCoroutine(ff1());
    }
    //----------------------------------------------------
    IEnumerator StopSomeTime5()
    {
        yield return new WaitForSeconds(0f);
        StartCoroutine(gg1());
    }
    //----------------------------------------------------
    IEnumerator StopSomeTime6()
    {
        yield return new WaitForSeconds(0f);
        StartCoroutine(hh1());
    }
    //----------------------------------------------------
    //----------------------------------------------------
    //NEXT
    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Next.SetActive(false);
    }
    //----------------------------------------------------

}