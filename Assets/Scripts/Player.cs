using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    SpriteRenderer rend;

    public float MoveSpeed; //이동속도
    public float maxHP; //최대체력
    public float HP; //체력
    public float damage; //공격력
    
    public Image barSprite; //체력바

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        HP = maxHP; //체력 초기화
    }

    void Update()
    {
        Move();

        barSprite.fillAmount = HP / maxHP; //체력 실시간 적용
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");   //가로
        float vAxis = Input.GetAxisRaw("Vertical");     //세로

        transform.Translate(new Vector2(hAxis, vAxis) * MoveSpeed * 0.001f);

        switch (hAxis) //sprite 변경
        {
            case 1:
                rend.flipX = true; //우측이동
                break;

            case -1:
                rend.flipX = false; //좌측이동
                break;
        }
    }
}
