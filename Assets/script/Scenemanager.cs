using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Scenemanager : SingletonMonoBehaviour<Scenemanager>
{
    /// <summary>FadeImage</summary>
    public Image FadeImage => _fadeImage;

    /// <summary>FadeImage</summary>
    [SerializeField]
    [Header("FadeImage")]
    Image _fadeImage;
    public void FadeStart(string scene)
    {
        _fadeImage.transform.DOMoveX(960, 1f)
            .OnComplete(() => SceneManager.LoadScene(scene));
    }
    public void FadeIn() => _fadeImage.transform.DOMoveX(-1000, 1f);
    
    void Start()
    {
        _fadeImage.transform.localPosition = new Vector3(0, 0, 0);
        FadeIn();
    }
}
