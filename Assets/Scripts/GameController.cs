using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int gameNum;
    public bool isScriptGoOn = false, gameStart = false;
    public GameObject panel_dialog, panel_game, gameBox;
    public Slider _slider_hp, _slider_st;
    float timer = 0.0f;

    void Start()
    {
        gameBox = GameObject.Find("GameBox");
        panel_dialog.SetActive(true);
        gameNum = 5;

    }

    void Update()
    {
        if (!isScriptGoOn)
        {
            panel_dialog.SetActive(false);
        }
        else
        {
            switch(panel_dialog.GetComponent<TypeWriterEffect>().speaker.text)
            {
                case "적":
                    //적 판넬 
                    break;
                case "슈리":
                    //
                    break;
                case "웬디":
                    break;
                case "유시":
                    break;
                default:
                    //공백, 상황 설명
                    break;
            }
        }

        if(gameStart)
        {
            gameStart = false;
            panel_game = gameBox.GetComponent<Transform>().GetChild(gameNum-1).gameObject;
            panel_game.SetActive(true);
        }
    }

    public Slider slider_hp() {
        return _slider_hp;
    }
    public Slider slider_st() {
        return _slider_st;
    }

    public void off_slider_hp()
    {
        _slider_hp.gameObject.SetActive(false);
    }
    public void off_slider_st()
    {
        _slider_st.gameObject.SetActive(false);
    }
}
