using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DotWeen : MonoBehaviour
{
    /// <summary>クリックされたときに出るImage</summary>
    public Image Image => _image;

    /// <summary>
    /// <para>0,Mission</para>
    /// <para>1,Quest</para>
    /// <para>2,Event</para>
    /// <para>3,PresentBtn</para>
    /// <para>4,MailBtn</para>
    /// <para>5,SettingBtn</para>
    /// </summary>
    public Button[] Button => _button;

    /// <summary>クリックされたときに出るImage</summary>
    [Header("クリックされたときに出るImage")]
    [SerializeField]
    Image _image;


    /// <summary>
    /// <para>0,Mission</para>
    /// <para>1,Quest</para>
    /// <para>2,Event</para>
    /// <para>3,PresentBtn</para>
    /// <para>4,MailBtn</para>
    /// <para>5,SettingBtn</para>
    /// </summary>
    [Header("0,Mission")]
    [Header("1,Quest")]
    [Header("2,Event")]
    [Header("3,PresentBtn")]
    [Header("4,MailBtn")]
    [Header("5,SettingBtn")]
    [SerializeField]
    Button[] _button;

    void Start() => this.transform.localScale = new Vector3(0f, 0f, 0f);
    
    public void MissionBtn()
    {
        Image.transform.DOScale(new Vector3(1f, 1f, 1f), 1f)
            .SetEase(Ease.Linear);
        Button[1].interactable = false;
        Button[2].interactable = false;
        Button[3].interactable = false;
        Button[4].interactable = false;
        Button[5].interactable = false;
    }
    public void Quest()
    {
        Image.transform.DOScale(new Vector3(1f, 1f, 1f), 1f)
            .SetEase(Ease.Linear);
        Button[0].interactable = false;
        Button[2].interactable = false;
        Button[3].interactable = false;
        Button[4].interactable = false;
        Button[5].interactable = false;
    }
    public void Event()
    {
        Image.transform.DOScale(new Vector3(1f, 1f, 1f), 1f)
            .SetEase(Ease.Linear);
        Button[0].interactable = false;
        Button[1].interactable = false;
        Button[3].interactable = false;
        Button[4].interactable = false;
        Button[5].interactable = false;
    }
    public void PresentBox()
    {
        Image.transform.DOScale(new Vector3(1f, 1f, 1f), 1f)
            .SetEase(Ease.Linear);
        Button[0].interactable = false;
        Button[1].interactable = false;
        Button[2].interactable = false;
        Button[4].interactable = false;
        Button[5].interactable = false;
    }
    public void MailBox()
    {
        Image.transform.DOScale(new Vector3(1f, 1f, 1f), 1f)
            .SetEase(Ease.Linear);
        Button[0].interactable = false;
        Button[1].interactable = false;
        Button[2].interactable = false;
        Button[3].interactable = false;
        Button[5].interactable = false;
    }
    public void CloseBtn()
    {
        Image.transform.DOScale(new Vector3(0f, 0f, 0f), 1f)
            .SetEase(Ease.Linear);
        Button[0].interactable = true;
        Button[1].interactable = true;
        Button[2].interactable = true;
        Button[3].interactable = true;
        Button[4].interactable = true;
        Button[5].interactable = true;
    }
}
