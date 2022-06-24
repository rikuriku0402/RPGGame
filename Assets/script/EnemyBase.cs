using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    #region �v���p�e�B
    /// <summary>Player�̎��_�ɍ��킹���L�����o�X</summary>
    public Canvas Canvas => _canvas;

    /// <summary>�G�t�F�N�g</summary>
    public GameObject[] EffectPrefab => _explosionPrefab;

    /// <summary>�G��Max�̗�</summary>
    public int MaxHP  => _maxHP;

    /// <summary>�G�̌��݂̗̑�</summary>
    public int CurrentHP => _currentHP;

    /// <summary>�G�̗̑̓X���C�_�[</summary>
    public Slider Slider => slider;

    /// <summary>Player�̍U����</summary>
    public int Power => _playerPower;

    /// <summary>�A�j���[�^�[</summary>
    public Animator Animator => _animator;

    /// <summary>�G�t�F�N�g�̏o���ꏊ</summary>
    public GameObject EffectPos => _effectPos;

    /// <summary>Player���A�^�b�`</summary>
    public GameObject Target => _target;

    /// <summary>Enemy�̕�����A�^�b�`</summary>
    public List<GameObject> EnemyWeapon => _enemyWeapon;

    /// <summary>���ʉ�</summary>
    public AudioClip[] Sound  => _sound;

    /// <summary>���ʉ���炷���߂̂���</summary>
    public AudioSource AudioSource => _audioSource;

    /// <summary>�{�X�̍U���ŏ���</summary>
    public List <int> BossAttack => _bossAttack;

    /// <summary>�Q�b�g�o����R�C���̗�</summary>
    public List<int> GetCoin => _getCoin;

    /// <summary>�Q�b�g�o����o���l�̗�</summary>
    public List<int> GetExp => _getExp;
    #endregion

    #region �ϐ�

    /// <summary>Player�̎��_�ɍ��킹���L�����o�X</summary>
    [Header("Player�̎��_�ɍ��킹���L�����o�X")]
    [SerializeField]
    Canvas _canvas;

    /// <summary>�G�t�F�N�g</summary>
    [Header("�G�t�F�N�g")]
    [SerializeField]
    GameObject[] _explosionPrefab;

    /// <summary>�G�t�F�N�g�̏o���ꏊ</summary>
    [Header("�G�t�F�N�g�̏o���ꏊ")]
    [SerializeField]
    GameObject _effectPos;

    /// <summary>�G��Max�̗�</summary>
    [Header("�G��Max�̗�")]
    [SerializeField]
    int _maxHP;

    /// <summary>�G�̌��݂̗̑�</summary>
    [Header("�G�̌��݂̗̑�")]
    int _currentHP;

    /// <summary>�G�̗̑͂̃X���C�_�[</summary>
    [Header("�G�̗̑͂̃X���C�_�[")]
    [SerializeField]
    Slider slider;

    /// <summary>Player�̍U����</summary>
    [Header("Player�̍U����")]
    int _playerPower;


    /// <summary>�A�j���[�^�[</summary>
    [Header("�A�j���[�^�[")]
    Animator _animator;

    /// <summary>Player���A�^�b�`</summary>
    [Header("Player���A�^�b�`")]
    [SerializeField]
    GameObject _target;

    /// <summary>Enemy�̕�����A�^�b�`</summary>
    [Header("Enemy�̕�����A�^�b�`")]
    [SerializeField]
    List <GameObject> _enemyWeapon = new List<GameObject>();

    /// <summary>�i�r���b�V��</summary>
    [Header("�i�r���b�V��")]
    NavMeshAgent _agent;

    /// <summary>���ʉ�</summary>
    [Header("���ʉ�")]
    [SerializeField]
     AudioClip[] _sound;

    /// <summary>���ʉ���炷���߂̂���</summary>
    [Header("���ʉ���炷���߂̂���")]
    AudioSource _audioSource;

    /// <summary><para>�{�X�̍U���ŏ���</para>
    /// <para>0�͍ŏ��l</para>
    /// <para>1�͍ő�l</para></summary>
    [Header("�{�X�̍U���ŏ���")]
    [Header("�{�X�̍U���ő吔")]
    List <int> _bossAttack = new List<int>();

    /// <summary>�Q�b�g�o����R�C���̗�</summary>
    [Header("�Q�b�g�o����R�C���̗�")]
    [SerializeField]
    List <int> _getCoin = new List<int>();

    /// <summary>�Q�b�g�o����o���l�̗�</summary>
    [Header("�Q�b�g�o����o���l�̗�")]
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
            print("�̗͂�0����");
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
