using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public GameObject LevelUpPanel;

    public void OnClickChoice()
    {
        Time.timeScale = 1;
        Pause.pause = false;
        LevelUpPanel.SetActive(false);
    }
}
