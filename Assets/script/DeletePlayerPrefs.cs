using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DeletePlayerPrefs : MonoBehaviour
{
    /// <summary>ボタンを押したときに出てくるイメージ</summary>
    public Image DeleteImage => _dataDeleteImage;

    /// <summary>ボタンを押したときに出てくるイメージ</summary>
    [Header("ボタンを押したときに出てくるイメージ")]
    [SerializeField]
    Image _dataDeleteImage;

    public void DeleteData()
    {
        DeleteImage.transform.DOScale(new Vector3(1f, 1f), 1f)
            .SetEase(Ease.Linear);
    }
    public void YesButton()
    {
        CloseDO();
        PlayerPrefs.DeleteAll();
    }
    public void NoButton()
    {
        CloseDO();
    }
    public void CloseDO()
    {
        DeleteImage.transform.DOScale(new Vector3(0f, 0f), 1f)
            .SetEase(Ease.Linear);
    }
}
