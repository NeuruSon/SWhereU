using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWallController : MonoBehaviour
{
    public int hp = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }


}
