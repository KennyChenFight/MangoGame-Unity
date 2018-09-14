using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelA : MonoBehaviour {
    public GameObject panelMainGameObject;
    public GameObject panelCGameObject;

    public void OnBtnCloseClick() {
        panelMainGameObject.SetActive(true);
        panelCGameObject.SetActive(false);
    }
    public void OnBtnOpenClick()
    {
        panelMainGameObject.SetActive(false);
        panelCGameObject.SetActive(true);
    }
}
