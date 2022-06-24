using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartGame : MonoBehaviour
{
    /// <summary>���[�������C���[�W</summary>
    public Image RuleImage  => _ruleImage;

    /// <summary>���[�������C���[�W</summary>
    [Header("���[�������C���[�W")]
    [SerializeField]
    Image _ruleImage;
    public void GameStart(string scene)
    {
        this.transform.DOScale(new Vector3(1.2f,1.2f), 1f)
            .SetEase(Ease.OutBounce)
            .OnComplete (() => Scenemanager.Instance.FadeStart(scene));
    }
    public void RuleOpen()
    {
        RuleImage.transform.DOScale(new Vector3(1.0f, 1.0f), 1f)
            .SetEase(Ease.Linear);
    }
    public void RuleClose()
    {
        RuleImage.transform.DOScale(new Vector3(0f, 0f), 1f)
            .SetEase(Ease.Linear);
    }
}
