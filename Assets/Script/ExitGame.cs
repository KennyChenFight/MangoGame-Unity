using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Text Show;
    float fadingSpeed = 1;
    bool fading;
    float startFadingTimep;
    Color originalColor;
    Color transparentColor;

    void Start()
    {
        originalColor = Show.color;
        transparentColor = originalColor;
        transparentColor.a = 0;
        Show.text = "再次按下返回鍵退出遊戲";
        Show.color = transparentColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (startFadingTimep == 0)
            {
                Show.color = originalColor;
                startFadingTimep = Time.time;
                fading = true;
            }
            else
            {
                Application.Quit();
            }
        }
        if (fading)
        {
            Show.color = Color.Lerp(originalColor, transparentColor, (Time.time - startFadingTimep) * fadingSpeed);
            if (Show.color.a < 2.0 / 255)
            {
                Show.color = transparentColor;
                startFadingTimep = 0;
                fading = false;
            }
        }
    }
}