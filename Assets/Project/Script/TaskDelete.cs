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
        //�폜�`�F�b�N�{�b�N�X�̃R�[���o�b�N�o�^
        toggle.onValueChanged.AddListener(AddDeleteList);

        //���[�h�ύX�̒ʒm���󂯎��ADotween�ō폜�{�^�����o��������
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

    //�폜�`�F�b�N�{�b�N�X�̍X�V�ŌĂ΂�Adeletebutton�̎����X�g�Ɏ��g��ID�̒ǉ�/�폜���s��
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
