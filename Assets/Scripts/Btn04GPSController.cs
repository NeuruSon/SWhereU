using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn04GPSController : MonoBehaviour
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
        else {
            if (PlayerData.curLati <= 37.62929015540708 && PlayerData.curLati >= 37.62927146926622)
            {
                isInLati = true;
            }
            else
            {
                isInLati = false;
            }

            if (PlayerData.curLongi <= 127.08900839354453 && PlayerData.curLongi >= 127.0888649095582)
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
