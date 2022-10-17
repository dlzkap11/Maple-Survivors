using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    SpriteRenderer rend;

    public float MoveSpeed; //이동속도
    public float maxHP; //최대체력
    public float HP; //체력
    public float damage; //공격력
    public float invincibleTime; //무적시간

    public GameObject Bullet; //총알
    public bool IsShoot = true;
    float shootTimer = 0;
    float shootDelay = 1.0f; //공격 딜레이

    private Vector3 lastMoveDir = Vector3.right;

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
                
        Shoot();
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

        if (hAxis != 0 || vAxis != 0)
        {
            lastMoveDir = new Vector3(hAxis, vAxis, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") //Enemy에게 피격 시
        {
            OnDamaged();
        }
    }

    void OnDamaged()
    {
        gameObject.layer = 3; // layer = Invincible
        HP -= Enemy.damage;
        rend.color = Color.red; //피격시 색상변화

        Debug.Log("Player on damage! -" + Enemy.damage + "."); //Log

        Invoke("OffDamaged", invincibleTime); //무적시간
    }

    void OffDamaged()
    {
        gameObject.layer = 6; // layer = Player
        rend.color = Color.white;
    }

    void Shoot()
    { 
        if (IsShoot)
        {
            if (shootTimer > shootDelay)
            {
                GameObject a = Instantiate(Bullet, transform.position, Quaternion.identity);
                a.GetComponent<NormalBullet>().setDir(lastMoveDir);
                
                shootTimer = 0;
            }
            shootTimer += Time.deltaTime;
        }
    }

}
