using UnityEngine;

public class BossEnemy : EnemyBase
{
    ///// <summary>�����_���̍ŏ��l</summary>
    //public int[] Mini => _mini;

    ///// <summary>�����_���̍ő�l</summary>
    //public int[] Max => _max;

    ///// <summary>�o���l</summary>
    //public int Exp => _exp;

    ///// <summary>�R�C��</summary>
    //public int Coin => _coin;


    ///// <summary>�����_���̍ŏ��l</summary>
    //[Header("�����_���̍ŏ��l")]
    //[Header("0�̓R�C��")]
    //[Header("1�͌o���l")]
    //[SerializeField]
    //int[] _mini;

    ///// <summary>�����_���̍ő�l</summary>
    //[Header("�����_���̍ő�l")]
    //[Header("0�̓R�C��")]
    //[Header("1�͌o���l")]
    //[SerializeField]
    //int[] _max;

    ///// <summary>�o���l</summary>
    //[Header("�o���l")]
    //int _exp;

    ///// <summary>�R�C��</summary>
    //[Header("�R�C��")]
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
