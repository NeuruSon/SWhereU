using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn05GPSController : MonoBehaviour
{
    bool isInLati = false, isInLongi = false;

    void Start()
    {

    }

    void Update()
    {
        if (PlayerData.isGPSOn == false)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            if (PlayerData.curLati <= 37.629659308079674 && PlayerData.curLati >= 37.628855831686955)
            {
                isInLati = true;
            }
            else
            {
                isInLati = false;
            }

            if (PlayerData.curLongi <= 127.08888402645509 && PlayerData.curLongi >= 127.09098166571158)
            {
                isInLongi = true;
            }
            else
            {
                isInLongi = false;
            }

            if (isInLati && isInLongi)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }
}
