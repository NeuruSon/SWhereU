using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorTextController : MonoBehaviour
{
    bool isOK = false;
    float spd_alpha = 4.0f, timer_destroy = 5.0f;
    TextMeshProUGUI text;
    Color alpha;

    void Start()
    {
        gameObject.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        text = GetComponent<TextMeshProUGUI>();
        alpha = text.color;
        gameObject.GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(0, -841, 0), new Quaternion(0,0,0,0));
        Invoke("Dec_alpha", 3.0f);
        Invoke("Delete", timer_destroy);
    }

    void Update()
    {
        if (isOK)
        {
            alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * spd_alpha);
            text.color = alpha;
        }
    }

    void Delete()
    {
        Destroy(gameObject);
    }

    void Dec_alpha()
    {
        isOK = true;
    }
}
