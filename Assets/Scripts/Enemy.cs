using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;
    SpriteRenderer rend;

    public float MoveSpeed; //�̵��ӵ�
    public float damage; //���ݷ�
    public float MaxHP; //�ִ�ü��
    public float HP; //����ü��

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        target = GameObject.FindWithTag("Player"); //Player �±׸� Ÿ������ ����
        HP = MaxHP;
    }

    void Update()
    {
        targetInit();
        Chase();
        attack();
    }

    void targetInit() //Ÿ��(�÷��̾�) �ʱ�ȭ
    {
        target = GameObject.FindWithTag("Player");
    }

    void Chase()
    {
        transform.position //target ����
            = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * 0.001f);

        //sprite ����
        if (target.transform.position.x > transform.position.x)
            rend.flipX = true; //�����̵�
        else if (target.transform.position.x < transform.position.x)
            rend.flipX = false; //�����̵�
    }

    void attack()
    {

    }
}
