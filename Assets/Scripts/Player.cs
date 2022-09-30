using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MoveSpeed; //이동속도
    public float maxHP; //최대체력
    public float HP; //체력
    SpriteRenderer rend;//렌더링

    public Image barSprite;

    void Start()
    {
        HP = maxHP; //체력 초기화
        rend = GetComponent<SpriteRenderer>();//컴포넌트
    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");   //가로
        float vAxis = Input.GetAxisRaw("Vertical");     //세로

        transform.Translate(new Vector2(hAxis, vAxis) * MoveSpeed * 0.001f);

        switch (hAxis)//좌우 이미지 반전
        {
            case 1:
                rend.flipX = true;
                break;

            case -1:
                rend.flipX = false;
                break;
        }

        barSprite.fillAmount = HP / maxHP; //체력 실시간 적용
    }
}
