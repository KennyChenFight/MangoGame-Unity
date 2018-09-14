using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelD : MonoBehaviour {

    public GameObject panelMainGameObject;
    public GameObject panelCGameObject;
    // public GameObject panelDGameObject;
    public GameObject Des;



    public void OnBtnCloseClick()
    {
        gameObject.SetActive(true);
        panelMainGameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    public void OnBtnShowClickC()
    {
        //UIManager.Instance.ShowPanel("PanelC");
        panelCGameObject.SetActive(true);
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