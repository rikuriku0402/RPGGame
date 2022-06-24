using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>コインテキスト</summary>
    public Text CoinText => coinText;

    /// <summary>経験値テキスト</summary>
    public Text ExpText => expText;

    /// <summary>経験値スライダー</summary>
    public Slider Slider => slider;

    /// <summary>ランクテキスト</summary>
    public Text RankText => _rankText;

    /// <summary>合計経験値</summary>
    public int Exp => _exp;

    /// <summary>合計コイン</summary>
    public int Coin => _coin;

    /// <summary>合計パワー</summary>
    public int Power => _power;

    /// <summary>ランクのカウント</summary>
    public int Count => _count;

    /// <summary>今のランク</summary>
    public int Rank => _rank;

    /// <summary>経験値バリューのMax</summary>
    public int ExpMaxValue => _maxValue;

    /// <summary>コインテキスト</summary>
    [Header("コインテキスト")]
    [SerializeField]
    Text coinText;

    /// <summary>経験値テキスト</summary>
    [Header("経験値テキスト")]
    [SerializeField]
    Text expText;

    /// <summary>経験値スライダー</summary>
    [Header("経験値スライダー")]
    [SerializeField]
    Slider slider;

    /// <summary>ランクテキスト</summary>
    [Header("ランクテキスト")]
    [SerializeField]
    Text _rankText;

    int _maxValue = 1000;
    //public List<int> _playerprefas = new List<int>();

    /// <summary>経験値</summary>
    int _exp;

    /// <summary>コイン</summary>
    int _coin;

    /// <summary>パワー</summary>
    int _power;

    /// <summary>ランクのカウント</summary>
    int _count;

    /// <summary>今のランク</summary>
    [Header("今のランク")]
    [SerializeField]
    int _rank;

    protected override void Awake()
    {
        _coin =  PlayerPrefs.GetInt("COIN");
        _exp = PlayerPrefs.GetInt("EXP");
    }
    void Start()
    {
        CoinText.text = Coin.ToString();
        RankText.text = "Rank:" + Rank.ToString();
        Slider.maxValue = ExpMaxValue;
        Slider.value = Exp;
        ExpText.text = Exp.ToString() + "/" + ExpMaxValue.ToString();

        #region レベルアップの処理
        if (Slider.value < (float)Exp)
        {
            LevelUp();
        }
        else
        {
            Debug.Log("経験値が足りないよ");
        }
        #endregion
        if (_coin <= 0)
        {
            Debug.Log("金がねーぞ！");
            _coin = 0;
            CoinText.text = _coin.ToString();
        }
        Debug.Log(Coin);
        Debug.Log(Exp);
        Debug.Log(Power);
    }
    public void LevelUp()
    {
        RankText.text = "Rank:" + _rank++.ToString();

        Slider.maxValue = _maxValue += 2000;
        Slider.value = 0;
        Slider.value = _exp;
        ExpText.text = Exp.ToString() + "/" + _maxValue.ToString();
        Debug.Log("LevelUpしたよ");
        if (Slider.value < (float)Exp)
        {
            LevelUp();
        }
    }

    public int TotalExp(int exp) => _exp = exp;
    public int TotalCoin(int coin) => _coin = coin;
    public int TotalPower(int power) => _power = power;
}
