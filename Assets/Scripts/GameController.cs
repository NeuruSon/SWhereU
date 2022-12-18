using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int gameNum;
    public bool isScriptGoOn = false, gameHintOn = false,
        gameStart = false, isGameCleared = false;
    //아예 게임 자체가 클리어 여부를 bool로 반환하는 함수라면... 
    public GameObject img_s, panel_speaker, panel_dialog, gameBox, hintBox, panel_clear, _tempCam;
    public Sprite img_s_bg, img_e_bg, img_u_bg, img_n_bg, img_swuri, img_usi, img_enemy, img_none;
    GameObject panel_game, panel_hint;
    public Slider _slider_hp, _slider_st;
    float timer = 0.0f;

    void Start()
    {
        if (PlayerData.isSoundOn == false)
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }

        gameBox = GameObject.Find("GameBox");
        panel_dialog.SetActive(true);
        panel_clear.SetActive(false);
        gameNum = PlayerData.curGameNum;
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
                    panel_speaker.GetComponent<Image>().sprite = img_e_bg;
                    img_s.GetComponent<Image>().sprite = img_enemy;
                    break;
                case "슈리":
                    panel_speaker.GetComponent<Image>().sprite = img_s_bg;
                    img_s.GetComponent<Image>().sprite = img_swuri;
                    break;
                case "웬디":
                    break;
                case "유시":
                    panel_speaker.GetComponent<Image>().sprite = img_u_bg;
                    img_s.GetComponent<Image>().sprite = img_usi;
                    break;
                default:
                    //공백, 상황 설명
                    panel_speaker.GetComponent<Image>().sprite = img_n_bg;
                    img_s.GetComponent<Image>().sprite = img_none;
                    break;
            }
        }

        if (gameHintOn)
        {
            gameHintOn = false;
            panel_hint = hintBox.GetComponent<Transform>().GetChild(gameNum - 1).gameObject;
            panel_hint.SetActive(true);
        }
        if (gameStart)
        {
            gameStart = false;
            _tempCam.SetActive(false);
            panel_game = gameBox.GetComponent<Transform>().GetChild(gameNum - 1).gameObject;
            panel_game.SetActive(true);
        }
        if (isGameCleared)
        {
            isGameCleared = false;
            PlayerData.clearCount[gameNum - 1] = true;
            panel_clear.SetActive(true);
            panel_clear.GetComponent<Transform>().GetChild(gameNum - 4).gameObject.SetActive(true);
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

    public void startGame()
    {
        panel_hint.SetActive(false);
        gameStart = true;
    }

    public void Sound()
    {
        if (PlayerData.isSoundOn)
        {
            PlayerData.isSoundOn = false;
            gameObject.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            PlayerData.isSoundOn = true;
            gameObject.GetComponent<AudioSource>().mute = false;
        }
    }
}
