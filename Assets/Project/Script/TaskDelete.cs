using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class TaskDelete : MonoBehaviour
{

    [SerializeField] RectTransform rect;
    public int selfTaskID;
    [SerializeField] Toggle toggle;

    float rectoffset_left ;
    void Start()
    {
        //削除チェックボックスのコールバック登録
        toggle.onValueChanged.AddListener(AddDeleteList);

        //モード変更の通知を受け取り、Dotweenで削除ボタンを出現させる
        Appmanager.OnModeChanged.Subscribe(mode =>
        {
            if (mode == Mode.MainMenu)
            {
                DOTween.To(() =>rectoffset_left, x => rectoffset_left = x, 0, 0.5f).OnUpdate(rectUpdate);
            }
            else if (mode==Mode.Delete)
            {
                DOTween.To(() =>
                rectoffset_left, x => rectoffset_left = x, 175, 0.5f).OnUpdate(rectUpdate);
            }
        });
    }
    void rectUpdate()
    {
        rect.offsetMin = new Vector2(rectoffset_left, 0);
    }

    //削除チェックボックスの更新で呼ばれ、deletebuttonの持つリストに自身のIDの追加/削除を行う
    void AddDeleteList(bool choice)
    {
        if (choice == true)
        {
            var deletebutton = GameObject.FindGameObjectWithTag("deletebutton").GetComponent<DeleteButton>();
            deletebutton.deletelist.Add(selfTaskID);
        }
        else if (choice == false)
        {
            var deletebutton = GameObject.FindGameObjectWithTag("deletebutton").GetComponent<DeleteButton>();
            deletebutton.deletelist.Remove(selfTaskID);
        }
    }

}
