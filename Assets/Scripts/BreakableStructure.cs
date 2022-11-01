using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStructure : MonoBehaviour
{
    public GameObject[] item; //����ǰ
    public float HP;
    
    void OnHit(float dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            Destroy(gameObject);
            dropItem(); //����ǰ ���
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

    void dropItem() //����� �׽�Ʈ�� expMarble�� ����
    {
        int random_item = (int)Random.Range(0, item.Length);

        Instantiate(item[random_item], transform.position, Quaternion.identity);
        Debug.Log("Drop Item : " + item[random_item]);
        random_item = 0; //�ʱ�ȭ
    }
}
