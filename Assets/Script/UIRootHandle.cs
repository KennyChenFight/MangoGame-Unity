using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootHandle : MonoBehaviour {

    void Awake()
    {
        UIManager.Instance.m_CanvasRoot = gameObject;
    }
}
