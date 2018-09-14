using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class aDefine
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Stop
    }
}

public class FoodManager : MonoBehaviour
{
    //紀錄手指觸碰位置
    private Vector2 m_screenPos = new Vector2();


    static int MAX_COUNT = 33;
    public GameObject[] foodList = new GameObject[MAX_COUNT];
    public GameObject leftButton, rightButton;
    int currentIndex = 17;
    int previousIndex = 17;

    string YN = "no";//判斷是否曾經送出食物以回復下一個食物物件位置
    string BO = "no";//判斷是否按下食物並送出了
    string MO = "no";//判斷GetMouseButtonDown被按下
    int countButtonOnClick = 0;//限制推出一次而已

    int Feedcount;//限制推出一次而已


    public GameObject Pet;
    public Image hpBar;
    //最大生命值
    public float MaxHp = 100;
    //當前生命值
    private float nowHP;

    public Text ChatText;
    public GameObject chat;
    public Text ChatText1;
    public GameObject chat1;

    public Text EatorNot;
    public GameObject food1;
    public GameObject pan;

    public int i = 0;//控制最大最小寵物大小



    // Use this for initialization
    void Start()
    {
        //nowHP = 100;
        nowHP = PlayerPrefs.GetFloat("FeedTime");
            PlayerPrefs.SetFloat("FeedTime", nowHP);
        Debug.Log(PlayerPrefs.GetFloat("FeedTime"));

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        MouseInput();   // 滑鼠偵測
#elif UNITY_ANDROID
		MobileInput();  // 觸碰偵測
#endif
        
        if (nowHP<=100 && nowHP>0)
        {
            
            nowHP -= Time.deltaTime *1; //每秒扣* HP
            PlayerPrefs.SetFloat("FeedTime", nowHP);

            if (nowHP <= 100 && nowHP >= 95)
            {
                Pet.transform.localScale = new Vector3(390f, 390f, 390f);
                chat1.SetActive(false);
                chat.SetActive(false);
            }
            else if (nowHP < 95 && nowHP >= 90)
            {
                Pet.transform.localScale = new Vector3(380f, 380f, 380f);
                chat.SetActive(true);
                ChatText.text = "主人~~\n我有點嘴饞了\n有零食吃嗎?";
            }
            else if (nowHP < 90 && nowHP >= 80)
            {
                chat.SetActive(false);
                Pet.transform.localScale = new Vector3(370f, 370f, 370f);
                if (nowHP < 90 && nowHP >= 85)
                {
                    chat.SetActive(true);
                    ChatText.text = "主人~~\n我有點餓了";
                }
              
            }

            else if (nowHP < 80 && nowHP >= 60)
            {
                chat.SetActive(false);
                Pet.transform.localScale = new Vector3(350f, 350f, 350f);
                if (nowHP < 80 && nowHP >= 70)
                {
                    chat.SetActive(true);
                    ChatText.text = "主人~~\n你忘記我了嗎?";
                }
                    
            }
            else if (nowHP < 60 && nowHP >= 50)
            {
                Pet.transform.localScale = new Vector3(300f, 330f, 330f);
                chat.SetActive(false);
                if (nowHP < 60 && nowHP >= 55)
                {
                    chat.SetActive(true);
                    ChatText.text = "本喵餓到吃手手了\n╮(╯▽╰)╭";
                }

                    
            }

            else if (nowHP < 50 && nowHP >= 40)
            {
                chat.SetActive(false);
                Pet.transform.localScale = new Vector3(250f, 300f, 300f);
                if (nowHP < 50 && nowHP >= 45)
                {
                    chat.SetActive(true);
                    ChatText.text = "唉~~\n人生好難";
                }

            }
            else if (nowHP < 40 && nowHP >= 30)
            {
                chat.SetActive(false);
                Pet.transform.localScale = new Vector3(200f, 250f, 250f);
                if (nowHP < 40 && nowHP >= 35)
                {
                    chat.SetActive(true);
                    ChatText.text = "有誰能明白本喵肚子餓的痛苦(〒︿〒)";
                }

            }

            else if (nowHP < 30 && nowHP >= 20)
            {
                chat.SetActive(false);
                Pet.transform.localScale = new Vector3(190f, 240f, 240f);
                if (nowHP < 30 && nowHP >= 25)
                {
                    chat.SetActive(true);
                    ChatText.text = "主人~~\n再沒食物我要離家\n出走去覓食了哦";
                }

            }
            else if (nowHP < 20 && nowHP >= 10)
            {
                chat.SetActive(false);
                Pet.transform.localScale = new Vector3(180f, 230f, 230f);
                if (nowHP < 20 && nowHP > 15)
                {
                    chat.SetActive(true);
                    ChatText.text = "沒關係~~\n我真的沒有哭";
                }

            }
            else if (nowHP < 10 && nowHP > 0)
            {
                chat.SetActive(false);
                Pet.transform.localScale = new Vector3(150f, 200f, 200f);
                if (nowHP < 5 && nowHP > 0)
                {
                    chat.SetActive(true);
                    ChatText.text = "我大概是金氏世界紀錄上最瘦的貓了";
                }

            }

        }


        else if (nowHP<=0)
        {
            nowHP = 0;
            Pet.transform.localScale = new Vector3(100f, 150f, 150f);
        }


        else if(nowHP > 100)
        {
            nowHP -= Time.deltaTime/5;
            PlayerPrefs.SetFloat("FeedTime", nowHP);
            if (nowHP > 100 && nowHP <= 110)
            {
                Pet.transform.localScale = new Vector3(400f, 400f, 400f);
                chat.SetActive(false);
                chat1.SetActive(true);
              ChatText1.text = "主人~~\n我飽了";

            }
            else if (nowHP > 110 && nowHP < 120)
            {
                Pet.transform.localScale = new Vector3(400f, 400f, 400f);
                chat.SetActive(false);
                chat1.SetActive(true);
                ChatText1.text = "傳說中爺爺奶奶養的孩子\n體型總有些不一樣\n我看了自己一眼";

            }
            else if (nowHP >= 120 && nowHP < 130)
            {
                Pet.transform.localScale = new Vector3(700f, 400f, 400f);
                chat.SetActive(false);
                chat1.SetActive(true);
                ChatText1.text = "減肥\n不屬於我的機會~";

            }

        }
        //更新畫面顯示
        updateHPBar();

    }
    void updateHPBar()
    {
        hpBar.fillAmount = nowHP / MaxHp;
    }

    //--------------------------------------------------------------------------------
    IEnumerator Huger()
    {
        yield return new WaitForSeconds(20f);
        
    }

    //--------------------------------------------------------------------------------

    //電腦滑鼠測試
    void MouseInput()
    {
        {
        if (Input.GetMouseButtonDown(0))
        {
            m_screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                MO = "yes";
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                aDefine.Direction mDirection = HandDirection(m_screenPos, pos);
                Debug.Log("mDirection: " + mDirection.ToString());

                if (mDirection.ToString() == "Up" && countButtonOnClick==0)
                {
                    YN = "yes";
                    BO = "yes";
                    countButtonOnClick++;
                }
            }
            if (MO == "yes" && BO == "yes" && PlayerPrefs.GetInt("FeedCount")>0)
            {

                foodList[currentIndex].transform.position += new Vector3(0f, 5f, 0f);//瞬移
                foodList[currentIndex].transform.localScale -= new Vector3(20f, 20f, 20f);
                StartCoroutine(LateCall1());
                BO = "no";
                Feedcount = PlayerPrefs.GetInt("FeedCount") - 1;
                PlayerPrefs.SetInt("FeedCount", Feedcount);

            }
        }
    }


    //-------------------------------------------------------------------------------
    //停止吃的動作
    IEnumerator stopeat()
    {
        yield return new WaitForSeconds(1.5f);
        EatorNot.text = "0";
        StartCoroutine(pans());
    }

    //食物空了 剩下盤子
    IEnumerator pans()
    {
        yield return new WaitForSeconds(0.5f);
        EatorNot.text = "0";
        food1.SetActive(false);
        pan.SetActive(true);
        StartCoroutine(LateCalltrue());
    }


    //控制幾秒消失
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(0.05f);
        foodList[currentIndex].SetActive(false);
        nowHP += 10;
        EatorNot.text = "1";
        if (nowHP>=120 && nowHP<200)
        {
            Pet.transform.localScale = new Vector3(700f, 400f, 400f);
        }
        else if (nowHP >= 100 && nowHP < 120)
        {
            Pet.transform.localScale = new Vector3(400f, 400f, 400f);
        }
        else if (nowHP<80)
        {
        Pet.transform.localScale += new Vector3(30f, 30f, 30f);
        }

       
        food1.SetActive(true);
        StartCoroutine(stopeat());
    }



//控制移動推出
IEnumerator LateCall1()
    {
        yield return new WaitForSeconds(0.05f);
        foodList[currentIndex].transform.position += new Vector3(0f, 5f, 0f);//瞬移
        foodList[currentIndex].transform.localScale -= new Vector3(40f, 40f, 40f);
        StartCoroutine(LateCall2());

    }
    IEnumerator LateCall2()
    {
        yield return new WaitForSeconds(0.04f);
        foodList[currentIndex].transform.position += new Vector3(0f, 5f, 0f);//瞬移   
        foodList[currentIndex].transform.localScale -= new Vector3(60f, 60f, 60f);
        StartCoroutine(LateCall3());

    }
    IEnumerator LateCall3()
    {
        yield return new WaitForSeconds(0.03f);
        foodList[currentIndex].transform.position += new Vector3(0f, 5f, 0f);//瞬移   
        foodList[currentIndex].transform.localScale -= new Vector3(100f, 100f, 100f);
        StartCoroutine(LateCall4());

    }
    IEnumerator LateCall4()
    {
        yield return new WaitForSeconds(0.02f);
        foodList[currentIndex].transform.position += new Vector3(0f, 5f, 0f);//瞬移   
        foodList[currentIndex].transform.localScale -= new Vector3(120f, 120f, 120f);
        StartCoroutine(LateCall5());

    }
    IEnumerator LateCall5()
    {
        yield return new WaitForSeconds(0.01f);
        foodList[currentIndex].transform.position += new Vector3(0f, 5f, 0f);//瞬移   
        foodList[currentIndex].transform.localScale -= new Vector3(160f, 160f, 160f);
        StartCoroutine(LateCall());

    }

    //控制幾秒重新出現
    IEnumerator LateCalltrue()
    {
        yield return new WaitForSeconds(1.5f);
        pan.SetActive(false);
        foodList[currentIndex].SetActive(true);
        foodList[currentIndex].transform.position -= new Vector3(0f, 30f, 0f);//瞬移
        foodList[currentIndex].transform.localScale += new Vector3(500f, 500f, 500f);
        YN = "no";
        countButtonOnClick--;



    }

    //--------------------------------------------------------------------------------
    //手機觸碰測試
    void MobileInput()
    {
        if (Input.touchCount <= 0)
            return;

        //1個手指觸碰螢幕
        if (Input.touchCount == 1)
        {

            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Began");
                //紀錄觸碰位置
                m_screenPos = Input.touches[0].position;
                MO = "yes";
                //手指移動
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Debug.Log("Moved");
                //移動攝影機
                //Camera.main.transform.Translate (new Vector3 (-Input.touches [0].deltaPosition.x * Time.deltaTime, -Input.touches [0].deltaPosition.y * Time.deltaTime, 0));
            }


            //手指離開螢幕
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Debug.Log("Ended");
                Vector2 pos = Input.touches[0].position;

                aDefine.Direction mDirection = HandDirection(m_screenPos, pos);
                Debug.Log("mDirection: " + mDirection.ToString());
                if (mDirection.ToString() == "Up" && countButtonOnClick == 0)
                {
                    YN = "yes";
                    BO = "yes";
                    countButtonOnClick++;
                }
            }
            if (MO == "yes" && BO == "yes" && PlayerPrefs.GetInt("FeedCount")>0)
            {

                foodList[currentIndex].transform.position += new Vector3(0f, 5f, 0f);//瞬移
                foodList[currentIndex].transform.localScale -= new Vector3(20f, 20f, 20f);
                StartCoroutine(LateCall1());
                BO = "no";
                Feedcount = PlayerPrefs.GetInt("FeedCount") - 1;
                PlayerPrefs.SetInt("FeedCount", Feedcount);
            } 

//--------------------------------------------------------------------------------------------------------------------

            //攝影機縮放，如果1個手指以上觸碰螢幕
        }
        else if (Input.touchCount > 1)
        {
            //記錄兩個手指位置
            Vector2 finger1 = new Vector2();
            Vector2 finger2 = new Vector2();

            //記錄兩個手指移動距離
            Vector2 move1 = new Vector2();
            Vector2 move2 = new Vector2();

            //是否是小於2點觸碰
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Touch touch = UnityEngine.Input.touches[i];

                if (touch.phase == TouchPhase.Ended)
                    break;

                if (touch.phase == TouchPhase.Moved)
                {
                    //每次都重置
                    float move = 0;

                    //觸碰一點
                    if (i == 0)
                    {
                        finger1 = touch.position;
                        move1 = touch.deltaPosition;
                        //另一點
                    }
                    else
                    {
                        finger2 = touch.position;
                        move2 = touch.deltaPosition;

                        //取最大X
                        if (finger1.x > finger2.x)
                        {
                            move = move1.x;
                        }
                        else
                        {
                            move = move2.x;
                        }

                        //取最大Y，並與取出的X累加
                        if (finger1.y > finger2.y)
                        {
                            move += move1.y;
                        }
                        else
                        {
                            move += move2.y;
                        }

                        //當兩指距離越遠，Z位置加的越多，相反之
                        Camera.main.transform.Translate(0, 0, move * Time.deltaTime);
                    }
                }
            }//end for
        }//end else if 
    }//end void
    //---------------------------------------------------------------------------
    aDefine.Direction HandDirection(Vector2 StartPos, Vector2 EndPos)
    {
        aDefine.Direction mDirection;

        //手指水平移動
        if (Mathf.Abs(StartPos.x - EndPos.x) > Mathf.Abs(StartPos.y - EndPos.y))
        {
            if (StartPos.x > EndPos.x)
            {
                //手指向左滑動
                mDirection = aDefine.Direction.Left;
            }
            else
            {
                //手指向右滑動
                mDirection = aDefine.Direction.Right;
            }
        }
        else
        {
            if (m_screenPos.y == EndPos.y || m_screenPos.y > EndPos.y)
            {
                if (m_screenPos.y == EndPos.y)
                {
                    //手指不滑動
                    mDirection = aDefine.Direction.Stop;
                }
                else
                {
                    //手指下滑動
                    mDirection = aDefine.Direction.Down;
                }
                
            }

            else
            {
                if (m_screenPos.y < EndPos.y-100)
                {
                //手指向上滑動
                mDirection = aDefine.Direction.Up;
                }
                else
                {
                    //手指滑動不足
                    mDirection = aDefine.Direction.Stop;
                }

            }
        }
        return mDirection;

    }

    //---------------------------------------------------------------------------




    public void clickLeft()
    {
        if (YN == "no")
        {
        previousIndex = currentIndex;
        currentIndex--;

        Debug.Log("clickLeft " + currentIndex+" pre "+ previousIndex);
       
        updateButtonStatus();
        changeFood();
        }
        else
        {

        }

        
    }

    public void clickRight()
    {
        if (YN == "no")
        {
        previousIndex = currentIndex;
        currentIndex++;

        Debug.Log("clickRight " + currentIndex + " pre " + previousIndex);
       
        updateButtonStatus();
        changeFood();
        }
        else
        {

        }


    }



    private void updateButtonStatus()
    {

        leftButton.SetActive(!(currentIndex == 0));
        rightButton.SetActive(!(currentIndex == MAX_COUNT - 1));
        //changeFood();
    }



    public void changeFood()
    {
       
        GameObject currentFoodObject = foodList[currentIndex];
        GameObject previousFoodObject = foodList[previousIndex];
 

        currentFoodObject.SetActive(true);
        previousFoodObject.SetActive(false);
        //currentFoodObject.SetActive(true);//(1)可執行，但圖案消失(隱藏)
        //Instantiate(currentFoodObject);//(2)可行
        //((FoodObject)(previousFoodObject)).removeObject();//(2)不行
        //previousFoodObject.SetActive(false);//(3)可執行，但圖案消失(隱藏)
        //currentFoodObject.GetComponent<Renderer>().enabled = true;//(4)可執行；log結果OK.但沒圖案
        //previousFoodObject.GetComponent<Renderer>().enabled = false;//(4)可執行；log結果OK.但沒圖案
        //DestroyImmediate(previousFoodObject,true);//(1)不會消失，但同一物件只能執行一次，將不再能執行，圖案prefab也消失檔案不能使用  XX 絕對不用QQ XX


    }
}