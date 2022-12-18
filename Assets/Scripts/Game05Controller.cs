using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game05Controller : MonoBehaviour
{
    Slider sliderHP;
    GameObject gCon;
    public int slider_minValue = 0, slider_maxValue = 12;

    float timer_map = 0.0f, timer_throw = 0.0f, timeLimit_throw = 1.0f, timer_help = 0.0f;
    bool isGaming = false, isHelpNeed = true;
    public GameObject col_ball, col_ball_temp, col_fire1, col_fire2, col_fire3;

    TextMeshProUGUI tmp1, tmp2, tmp3; int count_ball = 0, count_false_ball = 0;

    void Start()
    {
        gCon = GameObject.Find("GameController");
        sliderHP = gCon.GetComponent<GameController>().slider_hp();
        gCon.GetComponent<GameController>().off_slider_st();
        sliderHP.value = slider_minValue;
        sliderHP.maxValue = slider_maxValue;
        sliderHP.value = slider_maxValue;

        tmp3 = GameObject.Find("tmp_message_3").GetComponent<TextMeshProUGUI>();
        tmp3.text = "주변을 천천히 둘러보며\n사각형 패널이 나타날 때까지 기다려주세요!";

        //isGaming = true;
    }

    void Update()
    {
        //자동으로 물이 나가고 불에 닿으면 바가 깎임
        if (isGaming == false)
        {
            timer_help += Time.deltaTime;

            if (timer_help >= 3.0f)
            {
                timer_help = 0.0f;

                if (isHelpNeed)
                {
                    tmp3.text = "바닥면을 인식한 사각형 패널이 나타났다면\n화면을 터치해주세요!";
                }
                else
                {
                    tmp3.text = "주변을 천천히 둘러보며\n사각형 패널이 나타날 때까지 기다려주세요!";
                }
                isHelpNeed = !isHelpNeed;
            }
        }

        //다 깎으면 승리
        else if (isGaming == true)
        {
            tmp3.text = "천천히 화면을 돌려\n불을 꺼 주세요!";
            timer_throw += Time.deltaTime;
            if (timer_throw >= timeLimit_throw)
            {
                Instantiate(col_ball);
                //Instantiate(col_ball_temp);
                Debug.Log("instantiate");

                ++count_ball;
                //tmp1.text = count_ball+"!";

                timer_throw = 0.0f;
            }

            if (sliderHP.value <= 0)
            {
                isGaming = false;
                sliderHP.value = 0;
                Debug.Log("cleared");

                gCon.GetComponent<GameController>().isGameCleared = true;
            }
        }
        else if (sliderHP.value <= 0 && !isGaming)
        {
            tmp3.text = " ";
            col_fire1.SetActive(false);
            col_fire2.SetActive(false);
            col_fire3.SetActive(false);
        }
    }

    public void crashed(bool b, GameObject ball, GameObject wall)
    {
        if (b)
        {
            --sliderHP.value;
            ++count_false_ball;
        }
        Destroy(ball);
        //tmp2.text = count_false_ball + "?!";
    }

    public void startGame()
    {
        isGaming = true;
    }
}
