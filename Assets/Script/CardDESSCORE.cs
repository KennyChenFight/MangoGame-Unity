using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDESSCORE : MonoBehaviour {
    public GameObject panelMain;
    public GameObject panelDES;
    public GameObject panelSCORE;

    public void OnBtnShowClickMain()
    {
        panelMain.SetActive(true);
        panelDES.SetActive(false);
        panelSCORE.SetActive(false);

    }
    public void OnBtnShowClickDES()
    {
        panelMain.SetActive(false);
        panelDES.SetActive(true);
        panelSCORE.SetActive(false);

    }

    public void OnBtnShowClickSCORE()
    {
        panelMain.SetActive(false);
        panelDES.SetActive(false);
        panelSCORE.SetActive(true);

    }

}
