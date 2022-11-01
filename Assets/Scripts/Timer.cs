using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time; //시간
    public Text[] timeText; //텍스트

    void Start()
    {
        Debug.Log("Timer Start"); //Log
    }

    void Update()
    {
        time += Time.deltaTime;
        GameObject.Find("Spawn").GetComponent<Spawn>().timer = time; //없어도 가능 일단은 혹시 모르니 살려둠

        timeText[0].text = string.Format("{0:D2}", (int)time / 60 % 60); //분 출력
        timeText[1].text = string.Format("{0:D2}", (int)time % 60); //초 출력
    }
}
