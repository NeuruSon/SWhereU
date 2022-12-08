using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Slider _slider_hp, _slider_st;
    float timer = 0.0f;

    void Start()
    {
    }

    void Update()
    {

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
