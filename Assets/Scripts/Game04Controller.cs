using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game04Controller : MonoBehaviour
{
    Slider sliderHP;
    GameObject gCon;
    public int slider_minValue = 0, wall_maxValue = 20;

    float timer_map = 0.0f, timer_throw = 0.0f, timeLimit_throw = 0.5f;
    bool isGaming = false;
    public GameObject col_ball, wall_0, wall_1, wall_2, wall_3, wall_4, wall_5;

    TextMeshProUGUI tmp1, tmp2, tmp3; int count_ball = 0, count_false_ball = 0;

    void Start()
    {
        wall_0.GetComponent<ColliderWallController>().hp = wall_maxValue;
        wall_1.GetComponent<ColliderWallController>().hp = wall_maxValue;
        wall_2.GetComponent<ColliderWallController>().hp = wall_maxValue;
        wall_3.GetComponent<ColliderWallController>().hp = wall_maxValue;
        wall_4.GetComponent<ColliderWallController>().hp = wall_maxValue;
        wall_5.GetComponent<ColliderWallController>().hp = wall_maxValue;

        gCon = GameObject.Find("GameController");
        sliderHP = gCon.GetComponent<GameController>().slider_hp();
        gCon.GetComponent<GameController>().off_slider_st();
        sliderHP.value = slider_minValue;
        sliderHP.maxValue = sliderHP.value = wall_0.GetComponent<ColliderWallController>().hp
                + wall_1.GetComponent<ColliderWallController>().hp
                + wall_2.GetComponent<ColliderWallController>().hp
                + wall_3.GetComponent<ColliderWallController>().hp
                + wall_4.GetComponent<ColliderWallController>().hp
                + wall_5.GetComponent<ColliderWallController>().hp;
        sliderHP.value = sliderHP.value = wall_0.GetComponent<ColliderWallController>().hp
                + wall_1.GetComponent<ColliderWallController>().hp
                + wall_2.GetComponent<ColliderWallController>().hp
                + wall_3.GetComponent<ColliderWallController>().hp
                + wall_4.GetComponent<ColliderWallController>().hp
                + wall_5.GetComponent<ColliderWallController>().hp;

        tmp1 = GameObject.Find("tmp_message_1").GetComponent<TextMeshProUGUI>();
        tmp1.text = "0";
        tmp2 = GameObject.Find("tmp_message_2").GetComponent<TextMeshProUGUI>();
        tmp2.text = "0";
        tmp3 = GameObject.Find("tmp_message_3").GetComponent<TextMeshProUGUI>();
        tmp3.text = " ";


        startGame();
    }

    void Update()
    {
        //터치하면 공이 나가고 HP 다 깎으면 벽 깨짐 
        //다 깎으면 승리
        if (isGaming == true)
        {
            timer_throw += Time.deltaTime;

            if (timer_throw >= timeLimit_throw && Input.touchCount >= 1)
            {
                Instantiate(col_ball);
                Debug.Log("instantiate");

                ++count_ball;
                tmp1.text = count_ball + "!";
                timer_throw = 0.0f;
            }

            if (sliderHP.value <= 0)
            {
                isGaming = false;
                sliderHP.value = 0;
                Debug.Log("cleared");
                tmp3.text = "cleared";
            }
        }

    }

    public void crashed(bool b, GameObject ball, GameObject wall)
    {
        if (b)
        {
            --wall.GetComponent<ColliderWallController>().hp;
            sliderHP.value = wall_0.GetComponent<ColliderWallController>().hp
                + wall_1.GetComponent<ColliderWallController>().hp
                + wall_2.GetComponent<ColliderWallController>().hp
                + wall_3.GetComponent<ColliderWallController>().hp
                + wall_4.GetComponent<ColliderWallController>().hp
                + wall_5.GetComponent<ColliderWallController>().hp;

            ++count_false_ball;
            tmp2.text = count_false_ball + "?!";
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<Transform>().SetParent(wall.GetComponent<Transform>());
        }
        else
        {
            Destroy(ball);
        }
    }

    public void startGame()
    {
        isGaming = true;

        tmp3.text = "아직 벽이 남아있어요!";
    }
}
