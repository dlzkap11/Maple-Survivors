using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float plusHP; //HP회복량
    public bool isFullPotion; //파워 엘릭서 여부

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isFullPotion) //파워 엘릭서
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

            if (overPlus < plusHP) plusHP = overPlus; //최대 회복량

            GameObject.Find("Player").GetComponent<Player>().HP += plusHP; //경험치 증가

            Destroy(gameObject);
            Debug.Log("Get HP : " + plusHP); //Log
        }
    }
}
