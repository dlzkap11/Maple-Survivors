using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;
    SpriteRenderer rend;

    public float MoveSpeed; //이동속도
    public float damage; //공격력
    public float MaxHP; //최대체력
    public float HP; //현재체력

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        target = GameObject.FindWithTag("Player"); //Player 태그를 타겟으로 지정
        HP = MaxHP;
    }

    void Update()
    {
        targetInit();
        Chase();
        attack();
    }

    void targetInit() //타겟(플레이어) 초기화
    {
        target = GameObject.FindWithTag("Player");
    }

    void Chase()
    {
        transform.position //target 추적
            = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * 0.001f);

        //sprite 변경
        if (target.transform.position.x > transform.position.x)
            rend.flipX = true; //우측이동
        else if (target.transform.position.x < transform.position.x)
            rend.flipX = false; //좌측이동
    }

    void attack()
    {

    }
}
