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
    public Image EXPBar;
    public GameObject LevelUpPanel;

    void Start()
    {
        playerLevel = 1; //�ʱ� ����
        Exp = 0; //���� ����ġ
        stageMeso = 0;
        LevelUpPanel.SetActive(false);

        maxExpRefresh(); //�ִ����ġ ����
    }

    void Update()
    {
        if (Exp >= maxExp) playerLevelUp(); //������ ��

        EXPBar.fillAmount = (float)Exp / (float)maxExp;
    }

    void playerLevelUp()
    {
        LevelUpPanel.SetActive(true);
        Input.GetKey(KeyCode.P);

        long plusExp = 0; //�ʰ�����ġ
        if (Exp > maxExp) plusExp = Exp - maxExp; //�ʰ�����ġ ����

        playerLevel++;
        Exp = 0 + plusExp;
        Debug.Log("Player Level Up! Level : " + playerLevel); //Log

        maxExpRefresh(); //�ִ����ġ ����
    }

    void maxExpRefresh()
    {
        //maxExp = (long)Mathf.Pow(1.4f, playerLevel - 1) * 10 + playerLevel * 10; (��)����
        maxExp = (long) ((playerLevel + 2) * playerLevel * 10); //����ġ ����
        Debug.Log("Max Exp Refresh! MaxExp : " + maxExp); //Log
    }
}
