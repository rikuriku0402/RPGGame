using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    /// <summary>HomeImage</summary>
    public Image HomeImage { get => homeImage; set => homeImage = value; }

    /// <summary>HomeImage</summary>
    [Header("HomeImage")]
    [SerializeField]
    Image homeImage;


    //[SerializeField] Scenemanager _sceneManager;
    public void HomeBtn()
    {
        HomeImage.transform.DOScale(new Vector3(1f, 1f, 1f), 1f)
            .SetEase(Ease.Linear);
    }
    public void YesBtn(string scene)
    {
        Scenemanager.Instance.FadeStart(scene);
        //PlayerPrefs.GetInt("COIN",0);
        //PlayerPrefs.GetInt("EXP",0);
        PlayerPrefs.Save();
        //BattleManager.battleInstance.coinScore = 0;
        //BattleManager.battleInstance.expScore = 0;
    }
    public void NoBtn()
    {
        HomeImage.transform.DOScale(new Vector3(1f, 1f, 1f), 1f)
            .SetEase(Ease.Linear);
    }
}