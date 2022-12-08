using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game05Controller : MonoBehaviour
{
    Slider sliderHP;
    GameObject gCon;
    public int slider_minValue = 0, slider_maxValue = 30;

    float timer_map = 0.0f, timer_throw = 0.0f, timeLimit_throw = 1.0f;
    bool isGaming = false;
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

        tmp1 = GameObject.Find("tmp_message_1").GetComponent<TextMeshProUGUI>();
        tmp1.text = "0";
        tmp2 = GameObject.Find("tmp_message_2").GetComponent<TextMeshProUGUI>();
        tmp2.text = "0";
        tmp3 = GameObject.Find("tmp_message_3").GetComponent<TextMeshProUGUI>();
        tmp3.text = " ";

        //isGaming = true;
    }

    void Update()
    {
        //자동으로 물이 나가고 불에 닿으면 바가 깎임
        //다 깎으면 승리
        if (isGaming == true)
        {
            timer_throw += Time.deltaTime;
            if (timer_throw >= timeLimit_throw)
            {
                //Instantiate(col_ball);
                Instantiate(col_ball_temp);
                Debug.Log("instantiate");

                ++count_ball;
                tmp1.text = count_ball+"!";

                timer_throw = 0.0f;
            }

            if (sliderHP.value <= 0)
            {
                isGaming = false;
                sliderHP.value = 0;
                Debug.Log("cleared");
            }
        }
        else if (sliderHP.value <= 0 && !isGaming)
        {
            tmp3.text = "cleared";
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
        }

        Destroy(ball);

        ++count_false_ball;
        tmp2.text = count_false_ball + "?!";
    }

    public void startGame()
    {
        isGaming = true;
    }
}
