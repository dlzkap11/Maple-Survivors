using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target; //타겟(플레이어)
    SpriteRenderer rend;
    public GameObject expMarble; //경험치 구슬

    Color normalColor; //기본 색
    Color hitColor; //피격 시 색

    public float MoveSpeed; //이동속도
    public static float damage; //공격력
    public float MaxHP; //최대체력
    public float HP; //현재체력

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        target = GameObject.FindWithTag("Player"); //Player 태그를 타겟으로 지정
        HP = MaxHP;

        damage = 10; //초기 공격력 (후에 변경)

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

    void OnHit(float dmg) //피격 시
    {
        HP -= dmg;
        Debug.Log(this + " on damage! -" + dmg); //Log

        if(HP <= 0) //사망 시
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

    IEnumerator OnHitEffect () //피격 시 색 변화
    {
        rend.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        rend.color = normalColor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet") //PlayerBullet에 닿을 시
        {
            NormalBullet bullet = collision.gameObject.GetComponent<NormalBullet>();
            OnHit(bullet.dmg);
        }
    }

    void dropObj() //드랍(경험치/메소)
    {
        //경험치(확정)
        Instantiate(expMarble, transform.position, Quaternion.identity);

        //메소(확률)
        /*개인적인 아이디어로 rand % 100하면 0~99 나오잖아.
          그럼 확률을 20% 이하로 하고싶다고 가정한다면
          rand해서 나온 값 >= 19 하면 20퍼센트가 속하는 부분이고
          나머지는 80퍼센트라서 이렇게 구성해도 괜찮을 것 같다.*/
    }
}


