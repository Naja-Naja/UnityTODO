using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public enum Mode
{
    MainMenu,
    Delete,
}
public class Appmanager : MonoBehaviour
{


    //���݂̃��[�h
    static Mode AppMode;

    //���݂̃��[�h�̎擾�͂ǂ�����ł����R�ɉ\
    public static Mode GetMode()
    {
        return AppMode;
    }

    //���[�h�̕ύX�̓I�u�W�F�N�g�Q�Ƃ����X�N���v�g����\
    public void SetMode(Mode changeMode)
    {
        AppMode = changeMode;
        AppModeChabge.OnNext(changeMode);
    }

    //���[�h�ύX���ɂ̓T�u�X�N���C�u����Ă���I�u�W�F�N�g�ɒʒm�����
    private static Subject<Mode> AppModeChabge = new Subject<Mode>();

    //�w�ǂ͂ǂ�����ł��\
    public static IObservable<Mode> OnModeChanged
    {
        get { return AppModeChabge; }
    }

    void Awake()
    {
        //�ŏ���MainMenu�ɐݒ�
        SetMode(Mode.MainMenu);
    }
}
