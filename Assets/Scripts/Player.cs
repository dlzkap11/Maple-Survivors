using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MoveSpeed; //�̵��ӵ�
    public float maxHP; //�ִ�ü��
    public float HP; //ü��
    SpriteRenderer rend;//������

    public Image barSprite;

    void Start()
    {
        HP = maxHP; //ü�� �ʱ�ȭ
        rend = GetComponent<SpriteRenderer>();//������Ʈ
    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");   //����
        float vAxis = Input.GetAxisRaw("Vertical");     //����

        transform.Translate(new Vector2(hAxis, vAxis) * MoveSpeed * 0.001f);

        switch (hAxis)//�¿� �̹��� ����
        {
            case 1:
                rend.flipX = true;
                break;

            case -1:
                rend.flipX = false;
                break;
        }

        barSprite.fillAmount = HP / maxHP; //ü�� �ǽð� ����
    }
}
