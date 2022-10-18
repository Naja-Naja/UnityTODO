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


    //現在のモード
    static Mode AppMode;

    //現在のモードの取得はどこからでも自由に可能
    public static Mode GetMode()
    {
        return AppMode;
    }

    //モードの変更はオブジェクト参照を持つスクリプトから可能
    public void SetMode(Mode changeMode)
    {
        AppMode = changeMode;
        AppModeChabge.OnNext(changeMode);
    }

    //モード変更時にはサブスクライブされているオブジェクトに通知が飛ぶ
    private static Subject<Mode> AppModeChabge = new Subject<Mode>();

    //購読はどこからでも可能
    public static IObservable<Mode> OnModeChanged
    {
        get { return AppModeChabge; }
    }

    void Awake()
    {
        //最初にMainMenuに設定
        SetMode(Mode.MainMenu);
    }
}
