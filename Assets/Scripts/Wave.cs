using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    GameObject target; //타겟(플레이어)
    SpriteRenderer rend;
    public GameObject expMarble; //경험치 구슬
    public GameObject hudDamageText; //데미지 텍스트

    public enum Type { Normal, Flying, None };
    public Type MonsterType;
    Rigidbody2D bat;
    Vector2 wave;
    Vector2 mypos;

    Color normalColor; //기본 색
    Color hitColor; //피격 시 색

    public float MoveSpeed; //이동속도
    public float damage; //공격력
    public float MaxHP; //최대체력
    public float HP; //현재체력
    private Vector3 playerposition;

    private void Awake()
    {
        bat = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        target = GameObject.FindWithTag("Player"); //Player 태그를 타겟으로 지정
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

       
        if(x > a && y > b)// 플레이어가 몬스터보다 오른쪽에 있을시
        {
            Vector2 Away = new Vector2(result_x, result_y);
            bat.AddForce(Away * 0.01f * MoveSpeed);
        }
        else if(y > b) //플레이어가 몬스터보다 위에 있을시
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
                transform.position //target 추적
                    = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * 0.001f);
                break;

            case Type.Flying:

                GoAway();
                //bat.AddForce(wave * 0.01f);
                /*
                transform.position //target 추적               
                    = Vector2.MoveTowards(transform.position, playerposition, MoveSpeed * 0.001f);
                */
                break;
        }
    }

    void OnHit(float dmg) //피격 시
    {
        HP -= dmg;

        GameObject hudText = Instantiate(hudDamageText); //데미지 텍스트 출력
        hudText.transform.position = this.transform.position;
        hudText.GetComponent<DamageText>().dmg = dmg;

        Debug.Log(this + " on damage! -" + dmg); //Log

        if (HP <= 0) //사망 시
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

    IEnumerator OnHitEffect() //피격 시 색 변화
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
    void Monster_flip()
    {
        //sprite 변경
        if (target.transform.position.x > transform.position.x)
            rend.flipX = true; //우측이동
        else if (target.transform.position.x < transform.position.x)
            rend.flipX = false; //좌측이동
    }
    private void OnBecameInvisible() //화면 밖으로 나가면 삭제
    {
        if (MonsterType == Type.Flying)
            Destroy(this.gameObject);
    }
}