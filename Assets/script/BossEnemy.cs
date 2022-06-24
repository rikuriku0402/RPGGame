using UnityEngine;

public class BossEnemy : EnemyBase
{
    ///// <summary>ランダムの最小値</summary>
    //public int[] Mini => _mini;

    ///// <summary>ランダムの最大値</summary>
    //public int[] Max => _max;

    ///// <summary>経験値</summary>
    //public int Exp => _exp;

    ///// <summary>コイン</summary>
    //public int Coin => _coin;


    ///// <summary>ランダムの最小値</summary>
    //[Header("ランダムの最小値")]
    //[Header("0はコイン")]
    //[Header("1は経験値")]
    //[SerializeField]
    //int[] _mini;

    ///// <summary>ランダムの最大値</summary>
    //[Header("ランダムの最大値")]
    //[Header("0はコイン")]
    //[Header("1は経験値")]
    //[SerializeField]
    //int[] _max;

    ///// <summary>経験値</summary>
    //[Header("経験値")]
    //int _exp;

    ///// <summary>コイン</summary>
    //[Header("コイン")]
    //int _coin;
    protected override void Start() => base.Start();
    protected override void Update() => base.Update();
    protected override void OnTriggerEnter(Collider other) => base.OnTriggerEnter(other);
    protected override void OnTriggerStay(Collider other) => base.OnTriggerStay(other);
    protected override void OnTriggerExit(Collider other) => base.OnTriggerExit(other);
    protected override void OnDestroy() => base.OnDestroy();
    protected override void Destroy() => base.Destroy();
    //protected override void Effect() => base.Effect();
}
