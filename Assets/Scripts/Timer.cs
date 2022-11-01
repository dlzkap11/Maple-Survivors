using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time; //�ð�
    public Text[] timeText; //�ؽ�Ʈ

    void Start()
    {
        Debug.Log("Timer Start"); //Log
    }

    void Update()
    {
        time += Time.deltaTime;
        GameObject.Find("Spawn").GetComponent<Spawn>().timer = time; //��� ���� �ϴ��� Ȥ�� �𸣴� �����

        timeText[0].text = string.Format("{0:D2}", (int)time / 60 % 60); //�� ���
        timeText[1].text = string.Format("{0:D2}", (int)time % 60); //�� ���
    }
}
