using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public Button[] btns = new Button[7];
    void Start()
    {
        
    }

    void Update()
    {
        //PlayerData.clearCount 체크해서 true인 것들은 완료 도장 찍기
        for (int i = 0; i < 7; ++i)
        {
            if (PlayerData.clearCount[i] == true)
            {
                btns[i].GetComponent<Image>().color = new Color(60, 60, 60);
                btns[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void startMission01()
    {
        PlayerData.curGameNum = 1;
    }

    public void startMission02()
    {
        PlayerData.curGameNum = 2;
    }

    public void startMission03()
    {
        PlayerData.curGameNum = 3;
    }

    public void startMission04()
    {
        PlayerData.curGameNum = 4;
    }

    public void startMission05()
    {
        PlayerData.curGameNum = 5;
    }

    public void startMission06()
    {
        PlayerData.curGameNum = 6;
    }

    public void startMission07()
    {
        PlayerData.curGameNum = 7;
    }
}
