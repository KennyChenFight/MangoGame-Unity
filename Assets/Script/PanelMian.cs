using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMian : MonoBehaviour {

    public GameObject panelBGameObject;
 //   public GameObject panelCGameObject;
    public GameObject panelDGameObject;
    public GameObject panelEGameObject;

    public void OnBtnShowClickA() {
        UIManager.Instance.ShowPanel("PanelA");
    }


    public void OnBtnShowClickB()
    {
        //UIManager.Instance.ShowPanel("PanelB");
        panelBGameObject.SetActive(true);
        gameObject.SetActive(false);

    


    }



 /*   public void OnBtnShowClickC()
    {
        //UIManager.Instance.ShowPanel("PanelC");
        
        panelCGameObject.SetActive(true);
        gameObject.SetActive(false);
    }*/


    public void OnBtnShowClickD()
    {
        //UIManager.Instance.ShowPanel("PanelD");
        panelDGameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    public void OnBtnShowClickE()
    {
        //UIManager.Instance.ShowPanel("PanelE");
        panelEGameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OnBtnShowClickF()
    {
        UIManager.Instance.ShowPanel("PanelF");
    }
}
