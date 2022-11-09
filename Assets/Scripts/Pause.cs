using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool pause = false; //일시정지 상태확인

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(pause == false)
            {
                Time.timeScale = 0;
                pause = true;
            }
            else
            {
                Time.timeScale = 1;
                pause = false;
            }
        }
    }
}
