using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    void Start()
    {
    }

    public void toGameScene() {
        SceneManager.LoadScene("GameScene");
    }
}
