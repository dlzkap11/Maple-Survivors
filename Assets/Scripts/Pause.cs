using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool pause = false; //�Ͻ����� ����Ȯ��

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
