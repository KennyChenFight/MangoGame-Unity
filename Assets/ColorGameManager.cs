using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MaterialUI;
using System.IO;


public class ColorGameManager : MonoBehaviour {

    public Question[] question;
    public static List<Question> questions;
    public Question currentQuestion;
    public static int time = 60;
    public static int level = 1;
    public static double correctAnswerCount = 0;
    public static double wrongAnswerCount = 0;
    public static double correctRate = 0;
    public static double totalCorrectAnswerCount = 0;
    public static double totalWrongAnswerCount = 0;
    public static double totalCorrectRate = 0;
    public static bool isStartTimer = false;
    public static UserData[] userDatas = null;
    public static int countTatalTime = 0;
    

    [SerializeField]
    public Text questionText;
    [SerializeField]
    public Text button1Text;
    [SerializeField]
    public Text button2Text;
    [SerializeField]
    public Text resultText;
    [SerializeField]
    public Text timeText;
    [SerializeField]
    public Text levelNumText;
    [SerializeField]
    public Text correctRateText;

    public GameObject dialogBox;
    public GameObject nextLevelDialogBox;




    void Start () {
        Debug.Log(Application.persistentDataPath + "/" + "userData.json");
        questions = question.ToList<Question>();
        GetCurrentQuestion();
    }
	
	void Update () {
        
    }

    public void GetCurrentQuestion()
    {
        if (IsFileExist())
        {
            Load();
        }
        Debug.Log("GetCurrentQuestion()");
        resultText.text = "請作答";
        if (questions.Count == 0)
        {
            questions = question.ToList<Question>();
        }
        int questionIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[questionIndex];

        SelectQuestionTextAndColor();
        SelectResponseText();

        questions.RemoveAt(questionIndex);
        timeText.text = "時間:" + time + "";
        levelNumText.text = level + "";
        if (!isStartTimer)
        {
            InvokeRepeating("timer", 1, 1);
            isStartTimer = true;
        }
    }

    public void GetNextLevel()
    {
        
        Debug.Log("GetNextLevel()");
        if (level == 5)
        {
            //resultText.text = "全部破完了~好棒棒";
            totalCorrectRate = System.Math.Truncate((totalCorrectAnswerCount / (totalCorrectAnswerCount + totalWrongAnswerCount)) * 100);
            Save();
            dialogBox.SetActive(true);
        }
        else
        {
            nextLevelDialogBox.SetActive(false);
            questions = question.ToList<Question>();
            resultText.text = "請作答";
            int questionIndex = Random.Range(0, questions.Count);
            currentQuestion = questions[questionIndex];

            SelectQuestionTextAndColor();
            SelectResponseText();

            questions.RemoveAt(questionIndex);
            correctAnswerCount = 0;
            wrongAnswerCount = 0;
            level++;
            levelNumText.text = level + "";
            time = 60 - 10 * (level - 1);
            timeText.text = "時間:" + time + "";
            InvokeRepeating("timer", 1, 1);
        }

    }

    private void SelectQuestionTextAndColor()
    {
        questionText.text = currentQuestion.fact;
        switch (currentQuestion.questionColor)
        {
            case "綠":
                questionText.color = Color.green;
                break;
            case "紅":
                questionText.color = Color.red;
                break;
            case "藍":
                questionText.color = Color.blue;
                break;
            case "黃":
                questionText.color = Color.yellow;
                break;
        }
        
    }

    private void SelectResponseText()
    {
        int buttonRandom = Random.Range(1, 3);
        if (buttonRandom == 1)
        {
            button1Text.text = currentQuestion.TrueColor;
            button2Text.text = currentQuestion.falseColor;
            //correctText.text = "錯誤";
            //wrongText.text = "正確";

        }
        else
        {
            button2Text.text = currentQuestion.TrueColor;
            button1Text.text = currentQuestion.falseColor;           
        }
            
    }

    IEnumerator TransitionToNextQuestion()
    {
        Debug.Log("答對題數:" + correctAnswerCount);
        yield return new WaitForSecondsRealtime(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (correctAnswerCount != 10)
        {
            GetCurrentQuestion();
        }
        else
        {
            if (correctRate >= 70)
            {
                CancelInvoke("timer");
                if (level != 5)
                {
                    nextLevelDialogBox.SetActive(true);
                }
                else
                {
                    GetNextLevel();
                }
            }
            else
            {
                dialogBox.SetActive(true);
            }
        }
    }

    public void SelectColor1Button()
    {
        if (button1Text.text.Equals(currentQuestion.questionColor))
        {
            Debug.Log("Correct");
            resultText.text = "正確";
            correctAnswerCount++;
            totalCorrectAnswerCount++;
        }
        else
        {
            Debug.Log("Wrong");
            resultText.text = "錯誤";
            wrongAnswerCount++;
            totalWrongAnswerCount++;
        }
        correctRate = System.Math.Truncate((correctAnswerCount / (correctAnswerCount + wrongAnswerCount)) * 100);
        correctRateText.text = "正確率:" + correctRate + "%";
        Debug.Log("totalCorrectAnswer:" + totalCorrectAnswerCount);
        Debug.Log("totalWrongAnswer:" + totalWrongAnswerCount);
        StartCoroutine(TransitionToNextQuestion());
    }

    public void SelectColor2Button()
    {
        if (button2Text.text.Equals(currentQuestion.questionColor))
        {
            Debug.Log("Correct");
            resultText.text = "正確";
            correctAnswerCount++;
            totalCorrectAnswerCount++;
        }
        else
        {
            Debug.Log("Wrong");
            resultText.text = "錯誤";
            wrongAnswerCount++;
            totalWrongAnswerCount++;
        }
        correctRate = System.Math.Truncate((correctAnswerCount / (correctAnswerCount + wrongAnswerCount)) * 100);
        correctRateText.text = "正確率:" + correctRate + "%";
        Debug.Log("totalCorrectAnswer:" + totalCorrectAnswerCount);
        Debug.Log("totalWrongAnswer:" + totalWrongAnswerCount);
        StartCoroutine(TransitionToNextQuestion());
    }

    public void timer()
    {
        time -= 1;
        countTatalTime += 1;
        timeText.text = "時間:" + time + "";

        if (time == 0)
        {
            timeText.text = "時間到";
            CancelInvoke("timer");
            if (correctRate >= 70)
            {
                StartCoroutine(TransitionToNextQuestion());
            }
            else
            {
                //resultText.text = "沒有答對一定的題數，無法晉級請重玩";
                dialogBox.SetActive(true);
            }

        }
    }

    public void RestartGame()
    {
        time = 60;
        countTatalTime = 0;
        level = 1;
        correctAnswerCount = 0;
        wrongAnswerCount = 0;
        correctRate = 0;
        totalCorrectAnswerCount = 0;
        totalWrongAnswerCount = 0;
        totalCorrectRate = 0;
        isStartTimer = false;
        questions = question.ToList<Question>();
        dialogBox.SetActive(false);
        GetCurrentQuestion();
    }

    public void GoToMain()
    {
        userDatas = null;
        time = 60;
        countTatalTime = 0;
        level = 1;
        correctAnswerCount = 0;
        wrongAnswerCount = 0;
        correctRate = 0;
        totalCorrectAnswerCount = 0;
        totalWrongAnswerCount = 0;
        totalCorrectRate = 0;
        isStartTimer = false;
        SceneManager.LoadScene("MainScene");
    }

    public void Save()
    {
        try
        {
            UserData userData = new UserData();
            userData.name = "Kenny";
            userData.bestRecord = countTatalTime;
            userData.date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            userData.correctRate = totalCorrectRate;
            string saveString = "";
            if (userDatas == null)
            {
                PlayerPrefs.SetFloat("EXtrueRate1Color", 0);
                userDatas = new UserData[1];
                userDatas[0] = userData;
                saveString = JsonHelper.ToJson(userDatas, true);
            }
            else
            {
                int length = userDatas.Length;
                UserData[] newDatas = new UserData[length + 1];
                for (int i = 0; i < newDatas.Length - 1; i++)
                {
                    newDatas[i] = userDatas[i];
                }
                newDatas[newDatas.Length - 1] = userData;
                saveString = JsonHelper.ToJson(newDatas, true);
            }

            Debug.Log(saveString);
            
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
            {
                StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + "userData.json");
                writer.WriteLine(saveString);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
            else
            {
                StreamWriter writer = new StreamWriter(Path.Combine(Application.streamingAssetsPath, "userData.json"));
                writer.WriteLine(saveString);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
            int FeedCount;
            if (PlayerPrefs.GetFloat("EXtrueRate1Color") <= (totalCorrectRate + 10))
            {
                FeedCount = PlayerPrefs.GetInt("FeedCount") + 1;
                Debug.Log("before FeedCount:" + PlayerPrefs.GetInt("FeedCount"));
                PlayerPrefs.SetInt("FeedCount", FeedCount);
                Debug.Log(PlayerPrefs.GetInt("FeedCount"));
            }
            PlayerPrefs.SetFloat("EXtrueRate1Color", System.Convert.ToSingle(totalCorrectRate));
            Debug.Log("After FeedCount:" + PlayerPrefs.GetInt("FeedCount"));
        } catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
        
    }

    public void Load()
    {
        try
        {
            string loadJson = "";
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
            {
                StreamReader file = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, "userData.json"));
                loadJson = file.ReadToEnd();
                file.Close();
            }
            else
            {
                StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "userData.json"));
                loadJson = file.ReadToEnd();
                file.Close();
            }

            userDatas = JsonHelper.FromJson < UserData > (loadJson);
            for (int i = 0; i < userDatas.Length; i++)
            {
                Debug.Log(userDatas[i].date);
            }
        } catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public bool IsFileExist()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "userData.json")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        public static string FixJson(string value)
        {
            value = "{\"Items\":" + value + "}";
            return value;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
