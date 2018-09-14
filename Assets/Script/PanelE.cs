using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelE : MonoBehaviour {

    public GameObject panelMainGameObject;
    public GameObject panelE2GameObject;
    // public GameObject panelDGameObject;
    public GameObject Des;

    public void OnBtnCloseClick()
    {
        gameObject.SetActive(true);
        panelMainGameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    public void OnBtnShowClickE2()
    {
        //UIManager.Instance.ShowPanel("PanelC");
        panelE2GameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnBtnShowClickDes()
    {
        //UIManager.Instance.ShowPanel("PanelC");
        Des.SetActive(true);



    }
    public void OnBtnShowClickDesClose()
    {
        //UIManager.Instance.ShowPanel("PanelC");
        Des.SetActive(false);

    }

}
