using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyBase
{
    /// <summary>ゲット出来る経験値</summary>
    public List<int> GetExp => _getExp;

    /// <summary>ゲット出来るコイン</summary>
    public List <int> GetCoin => _getCoin;

    /// <summary>コイン</summary>
    public int Coin => _coin;

    /// <summary>コイン</summary>
    public int Exp => _exp;

    /// <summary>コイン</summary>
    public int Diamond => _diamond;

    /// <summary>ゲット出来る経験値の量</summary>
    [Header("ゲット出来る経験値の量")]
    [SerializeField]
    List<int> _getExp = new List<int>();

    /// <summary>コイン</summary>
    [Header("コイン")]
    [SerializeField]
    List<int> _getCoin = new List<int>();

    /// <summary>ダイヤ</summary>
    [Header("ダイヤ")]
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
