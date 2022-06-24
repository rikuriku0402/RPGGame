using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    /// <summary>���v�o���l</summary>
    public int ExpScore => _expScore;

    /// <summary>���v�R�C����</summary>
    public int CoinScore => _coinScore;

    /// <summary>����̍U����</summary>
    public int PowerScore => _powerScore;


    /// <summary>���v�o���l</summary>
    [Header("���v�o���l")]
    [SerializeField]
    int _expScore;

    /// <summary>���v�R�C����</summary>
    [Header("���v�R�C����")]
    [SerializeField]
    int _coinScore;



    /// <summary>�p���[</summary>
    [Header("�p���[")]
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
