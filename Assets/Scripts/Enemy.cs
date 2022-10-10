using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;
    SpriteRenderer rend;

    Color normalColor; //�⺻ ��
    Color hitColor; //�ǰ� �� ��

    public float MoveSpeed; //�̵��ӵ�
    public static float damage; //���ݷ�
    public float MaxHP; //�ִ�ü��
    public float HP; //����ü��

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        target = GameObject.FindWithTag("Player"); //Player �±׸� Ÿ������ ����
        HP = MaxHP;

        damage = 10; //�ʱ� ���ݷ� (�Ŀ� ����)

        normalColor = rend.color;
        hitColor = normalColor;
        hitColor.r -= 0.5f;
        hitColor.g -= 0.5f;
        hitColor.b -= 0.5f;

    }

    void Update()
    {
        targetInit();
        Chase();
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

    void OnHit(float dmg) //�ǰ� ��
    {
        HP -= dmg;

        if(HP <= 0)
        {
            Destroy(gameObject);
        }
        else if (HP > 0)
        {
            StartCoroutine("OnHitEffect");
        }        
    }
    IEnumerator OnHitEffect () //�ǰ� �� �� ��ȭ
    {
        rend.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        rend.color = normalColor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet") //PlayerBullet�� ���� ��
        {
            NormalBullet bullet = collision.gameObject.GetComponent<NormalBullet>();
            OnHit(bullet.dmg);
        }
    }
}
