using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float plusHP; //HPȸ����
    public bool isFullPotion; //�Ŀ� ������ ����

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isFullPotion) //�Ŀ� ������
        {
            GameObject.Find("Player").GetComponent<Player>().HP =
                    GameObject.Find("Player").GetComponent<Player>().maxHP; //FullHP

            Destroy(gameObject);
            Debug.Log("Get PowerPotion!"); //Log
        }
            
        else if (collision.gameObject.tag == "Player")
        {
            float overPlus = GameObject.Find("Player").GetComponent<Player>().maxHP
                - GameObject.Find("Player").GetComponent<Player>().HP;

            if (overPlus < plusHP) plusHP = overPlus; //�ִ� ȸ����

            GameObject.Find("Player").GetComponent<Player>().HP += plusHP; //����ġ ����

            Destroy(gameObject);
            Debug.Log("Get HP : " + plusHP); //Log
        }
    }
}
