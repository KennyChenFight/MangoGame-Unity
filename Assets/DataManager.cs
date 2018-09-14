using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour {

    public GameObject panel1;
    [SerializeField]
    public Text panel1Date;
    [SerializeField]
    public Text panel1BestRecord;
    [SerializeField]
    public Text panel1BestRate;

    public GameObject panel2;
    [SerializeField]
    public Text panel2Date;
    [SerializeField]
    public Text panel2BestRecord;
    [SerializeField]
    public Text panel2BestRate;

    public GameObject panel3;
    [SerializeField]
    public Text panel3Date;
    [SerializeField]
    public Text panel3BestRecord;
    [SerializeField]
    public Text panel3BestRate;

    public GameObject panel4;
    [SerializeField]
    public Text panel4Date;
    [SerializeField]
    public Text panel4BestRecord;
    [SerializeField]
    public Text panel4BestRate;

    public GameObject panel5;
    [SerializeField]
    public Text panel5Date;
    [SerializeField]
    public Text panel5BestRecord;
    [SerializeField]
    public Text panel5BestRate;

    public GameObject noDatatext;

    public static UserData[] userDatas;


    void Start () {
		if (IsFileExist())
        {
            Load();
            ShowDataPanel();
        }
        else
        {
            ShowNoDataText();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowNoDataText()
    {
        noDatatext.SetActive(true);
    }

    public void ShowDataPanel()
    {
        int length = userDatas.Length;
        switch(length)
        {
            case 1:
                panel1Date.text = "時間:" + userDatas[0].date;
                panel1BestRecord.text = "最佳紀錄:" + userDatas[0].bestRecord + "s";
                panel1BestRate.text = "最佳正確率:" + userDatas[0].correctRate + "%";
                panel1.SetActive(true);
                break;
            case 2:
                panel1Date.text = "時間:" + userDatas[0].date;
                panel1BestRecord.text = "最佳紀錄:" + userDatas[0].bestRecord + "s";
                panel1BestRate.text = "最佳正確率:" + userDatas[0].correctRate + "%";
                panel1.SetActive(true);
                panel2Date.text = "時間:" + userDatas[1].date;
                panel2BestRecord.text = "最佳紀錄:" + userDatas[1].bestRecord + "s";
                panel2BestRate.text = "最佳正確率:" + userDatas[1].correctRate + "%";
                panel2.SetActive(true);
                break;
            case 3:
                panel1Date.text = "時間:" + userDatas[0].date;
                panel1BestRecord.text = "最佳紀錄:" + userDatas[0].bestRecord + "s";
                panel1BestRate.text = "最佳正確率:" + userDatas[0].correctRate + "%";
                panel1.SetActive(true);
                panel2Date.text = "時間:" + userDatas[1].date;
                panel2BestRecord.text = "最佳紀錄:" + userDatas[1].bestRecord + "s";
                panel2BestRate.text = "最佳正確率:" + userDatas[1].correctRate + "%";
                panel2.SetActive(true);
                panel3Date.text = "時間:" + userDatas[2].date;
                panel3BestRecord.text = "最佳紀錄:" + userDatas[2].bestRecord + "s";
                panel3BestRate.text = "最佳正確率:" + userDatas[2].correctRate + "%";
                panel3.SetActive(true);
                break;
            case 4:
                panel1Date.text = "時間:" + userDatas[0].date;
                panel1BestRecord.text = "最佳紀錄:" + userDatas[0].bestRecord + "s";
                panel1BestRate.text = "最佳正確率:" + userDatas[0].correctRate + "%";
                panel1.SetActive(true);
                panel2Date.text = "時間:" + userDatas[1].date;
                panel2BestRecord.text = "最佳紀錄:" + userDatas[1].bestRecord + "s";
                panel2BestRate.text = "最佳正確率:" + userDatas[1].correctRate + "%";
                panel2.SetActive(true);
                panel3Date.text = "時間:" + userDatas[2].date;
                panel3BestRecord.text = "最佳紀錄:" + userDatas[2].bestRecord + "s";
                panel3BestRate.text = "最佳正確率:" + userDatas[2].correctRate + "%";
                panel3.SetActive(true);
                panel4Date.text = "時間:" + userDatas[3].date;
                panel4BestRecord.text = "最佳紀錄:" + userDatas[3].bestRecord + "s";
                panel4BestRate.text = "最佳正確率:" + userDatas[3].correctRate + "%";
                panel4.SetActive(true);
                break;
            case 5:
                panel1Date.text = "時間:" + userDatas[0].date;
                panel1BestRecord.text = "最佳紀錄:" + userDatas[0].bestRecord + "s";
                panel1BestRate.text = "最佳正確率:" + userDatas[0].correctRate + "%";
                panel1.SetActive(true);
                panel2Date.text = "時間:" + userDatas[1].date;
                panel2BestRecord.text = "最佳紀錄:" + userDatas[1].bestRecord + "s";
                panel2BestRate.text = "最佳正確率:" + userDatas[1].correctRate + "%";
                panel2.SetActive(true);
                panel3Date.text = "時間:" + userDatas[2].date;
                panel3BestRecord.text = "最佳紀錄:" + userDatas[2].bestRecord + "s";
                panel3BestRate.text = "最佳正確率:" + userDatas[2].correctRate + "%";
                panel3.SetActive(true);
                panel4Date.text = "時間:" + userDatas[3].date;
                panel4BestRecord.text = "最佳紀錄:" + userDatas[3].bestRecord + "s";
                panel4BestRate.text = "最佳正確率:" + userDatas[3].correctRate + "%";
                panel4.SetActive(true);
                panel5Date.text = "時間:" + userDatas[4].date;
                panel5BestRecord.text = "最佳紀錄:" + userDatas[4].bestRecord + "s";
                panel5BestRate.text = "最佳正確率:" + userDatas[4].correctRate + "%";
                panel5.SetActive(true);
                break;
        }
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Load()
    {
        try
        {
            string loadJson = "";
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
            {
                Debug.Log(System.IO.Path.Combine(Application.persistentDataPath, "userData.json"));
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

            userDatas = JsonHelper.FromJson<UserData>(loadJson);

            int length = userDatas.Length;
            if (length > 5)
            {
                UserData[] tempUserData = new UserData[5];
                int count = 0;
                for (int i = length - 5; i < userDatas.Length; i++)
                {
                    tempUserData[count] = userDatas[i];
                    count++;
                }
                userDatas = tempUserData;
            }
            for (int i = 0; i < userDatas.Length; i++)
            {
                Debug.Log(userDatas[i].date);
            }
        }
        catch (System.Exception e)
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
