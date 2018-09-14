using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject again;
    public int trueCount = 0;//正確次數
    public int Count = 0;//次數
    public int PostCount = 0;//翻開次數
    public float trueRate = 0;//正確率
    public Text TtrueRateData;//顯示正確率
    public Text TimeShow;//顯示時間
    float timer = 0f;//時間
    bool start_Time = false;//
    public int max1;

    //成績相關
    public GameObject ScoreObject;
    public Text ScoreShow;//顯示成績

    public float EXtrueRate = 0;//正確率
    public int FeedCount;//





    [Header("比對卡牌的清單")]
    public List<Card> cardComparison;



    [Header("卡牌種類清單")]
    public List<CardPattern> cardsToBePutIn;



    public Transform[] positions;

    [Header("已經成功配對卡牌的數量")]
    int matchedCardsCount=0;

	void Start () {
        again.SetActive(false);
        GenerateRandomCards();
        start_Time = true;
    }
    private void Update()
    {
        if (start_Time)
        {
            timer += Time.deltaTime;

        }

        TimeShow.text = "時間 :　" + timer.ToString("f2");
    }


    //------------------------------
    void SetupCardsToBePutIn()
    {
        Array array = Enum.GetValues(typeof(CardPattern));
        foreach(var item in array )
        {
            cardsToBePutIn.Add((CardPattern)item);
        }
        cardsToBePutIn.Remove(0);


    }

    //發出所有牌
    void GenerateRandomCards()
    {
        int positionIndex = 0;

        for (int i = 0; i<2;i++)
        {
        SetupCardsToBePutIn();
        //int max = cardsToBePutIn.Count;
        for (int j = 0; j<max1;max1--)
        {
            int randomNumber = UnityEngine.Random.Range(0, max1);//0 ~ max-1
            AddNewCards(cardsToBePutIn[randomNumber], positionIndex);//抽牌
            cardsToBePutIn.RemoveAt(randomNumber);
            positionIndex++;
        }
        }
        ///



    }


    void AddNewCards(CardPattern cardPattern,int positionIndex)
    {
        GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/card"));
        card.GetComponent<Card>().cardPattern = cardPattern;
        card.name = "card_" + cardPattern.ToString();
        card.transform.position = positions[positionIndex].position;

        GameObject CardGraph1 = Instantiate(Resources.Load<GameObject>("Prefabs/card1"));
        CardGraph1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CardGraph/"+cardPattern.ToString());


        CardGraph1.transform.SetParent(card.transform);//變反面(背牌)的子物件
        CardGraph1.transform.localPosition = new Vector3(0, 0, 0f);//設定座標
        CardGraph1.transform.eulerAngles = new Vector3(0, 180, 0);//順著Y軸轉

    }


    public void AddCardInCardComparison(Card card)
    {
        cardComparison.Add(card);
    }


    public bool ReadyToCompareCards
    {
        get
        {
            if (cardComparison.Count==2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public void CompareCardsInList()
    {
        if (ReadyToCompareCards)
        {
            Debug.Log("可以比對卡牌了");
            if (cardComparison[0].cardPattern==cardComparison[1].cardPattern)
            {
                Debug.Log("兩張牌一樣");
                PostCount++;
                trueCount++;

                foreach (var card in cardComparison)
                {
                    card.cardState = CardState.TrueRight;
                    Destroy(card);
                }
                ClearCardComparison();
                matchedCardsCount+=2;//配對成功數量+2(一組)
                if (matchedCardsCount >=positions.Length)
                {
                   StartCoroutine(ReloadScene());
                    start_Time = false;

                    Count = PlayerPrefs.GetInt("CardPostCount", Count)+1;
                    PlayerPrefs.SetInt("CardPostCount", Count);

                    trueRate =((float)(trueCount) / (float)PostCount)* 100;
                    PlayerPrefs.SetFloat("CardtrueRate", trueRate);

                    ScoreShow.text = PlayerPrefs.GetString("CardScore") + "第" + Count + "次:" + "  時間:" + timer.ToString("f2") + "  正確率:" + trueRate.ToString("f2") + "%" + "\n\n";
                    PlayerPrefs.SetString("CardScore", ScoreShow.text);

                    TtrueRateData.text = "正確率 : "+trueRate.ToString("f2") + " %";

                    if (PlayerPrefs.GetFloat("EXtrueRate1Card") <= (trueRate + 10))
                    {
                        FeedCount = PlayerPrefs.GetInt("FeedCount") + 1;
                        PlayerPrefs.SetInt("FeedCount", FeedCount);
                        Debug.Log(PlayerPrefs.GetInt("FeedCount"));
                    }
                    EXtrueRate = trueRate;
                    PlayerPrefs.SetFloat("EXtrueRate1Card", EXtrueRate);

                }


            }
            else
            {
                Debug.Log("兩張牌不一樣");
                StartCoroutine (MissMatchCards());
                PostCount++;
            }
        }
    }


    void ClearCardComparison()
    {
        cardComparison.Clear();
    }




    void TurnBackCards()
    {
        foreach(var card in cardComparison)
        {
            card.gameObject.transform.eulerAngles = Vector3.zero; // Vector3.zero = new Vector3(0,0,0)
            card.cardState = CardState.NotPick;
        }
    }


    //延遲翻回背面的時間
    IEnumerator MissMatchCards()
    {
        yield return new WaitForSeconds(1);
        TurnBackCards();
        ClearCardComparison();
    }

    //全部成功翻面
    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(0);
        again.SetActive(true);


    }


}
