using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerLevel; //레벨
    public long Exp; //현재경험치
    public long maxExp; //최대경험치
    public int stageMeso; //메소


    public Image ExpBar; //경험치바

    void Start()
    {
        playerLevel = 1; //초기 레벨
        Exp = 0; //현재 경험치
        stageMeso = 0;

        maxExpRefresh(); //최대경험치 갱신
    }

    void Update()
    {
        ExpBar.fillAmount = (float)Exp / (float)maxExp;

        if (Exp >= maxExp) playerLevelUp(); //레벨업 시

        

    }

    void playerLevelUp()
    {
        long plusExp = 0; //초과경험치
        if (Exp > maxExp) plusExp = Exp - maxExp; //초과경험치 저장

        playerLevel++;
        Exp = 0 + plusExp;
        Debug.Log("Player Level Up! Level : " + playerLevel); //Log

        

        maxExpRefresh(); //최대경험치 갱신
        selectskill();
    }

    void maxExpRefresh()
    {
        //maxExp = (long)Mathf.Pow(1.4f, playerLevel - 1) * 10 + playerLevel * 10; (구)공식
        maxExp = (long) ((playerLevel + 2) * playerLevel * 10); //경험치 공식
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

        
           

        //타이머 멈추기 및 게임 멈추기
        //선택지 3개
        //고른 스킬 활성화, 강화
        //고른 이후 다시 게임 재개
    }
}
