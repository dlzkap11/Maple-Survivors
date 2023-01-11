using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    GameObject target; //Ÿ��(�÷��̾�)
    SpriteRenderer rend;
    public GameObject expMarble; //����ġ ����
    public GameObject hudDamageText; //������ �ؽ�Ʈ

    public enum Type { Normal, Flying, None };
    public Type MonsterType;
    Rigidbody2D bat;
    Vector2 wave;
    Vector2 mypos;

    Color normalColor; //�⺻ ��
    Color hitColor; //�ǰ� �� ��

    public float MoveSpeed; //�̵��ӵ�
    public float damage; //���ݷ�
    public float MaxHP; //�ִ�ü��
    public float HP; //����ü��
    private Vector3 playerposition;

    private void Awake()
    {
        bat = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        target = GameObject.FindWithTag("Player"); //Player �±׸� Ÿ������ ����
        HP = MaxHP;

        normalColor = rend.color;
        hitColor = normalColor;
        hitColor.r -= 0.5f;
        hitColor.g -= 0.5f;
        hitColor.b -= 0.5f;

        playerposition = target.transform.position;
        mypos = transform.position;
        wave = new Vector2(-transform.position.x, -transform.position.y);

        if (MonsterType == Type.Flying)
            Monster_flip();
    }

    void GoAway()
    {
        float x = playerposition.x;
        float y = playerposition.y;

        float a = mypos.x;
        float b = mypos.y;

        float result_x;
        float result_y;
        
        result_x = Mathf.Abs(x - a);
        result_y = Mathf.Abs(y - b);

       
        if(x > a && y > b)// �÷��̾ ���ͺ��� �����ʿ� ������
        {
            Vector2 Away = new Vector2(result_x, result_y);
            bat.AddForce(Away * 0.01f * MoveSpeed);
        }
        else if(y > b) //�÷��̾ ���ͺ��� ���� ������
        {
            Vector2 Away = new Vector2(-result_x, result_y);
            bat.AddForce(Away * 0.01f * MoveSpeed);
        }
        else if(x < a)
        {
            Vector2 Away = new Vector2(-result_x, -result_y);
            bat.AddForce(Away * 0.01f * MoveSpeed);
        }
        else if(y < b)
        {
            Vector2 Away = new Vector2(result_x, -result_y);
            bat.AddForce(Away * 0.01f * MoveSpeed);
        }
    }

    void Update()
    {

        Physics2D.IgnoreLayerCollision(11,12);
        if (MonsterType != Type.Flying)
        {
            Monster_flip();
        }


        if (Pause.pause == false)
            Chase();
    }


    void Chase()
    {
        switch (MonsterType)
        {
            case Type.Normal:
                transform.position //target ����
                    = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * 0.001f);
                break;

            case Type.Flying:

                GoAway();
                //bat.AddForce(wave * 0.01f);
                /*
                transform.position //target ����               
                    = Vector2.MoveTowards(transform.position, playerposition, MoveSpeed * 0.001f);
                */
                break;
        }
    }

    void OnHit(float dmg) //�ǰ� ��
    {
        HP -= dmg;

        GameObject hudText = Instantiate(hudDamageText); //������ �ؽ�Ʈ ���
        hudText.transform.position = this.transform.position;
        hudText.GetComponent<DamageText>().dmg = dmg;

        Debug.Log(this + " on damage! -" + dmg); //Log

        if (HP <= 0) //��� ��
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

    IEnumerator OnHitEffect() //�ǰ� �� �� ��ȭ
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
    void Monster_flip()
    {
        //sprite ����
        if (target.transform.position.x > transform.position.x)
            rend.flipX = true; //�����̵�
        else if (target.transform.position.x < transform.position.x)
            rend.flipX = false; //�����̵�
    }
    private void OnBecameInvisible() //ȭ�� ������ ������ ����
    {
        if (MonsterType == Type.Flying)
            Destroy(this.gameObject);
    }
}