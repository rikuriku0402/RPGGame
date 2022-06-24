using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoText : MonoBehaviour
{
    /// <summary>���b�Z�[�W�e�L�X�g</summary>
    public Text TalkText => _talkText;

    /// <summary>���b�Z�[�W�z��</summary>
    public List <string> Message => message;


    /// <summary>���b�Z�[�W�e�L�X�g</summary>
    [Header("���b�Z�[�W�e�L�X�g")]
    [SerializeField]
    private Text _talkText;

    /// <summary>���b�Z�[�W�z��</summary>
    [Header("���b�Z�[�W�z��")]
    [SerializeField]
    List <string> message = new List<string>();

    int _index = 0;

    int _count = 0;

    const float TIME = 3;
    void Start()
    {
        StartCoroutine(TextMessage());
    }
    IEnumerator TextMessage()
    {
        _count = 0;
        _index = 0;
        while (_count < 6)
        {
            TalkText.DOText(Message[_index++], 2f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(TIME);
            TalkText.text = "";
            ++_count;
        }
        StartCoroutine(TextMessage());
    }
}
