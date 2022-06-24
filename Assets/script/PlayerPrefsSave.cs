using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsSave : MonoBehaviour
{
    public void SettingBtn()
    {
        Scenemanager.Instance.FadeStart("StartScene");
        PlayerPrefs.Save();
    }
}
