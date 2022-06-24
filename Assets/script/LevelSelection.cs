using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    /// <summary>レベルボタン</summary>
    public Button[] LvlButtons { get => lvlButtons; set => lvlButtons = value; }
    
    /// <summary>レベルボタン</summary>
    [Header("レベルボタン")]
    [SerializeField]
    Button[] lvlButtons;


    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < LvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                LvlButtons[i].interactable = false;
            }
        }
    }
    public void Stage1()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("Scene3");
    }
    public void Stage4()
    {
        SceneManager.LoadScene("Scene4");
    }
}
