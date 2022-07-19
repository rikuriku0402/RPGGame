using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoText : MonoBehaviour
{
    /// <summary>メッセージテキスト</summary>
    public Text TalkText => _talkText;

    /// <summary>メッセージ配列</summary>
    public List <string> Message => message;


    /// <summary>メッセージテキスト</summary>
    [Header("メッセージテキスト")]
    [SerializeField]
    private Text _talkText;

    /// <summary>メッセージ配列</summary>
    [Header("メッセージ配列")]
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
