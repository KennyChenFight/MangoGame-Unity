using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public CardState cardState;
    public CardPattern cardPattern;
    public GameManager gameManager;

    // Use this for initialization
    void Start () {
       cardState = CardState.NotPick;
       gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


    }


    //滑鼠按下放開後
    private void OnMouseUp()
    {
        //第一個翻開的牌不會再直接可翻...得選擇另一張不同的牌
        if (cardState.Equals(CardState.YetPick))
        {
            return;//後面都不會被執行
        }
        //當已經翻開兩張牌...進行判斷...不給予機會在此期間翻開第三張牌
        if (gameManager.ReadyToCompareCards)
        {
            return;//後面都不會被執行
        }

        OpenCard();//run OpenCard
        gameManager.AddCardInCardComparison(this);
        gameManager.CompareCardsInList();
    }
    
    void OpenCard()
    {
        transform.eulerAngles = new Vector3(0,180,0);
        cardState = CardState.YetPick;
    }

}

public enum CardState
{
    NotPick,YetPick,TrueRight//未翻.已翻.配對完成
}
public enum CardPattern
{
    NoPet,Pet1, Pet2, Pet3, Pet4, Pet5, Pet6, Pet7,Pet8//牌的類型
}
