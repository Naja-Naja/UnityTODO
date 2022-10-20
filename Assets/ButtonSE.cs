using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonSE : MonoBehaviour
{
    AudioClip buttonSE;
    public void onClick()
    {
        Debug.Log("click");   
        AudioManager.SE_Play(buttonSE);
    }

}
