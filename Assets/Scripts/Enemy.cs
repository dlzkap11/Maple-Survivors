using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;

    public float MoveSpeed; //�̵��ӵ�

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        targetInit();

        transform.position 
            = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * 0.001f);
    }

    void targetInit() //Ÿ��(�÷��̾�) �ʱ�ȭ
    {
        target = GameObject.FindWithTag("Player");
    }
}
