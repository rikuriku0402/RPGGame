using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    /// <summary>合計経験値</summary>
    public int ExpScore => _expScore;

    /// <summary>合計コイン数</summary>
    public int CoinScore => _coinScore;

    /// <summary>武器の攻撃力</summary>
    public int PowerScore => _powerScore;


    /// <summary>合計経験値</summary>
    [Header("合計経験値")]
    [SerializeField]
    int _expScore;

    /// <summary>合計コイン数</summary>
    [Header("合計コイン数")]
    [SerializeField]
    int _coinScore;



    /// <summary>パワー</summary>
    [Header("パワー")]
    [SerializeField]
    int _powerScore;
    void Start()
    {

    }

    void Update()
    {

    }
    public int TotalExp(int exp) => _expScore = exp;
    public int TotalCoin(int coin) => _coinScore = coin;
}
