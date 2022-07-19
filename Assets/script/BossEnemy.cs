using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyBase
{
    /// <summary>�Q�b�g�o����o���l</summary>
    public List<int> GetExp => _getExp;

    /// <summary>�Q�b�g�o����R�C��</summary>
    public List <int> GetCoin => _getCoin;

    /// <summary>�R�C��</summary>
    public int Coin => _coin;

    /// <summary>�R�C��</summary>
    public int Exp => _exp;

    /// <summary>�R�C��</summary>
    public int Diamond => _diamond;

    /// <summary>�Q�b�g�o����o���l�̗�</summary>
    [Header("�Q�b�g�o����o���l�̗�")]
    [SerializeField]
    List<int> _getExp = new List<int>();

    /// <summary>�R�C��</summary>
    [Header("�R�C��")]
    [SerializeField]
    List<int> _getCoin = new List<int>();

    /// <summary>�_�C��</summary>
    [Header("�_�C��")]
    [SerializeField]
    int _diamond;

    int _coin;
    int _exp;
    protected override void Start()
    {
        _coin = PlayerPrefs.GetInt("COIN");
        _exp = PlayerPrefs.GetInt("EXP");
        _diamond = PlayerPrefs.GetInt("DIAMOND");
        base.Start();
    }
    
    protected override void Destroy()
    {
        var getCoin = Random.Range(GetCoin[0], GetCoin[1]);
        var getExp = Random.Range(GetExp[0], GetExp[1]);
        PlayerPrefs.SetInt("COIN", Coin + getCoin);
        PlayerPrefs.SetInt("EXP", Exp + getExp);
        PlayerPrefs.SetInt("DIAMOND", ++_diamond);
        base.Destroy();
    }
}
