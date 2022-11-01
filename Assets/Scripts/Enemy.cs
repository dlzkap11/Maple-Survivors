using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target; //Ÿ��(�÷��̾�)
    SpriteRenderer rend;
    public GameObject expMarble; //����ġ ����

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
        if (Pause.pause == false)
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
        Debug.Log(this + " on damage! -" + dmg); //Log

        if(HP <= 0) //��� ��
        {
            Destroy(gameObject);
            Debug.Log(this + " has destroyed!"); //Log

            dropObj();
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

    void dropObj() //���(����ġ/�޼�)
    {
        //����ġ(Ȯ��)
        Instantiate(expMarble, transform.position, Quaternion.identity);

        //�޼�(Ȯ��)
        /*�������� ���̵��� rand % 100�ϸ� 0~99 �����ݾ�.
          �׷� Ȯ���� 20% ���Ϸ� �ϰ�ʹٰ� �����Ѵٸ�
          rand�ؼ� ���� �� >= 19 �ϸ� 20�ۼ�Ʈ�� ���ϴ� �κ��̰�
          �������� 80�ۼ�Ʈ�� �̷��� �����ص� ������ �� ����.*/
    }
}


