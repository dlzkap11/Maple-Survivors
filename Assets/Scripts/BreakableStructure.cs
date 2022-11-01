using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStructure : MonoBehaviour
{
    public GameObject[] item; //전리품
    public float HP;
    
    void OnHit(float dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            Destroy(gameObject);
            dropItem(); //전리품 드랍
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            NormalBullet bullet = collision.gameObject.GetComponent<NormalBullet>();
            OnHit(bullet.dmg);
        }
    }

    void dropItem() //현재는 테스트로 expMarble이 나옴
    {
        int random_item = (int)Random.Range(0, item.Length);

        Instantiate(item[random_item], transform.position, Quaternion.identity);
        Debug.Log("Drop Item : " + item[random_item]);
        random_item = 0; //초기화
    }
}
