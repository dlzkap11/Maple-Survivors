using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    SpriteRenderer rend;

    public float MoveSpeed; //�̵��ӵ�
    public float maxHP; //�ִ�ü��
    public float HP; //ü��
    public float damage; //���ݷ�
    
    public Image barSprite; //ü�¹�

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        HP = maxHP; //ü�� �ʱ�ȭ
    }

    void Update()
    {
        Move();

        barSprite.fillAmount = HP / maxHP; //ü�� �ǽð� ����
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");   //����
        float vAxis = Input.GetAxisRaw("Vertical");     //����

        transform.Translate(new Vector2(hAxis, vAxis) * MoveSpeed * 0.001f);

        switch (hAxis) //sprite ����
        {
            case 1:
                rend.flipX = true; //�����̵�
                break;

            case -1:
                rend.flipX = false; //�����̵�
                break;
        }
    }
}
