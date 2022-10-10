using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time; //시간
    public Text[] timeText; //텍스트

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;

        timeText[0].text = string.Format("{0:D2}", (int)time / 60 % 60); //분 출력
        timeText[1].text = string.Format("{0:D2}", (int)time % 60); //초 출력
    }
}
