using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>�R�C���e�L�X�g</summary>
    public Text CoinText => coinText;

    /// <summary>�o���l�e�L�X�g</summary>
    public Text ExpText => expText;

    /// <summary>�o���l�X���C�_�[</summary>
    public Slider Slider => slider;

    /// <summary>�����N�e�L�X�g</summary>
    public Text RankText => _rankText;

    /// <summary>���v�o���l</summary>
    public int Exp => _exp;

    /// <summary>���v�R�C��</summary>
    public int Coin => _coin;

    /// <summary>���v�p���[</summary>
    public int Power => _power;

    /// <summary>�����N�̃J�E���g</summary>
    public int Count => _count;

    /// <summary>���̃����N</summary>
    public int Rank => _rank;

    /// <summary>�o���l�o�����[��Max</summary>
    public int ExpMaxValue => _maxValue;

    /// <summary>�R�C���e�L�X�g</summary>
    [Header("�R�C���e�L�X�g")]
    [SerializeField]
    Text coinText;

    /// <summary>�o���l�e�L�X�g</summary>
    [Header("�o���l�e�L�X�g")]
    [SerializeField]
    Text expText;

    /// <summary>�o���l�X���C�_�[</summary>
    [Header("�o���l�X���C�_�[")]
    [SerializeField]
    Slider slider;

    /// <summary>�����N�e�L�X�g</summary>
    [Header("�����N�e�L�X�g")]
    [SerializeField]
    Text _rankText;

    int _maxValue = 1000;
    //public List<int> _playerprefas = new List<int>();

    /// <summary>�o���l</summary>
    int _exp;

    /// <summary>�R�C��</summary>
    int _coin;

    /// <summary>�p���[</summary>
    int _power;

    /// <summary>�����N�̃J�E���g</summary>
    int _count;

    /// <summary>���̃����N</summary>
    [Header("���̃����N")]
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

        #region ���x���A�b�v�̏���
        if (Slider.value < (float)Exp)
        {
            LevelUp();
        }
        else
        {
            Debug.Log("�o���l������Ȃ���");
        }
        #endregion
        if (_coin <= 0)
        {
            Debug.Log("�����ˁ[���I");
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
        Debug.Log("LevelUp������");
        if (Slider.value < (float)Exp)
        {
            LevelUp();
        }
    }

    public int TotalExp(int exp) => _exp = exp;
    public int TotalCoin(int coin) => _coin = coin;
    public int TotalPower(int power) => _power = power;
}
