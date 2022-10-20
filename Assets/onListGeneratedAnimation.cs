using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class onListGeneratedAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
