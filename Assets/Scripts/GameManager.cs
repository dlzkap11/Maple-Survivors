using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerLevel; //����
    public int Exp; //�������ġ
    public int maxExp; //�ִ����ġ
    public int stageMeso; //�޼�

    void Start()
    {
        playerLevel = 1; //�ʱ� ����
        Exp = 0; //���� ����ġ
        stageMeso = 0;

        maxExpRefresh(); //�ִ����ġ ����
    }

    void Update()
    {
        if (Exp >= maxExp) playerLevelUp(); //������ ��
    }

    void playerLevelUp()
    {
        int plusExp = 0; //�ʰ�����ġ
        if (Exp > maxExp) plusExp = Exp - maxExp; //�ʰ�����ġ ����

        playerLevel++;
        Exp = 0 + plusExp;
        Debug.Log("Player Level Up! Level : " + playerLevel); //Log
        
        maxExpRefresh(); //�ִ����ġ ����
    }

    void maxExpRefresh()
    {
        maxExp = (int)Mathf.Pow(1.4f, playerLevel - 1) * 10 + playerLevel * 10; //����ġ ����
        Debug.Log("Max Exp Refresh! MaxExp : " + maxExp); //Log
    }
}
