using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TypeWriterEffect : MonoBehaviour
{
    public GameObject gCon;
    public TextMeshProUGUI scriptT, speaker;

    //변경할 변수
	public float delay;
    public float Skip_delay;
    public int cnt;

    //타이핑효과 변수
    public string[] fulltext;
    public List<string> spk;
    public static string[] dialogues;
    public int dialog_cnt;

    //타이핑확인 변수
    public bool text_exit;
    public bool text_full;
    public bool text_cut;

    //시작과 동시에 타이핑시작
    void Start()
    {
        Debug.Log(gCon.GetComponent<GameController>().gameNum);
        switch (gCon.GetComponent<GameController>().gameNum)
        {
            case 0:
                fulltext = ScriptData.home;
                dialogues = fulltext;
                break;
            case 1:
                fulltext = ScriptData.game1;
                dialogues = fulltext;
                break;
            case 2:
                fulltext = ScriptData.game2;
                dialogues = fulltext;
                break;
            case 3:
                fulltext = ScriptData.game3;
                dialogues = fulltext;
                break;
            case 4:
                fulltext = ScriptData.game4;
                dialogues = fulltext;
                break;
            case 5:
                fulltext = ScriptData.game5;
                dialogues = fulltext;
                break;
            case 6:
                fulltext = ScriptData.game6;
                dialogues = fulltext;
                break;
            case 7:
                fulltext = ScriptData.game7;
                dialogues = fulltext;
                break;
            case 8:
                fulltext = ScriptData.ending;
                dialogues = fulltext;
                break;
        }

        dialog_cnt = fulltext.Length;
        Debug.Log("first: " + dialog_cnt);
        ParseSnD(fulltext);
        Get_Typing(dialog_cnt, dialogues);
    }


    //모든 텍스트 호출완료시 탈출
    void Update()
    {
        if(text_exit==true)
        {
            gCon.GetComponent<GameController>().isScriptGoOn = false;
            gCon.GetComponent<GameController>().gameStart = true;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) //터치 시작만을 기준점으로 잡아 홀드 방지. 
            {
                End_Typing();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            End_Typing();
        }
    }

    //다음버튼함수
    public void End_Typing()
    {
        //다음 텍스트 호출
        if (text_full == true)
        {
            cnt++;
            text_full = false;
            text_cut = false;
            StartCoroutine(ShowText(fulltext));
        }
        //텍스트 타이핑 생략
        else
        {
            text_cut = true;
        }
    }

    //텍스트 시작호출
    public void Get_Typing(int _dialog_cnt, string[] _fullText)
    {
        //재사용을 위한 변수초기화
        text_exit = false;
        text_full = false;
        text_cut = false;
        cnt = 0;

        //변수 불러오기
        dialog_cnt = _fullText.Length;
        //타이핑 코루틴시작
        StartCoroutine(ShowText(_fullText));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        //모든텍스트 종료
        if (cnt >= dialog_cnt)
        {
            text_exit = true;
            StopCoroutine("showText");
        }
        else
        {
            speaker.text = spk[cnt];
            //타이핑 시작
            for (int i = 0; i < _fullText[cnt].Length; i++)
            {
                //타이핑중도탈출
                if (text_cut == true)
                {
                    break;
                }
                //단어하나씩출력
                scriptT.text = changeScript(_fullText[cnt].Substring(0, i + 1));
                yield return new WaitForSeconds(delay);
            }
            //탈출시 모든 문자출력
            Debug.Log("Typing 종료");
            scriptT.text = changeScript(_fullText[cnt]);
            yield return new WaitForSeconds(Skip_delay);

            //스킵_지연후 종료
            Debug.Log("Enter 대기");
            text_full = true;
        }
    }

    string changeScript(string s)
    {
        Debug.Log("교체");
        s = s.Replace("-", "\n"); //줄바꿈.
        return s;
    }

    void ParseSnD(string[] _fullText)
    {
        Debug.Log(_fullText.Length);
        for (int i = 0; i < _fullText.Length; ++i)
        {
            string[] temp;
            temp = _fullText[i].Split(": ");
            spk.Add(temp[0]);
            dialogues[i] = temp[1] + "";
        }
    }
}
