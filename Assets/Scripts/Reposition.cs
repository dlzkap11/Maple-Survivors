using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 mypos = transform.position;

        /*
        float diffx = Mathf.Abs(playerPos.x - mypos.x); //절대값
        float diffy = Mathf.Abs(playerPos.y - mypos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;

        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        */

        float dirX = playerPos.x - mypos.x;
        float dirY = playerPos.y - mypos.y;

        float diffx = Mathf.Abs(dirX);
        float diffy = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground":
                if (Mathf.Abs(diffx - diffy) <= 0.1f || diffx == diffy)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                    transform.Translate(Vector3.up * dirY * 40);
                    Debug.Log("대각선 이동: x = " + diffx + ", y = " + diffy);
                }
                else if (diffx > diffy)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                    Debug.Log("x축이동: x = " + diffx + ", y = " + diffy);
                }
                else if (diffx < diffy)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                    Debug.Log("y축이동: x = " + diffx + ", y = " + diffy);
                }
                break;
        }

    }
    void Start()
    {
        
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
