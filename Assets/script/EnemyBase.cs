using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    #region プロパティ
    /// <summary>Playerの視点に合わせたキャンバス</summary>
    public Canvas Canvas => _canvas;

    /// <summary>エフェクト</summary>
    public GameObject[] EffectPrefab => _explosionPrefab;

    /// <summary>敵のMax体力</summary>
    public int MaxHP  => _maxHP;

    /// <summary>敵の現在の体力</summary>
    public int CurrentHP => _currentHP;

    /// <summary>敵の体力スライダー</summary>
    public Slider Slider => slider;

    /// <summary>Playerの攻撃力</summary>
    public int Power => _playerPower;

    /// <summary>アニメーター</summary>
    public Animator Animator => _animator;

    /// <summary>エフェクトの出現場所</summary>
    public GameObject EffectPos => _effectPos;

    /// <summary>Playerをアタッチ</summary>
    public GameObject Target => _target;

    /// <summary>Enemyの武器をアタッチ</summary>
    public List<GameObject> EnemyWeapon => _enemyWeapon;

    /// <summary>効果音</summary>
    public AudioClip[] Sound  => _sound;

    /// <summary>効果音を鳴らすためのもの</summary>
    public AudioSource AudioSource => _audioSource;

    /// <summary>ボスの攻撃最小数</summary>
    public List <int> BossAttack => _bossAttack;

    /// <summary>ゲット出来るコインの量</summary>
    public List<int> GetCoin => _getCoin;

    /// <summary>ゲット出来る経験値の量</summary>
    public List<int> GetExp => _getExp;
    #endregion

    #region 変数

    /// <summary>Playerの視点に合わせたキャンバス</summary>
    [Header("Playerの視点に合わせたキャンバス")]
    [SerializeField]
    Canvas _canvas;

    /// <summary>エフェクト</summary>
    [Header("エフェクト")]
    [SerializeField]
    GameObject[] _explosionPrefab;

    /// <summary>エフェクトの出現場所</summary>
    [Header("エフェクトの出現場所")]
    [SerializeField]
    GameObject _effectPos;

    /// <summary>敵のMax体力</summary>
    [Header("敵のMax体力")]
    [SerializeField]
    int _maxHP;

    /// <summary>敵の現在の体力</summary>
    [Header("敵の現在の体力")]
    int _currentHP;

    /// <summary>敵の体力のスライダー</summary>
    [Header("敵の体力のスライダー")]
    [SerializeField]
    Slider slider;

    /// <summary>Playerの攻撃力</summary>
    [Header("Playerの攻撃力")]
    int _playerPower;


    /// <summary>アニメーター</summary>
    [Header("アニメーター")]
    Animator _animator;

    /// <summary>Playerをアタッチ</summary>
    [Header("Playerをアタッチ")]
    [SerializeField]
    GameObject _target;

    /// <summary>Enemyの武器をアタッチ</summary>
    [Header("Enemyの武器をアタッチ")]
    [SerializeField]
    List <GameObject> _enemyWeapon = new List<GameObject>();

    /// <summary>ナビメッシュ</summary>
    [Header("ナビメッシュ")]
    NavMeshAgent _agent;

    /// <summary>効果音</summary>
    [Header("効果音")]
    [SerializeField]
     AudioClip[] _sound;

    /// <summary>効果音を鳴らすためのもの</summary>
    [Header("効果音を鳴らすためのもの")]
    AudioSource _audioSource;

    /// <summary><para>ボスの攻撃最小数</para>
    /// <para>0は最小値</para>
    /// <para>1は最大値</para></summary>
    [Header("ボスの攻撃最小数")]
    [Header("ボスの攻撃最大数")]
    List <int> _bossAttack = new List<int>();

    /// <summary>ゲット出来るコインの量</summary>
    [Header("ゲット出来るコインの量")]
    [SerializeField]
    List <int> _getCoin = new List<int>();

    /// <summary>ゲット出来る経験値の量</summary>
    [Header("ゲット出来る経験値の量")]
    [SerializeField]
    List <int> _getExp = new List<int>();
    #endregion

    protected virtual void Start()
    {
        Slider.value = MaxHP;
        Slider.maxValue = MaxHP;
        _currentHP = MaxHP;
        _playerPower = PlayerPrefs.GetInt("POWER");
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
    }
    protected virtual void Update()
    {
        Vector3 vector3 = Target.transform.position - this.transform.position;

        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;

        _agent.destination = Target.transform.position;
        Canvas.transform.rotation = Camera.main.transform.rotation;
    }

    protected virtual void DeathEnemy()
    {
        if (Slider.value <= 0)
        {
            print("体力が0だよ");
            Animator.SetBool("Walk", false);
            Animator.Play("Death");
        }
        else
        {
            Animator.SetTrigger("Attack");
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            var damage = Random.Range(BossAttack[0] + _playerPower, BossAttack[1] + _playerPower);
            _currentHP -= damage;
            Slider.value = (float)CurrentHP;
            Instantiate(EffectPrefab[0], transform.position, Quaternion.identity);
        }
        if (other.gameObject.tag == "Player")
        {
            DeathEnemy();
        }
    }
    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DeathEnemy();
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Animator.SetBool("Walk", true);
        }
    }
    protected virtual void OnDestroy()
    {
        var getCoin = Random.Range(GetCoin[0], GetCoin[1]);
        var getExp = Random.Range(GetExp[0], GetExp[1]);
        PlayerPrefs.SetInt("COIN", +getCoin);
        PlayerPrefs.SetInt("EXP", +getExp);
        PlayerPrefs.Save();
    }
    protected virtual void Destroy() => Destroy(this.gameObject);
    protected virtual void Effect() => Instantiate(EffectPrefab[1], transform.position, Quaternion.identity);
    protected virtual void WeaponTrue() => EnemyWeapon.ForEach(x => x.gameObject.SetActive(true));
    protected virtual void WeaponFalse() => EnemyWeapon.ForEach(x => x.gameObject.SetActive(false));
    protected virtual void AttackSE() => _audioSource.PlayOneShot(Sound[0]);
}
