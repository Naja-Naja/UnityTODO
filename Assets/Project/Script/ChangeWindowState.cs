using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWindowState : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] bool state = true;
    [SerializeField] GameObject window;
    [SerializeField] Mode changemode;
    [SerializeField] Appmanager appmanager;
    void Start()
    {
        //モード変更ボタンのコールバック登録
        button.onClick.AddListener(SetState);
    }
    void SetState()
    {
        //モード変更処理
        window.SetActive(state);
        Debug.Log("setstate" + state);
        appmanager.SetMode(changemode);
    }
}
