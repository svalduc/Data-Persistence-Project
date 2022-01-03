using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text nameText;
    void Start()
    {
        
    }

    public void StartGame()
    {
        ScoreData.Instance.m_PlayerName = nameText.text;
        SceneManager.LoadScene(1);
    }
}
