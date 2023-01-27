using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public Player player;
    public int playerLevel; //레벨
    public long Exp; //현재경험치
    public long maxExp; //최대경험치
    public int stageMeso; //메소
    public Image EXPBar;
    public GameObject LevelUpPanel;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerLevel = 1; //초기 레벨
        Exp = 0; //현재 경험치
        stageMeso = 0;
        LevelUpPanel.SetActive(false);

        maxExpRefresh(); //최대경험치 갱신
    }

    void Update()
    {
        if (Exp >= maxExp) playerLevelUp(); //레벨업 시

        EXPBar.fillAmount = (float)Exp / (float)maxExp;
    }

    void playerLevelUp()
    {
        Time.timeScale = 0;
        Pause.pause = true;

        LevelUpPanel.SetActive(true);
 
        long plusExp = 0; //초과경험치
        if (Exp > maxExp) plusExp = Exp - maxExp; //초과경험치 저장

        playerLevel++;
        Exp = 0 + plusExp;
        Debug.Log("Player Level Up! Level : " + playerLevel); //Log

        maxExpRefresh(); //최대경험치 갱신
    }

    void maxExpRefresh()
    {
        //maxExp = (long)Mathf.Pow(1.4f, playerLevel - 1) * 10 + playerLevel * 10; (구)공식
        maxExp = (long) ((playerLevel + 2) * playerLevel * 10); //경험치 공식
        Debug.Log("Max Exp Refresh! MaxExp : " + maxExp); //Log
    }
}
