using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerLevel; //����
    public long Exp; //�������ġ
    public long maxExp; //�ִ����ġ
    public int stageMeso; //�޼�


    public Image ExpBar; //����ġ��

    void Start()
    {
        playerLevel = 1; //�ʱ� ����
        Exp = 0; //���� ����ġ
        stageMeso = 0;

        maxExpRefresh(); //�ִ����ġ ����
    }

    void Update()
    {
        ExpBar.fillAmount = (float)Exp / (float)maxExp;

        if (Exp >= maxExp) playerLevelUp(); //������ ��

        

    }

    void playerLevelUp()
    {
        long plusExp = 0; //�ʰ�����ġ
        if (Exp > maxExp) plusExp = Exp - maxExp; //�ʰ�����ġ ����

        playerLevel++;
        Exp = 0 + plusExp;
        Debug.Log("Player Level Up! Level : " + playerLevel); //Log

        

        maxExpRefresh(); //�ִ����ġ ����
        selectskill();
    }

    void maxExpRefresh()
    {
        //maxExp = (long)Mathf.Pow(1.4f, playerLevel - 1) * 10 + playerLevel * 10; (��)����
        maxExp = (long) ((playerLevel + 2) * playerLevel * 10); //����ġ ����
        Debug.Log("Max Exp Refresh! MaxExp : " + maxExp); //Log
    }

    void selectskill()
    {
        //bool selectpause = Pause.pause;
        Pause.pause = true;
        Time.timeScale = 0;

           
        if (Input.GetKeyDown(KeyCode.K))        
        {          
            Pause.pause = false;            
            Time.timeScale = 1;                   
        }

        
           

        //Ÿ�̸� ���߱� �� ���� ���߱�
        //������ 3��
        //�� ��ų Ȱ��ȭ, ��ȭ
        //�� ���� �ٽ� ���� �簳
    }
}
