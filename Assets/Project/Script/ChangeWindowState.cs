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
        //���[�h�ύX�{�^���̃R�[���o�b�N�o�^
        button.onClick.AddListener(SetState);
    }
    void SetState()
    {
        //���[�h�ύX����
        window.SetActive(state);
        Debug.Log("setstate" + state);
        appmanager.SetMode(changemode);
    }
}
