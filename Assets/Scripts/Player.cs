using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    SpriteRenderer rend;

    public Vector2 inputVec;

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

    public GameObject[] Weapons; //무기

    Animator anim;
    Collider2D coll;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        HP = maxHP; //체력 초기화
    }

    void Update()
    {
        if(Pause.pause == false)
        Move();

        barSprite.fillAmount = HP / maxHP; //체력 실시간 적용
                
        Shoot();

    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");   //가로
        float vAxis = Input.GetAxisRaw("Vertical");     //세로

        transform.Translate(new Vector2(hAxis, vAxis) * MoveSpeed * 0.001f);

        if (hAxis == 0 && vAxis == 0)   //움직임 애니메이션
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

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
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            OnDamaged(enemy.damage);
           
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Wave Enemy"))
            return;
        switch (transform.tag)          
        {              
            case "Player":                
                Wave w_enemy = collision.gameObject.GetComponent<Wave>();                 
                OnDamaged(w_enemy.damage);                
                break;    
        }       
    }
    void OnDamaged(float dmg)
    {
        gameObject.layer = 3; // layer = Invincible
        HP -= dmg;
        rend.color = Color.red; //피격시 색상변화

        Debug.Log("Player on damage! -" + dmg + "."); //Log

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
