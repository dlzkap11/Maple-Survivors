using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;

    public float MoveSpeed; //이동속도

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

    void targetInit() //타겟(플레이어) 초기화
    {
        target = GameObject.FindWithTag("Player");
    }
}
