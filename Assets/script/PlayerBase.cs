using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.InputSystem;

/// <summary>Player��BaseClass</summary>
public class PlayerBase : MonoBehaviour
{
    #region �v���p�e�B
    /// <summary>PS4�R���g���[���[,�L�[�{�[�h���͔���</summary>
    public PS4 PlayerActionsAsset => _playerActionsAsset;

    /// <summary>�R���g���[���[�œ��������߂̃V�X�e��</summary>
    public InputAction Move => _move;

    /// <summary>����</summary>
    public Rigidbody Rb => _rb;

    /// <summary>�����X�s�[�h</summary>
    public float MaxSpeed => _maxSpeed;

    /// <summary>�͂̕���</summary>
    public Vector3 ForceDirection => _forceDirection;

    /// <summary>Player�ǐՃJ����</summary>
    public Camera PlayerCamera => _playerCamera;

    /// <summary>�A�j���[�V����</summary>
    public Animator Animator => _animator;

    /// <summary>�J�����̉�]</summary>
    public Quaternion TargetRotation => _targetRotation;

    /// <summary>�����������Ȃ������f����</summary>
    public bool CanMove => _canMove;

    /// <summary>�}�b�N�X�̗�</summary>
    public int MaxHP => _maxHP;

    /// <summary>�����_�̗̑�</summary>
    public int CurrentHP => _currentHP;

    /// <summary>PlayerHP�X���C�_�[</summary>
    public Slider Slider => slider;

    /// <summary>�G�̔z��</summary>
    public GameObject[] Enemy => _enemy;

    /// <summary>���̃��x���̃V�[����</summary>
    public int NextSceneLoad => _nextSceneLoad;

    /// <summary>�N���A�������̃C���[�W</summary>
    public Image GameClearImage => _gameClearImage;

    /// <summary>�|�[�Y���̃p�l��</summary>
    public RectTransform Panel => _panel;

    /// <summary>�A�C�R���C���[�W</summary>
    public GameObject Icon => _icon;

    /// <summary>�U���G�t�F�N�g</summary>
    public List <GameObject> Effect => _effect;

    /// <summary>��</summary>
    public GameObject Sword => _sword;

    /// <summary>����</summary>
    public List<GameObject> Weapon  => _weapon;

    /// <summary>Player�̍U����</summary>
    public int PlayerPower => _playerPower;

    /// <summary>�G���G�̍U�����X�g</summary>
    public List <int> MobAttack => _mobAttack;

    /// <summary>�{�X�̍U�����X�g</summary>
    public List <int> BossAttack => _bossAttack;

    #endregion

    #region �ϐ�
    /// <summary>PS4�R���g���[���[,�L�[�{�[�h���͔���</summary>
    [Header("PS4�R���g���[���[,�L�[�{�[�h���͔���")]
    PS4 _playerActionsAsset;

    /// <summary></summary>
    [Header("�R���g���[���[�œ��������߂̃V�X�e��")]
    InputAction _move;

    /// <summary></summary>
    [Header("����")]
    Rigidbody _rb;

    /// <summary>���s�X�s�[�h</summary>
    [Header("���s�X�s�[�h")]
    [SerializeField]
    const float _maxSpeed = 5f;//���s�X�s�[�h

    /// <summary>�͂̕���</summary>
    [Header("�͂̕���")]
    Vector3 _forceDirection = Vector3.zero;

    /// <summary>Player�ǐՃJ����</summary>
    [Header("Player�ǐՃJ����")]
    [SerializeField]
    Camera _playerCamera;

    /// <summary>�A�j���[�V����</summary>
    [Header("�A�j���[�V����")]
    Animator _animator;

    /// <summary>�J�����̉�]</summary>
    [Header("�J�����̉�]")]
    Quaternion _targetRotation;

    /// <summary>�����������Ȃ������f����</summary>
    [Header("�����������Ȃ������f����")]
    bool _canMove;

    /// <summary>�ő�̗͒l</summary>
    [Header("�ő�̗͒l")]
    [SerializeField]
    int _maxHP;

    /// <summary>���݂̗̑�</summary>
    [Header("���݂̗̑�")]
    int _currentHP;

    /// <summary>�̗̓o�[</summary>
    [Header("�̗̓o�[")]
    [SerializeField]
    Slider slider;

    /// <summary>�G�̔z��</summary>
    [Header("�G�̔z��")]
    [SerializeField]
    GameObject[] _enemy;

    /// <summary>���̃X�e�[�W���</summary>
    [Header("���̃X�e�[�W���")]
    [SerializeField]
    int _nextSceneLoad;

    /// <summary>�N���A�C���[�W</summary>
    [Header("�N���A�C���[�W")]
    [SerializeField]
    Image _gameClearImage;

    /// <summary>�|�[�Y���̃p�l��</summary>
    [Header("�|�[�Y���̃p�l��")]
    [SerializeField]
    RectTransform _panel;

    /// <summary>�A�C�R��</summary>
    [Header("�A�C�R��")]
    [SerializeField]
    GameObject _icon;

    /// <summary>�G�t�F�N�g</summary>
    [Header("�G�t�F�N�g")]
    [SerializeField]
    List <GameObject> _effect = new List<GameObject>();

    /// <summary>��</summary>
    [Header("��")]
    [SerializeField]
    GameObject _sword;

    /// <summary>����</summary>
    [Header("����")]
    [SerializeField]
    List<GameObject> _weapon = new List<GameObject>();

    /// <summary>Player�̍U����</summary>
    [Header("Player�̍U����")]
    int _playerPower;

    /// <summary>��񂾂��̏���</summary>
    [Header("��񂾂��̏���")]
    bool _isFirst = false;

    /// <summary>�G���̍U�����X�g</summary>
    [Header("�G���G�̍U���̍ŏ���")]
    List <int> _mobAttack = new List<int>();

    /// <summary>�{�X�̍U�����X�g</summary>
    [Header("�{�X�̍U�����X�g")]
    List <int> _bossAttack = new List<int>();
    #endregion

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerActionsAsset = new PS4();
        _canMove = true;
        _targetRotation = transform.rotation;
        _nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        GameClearImage.gameObject.SetActive(false);
    }
    protected virtual void Start()
    {
        Slider.value = MaxHP;
        Slider.maxValue = MaxHP;
        _currentHP = MaxHP;
        _nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        GameClearImage.gameObject.SetActive(false);
        Panel.transform.localPosition = new Vector3(-1400, 0);
    }

    protected virtual void OnEnable()
    {
        PlayerActionsAsset.Player.Attack.started += Attack;
        PlayerActionsAsset.Player.Kick.started += Kick;
        PlayerActionsAsset.Player.Jump.started += Jump;
        PlayerActionsAsset.Player.Pause.started += Pause;
        PlayerActionsAsset.Player.SpecialAttack.started += Special;
        _move = PlayerActionsAsset.Player.Move;
        PlayerActionsAsset.Player.Enable();
    }

    protected virtual void OnDisable()
    {
        PlayerActionsAsset.Player.Attack.started -= Attack;
        PlayerActionsAsset.Player.Kick.started -= Kick;
        PlayerActionsAsset.Player.SpecialAttack.started -= Special;
        PlayerActionsAsset.Player.Disable();
    }

    protected virtual void Update()
    {
        Animator.SetFloat("speed", Rb.velocity.sqrMagnitude / MaxSpeed);
        Clear("BigBoss");
    }
    protected virtual void Clear(string tagName)
    {
        _enemy = GameObject.FindGameObjectsWithTag(tagName);
        if (Enemy.Length == 0)
        {
            Debug.Log(tagName + "�^�O�̂����I�u�W�F�N�g�͂Ȃ���");
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                Debug.Log("YOU WIN GAME");
            }
            else
            {
                SceneManager.LoadScene("MenuScene");
                if (NextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", NextSceneLoad);
                }
            }
        }
    }
    protected virtual void FixedUpdate()
    {
        SpeedCheck();

        if (!CanMove)
        {
            return;
        }
        

        _forceDirection += Move.ReadValue<Vector2>().x * GetCameraRight(PlayerCamera);
        _forceDirection += Move.ReadValue<Vector2>().y * GetCameraForward(PlayerCamera);

        Rb.AddForce(ForceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        LookAt();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyHand")
        {
            var mobA = Random.Range(MobAttack[0],MobAttack[1]);
            _currentHP -= mobA;
            PlayerDamage();
        }
        if (other.gameObject.tag == "BossHand")
        {
            var bossA = Random.Range(BossAttack[0], BossAttack[1]);
            _currentHP -= bossA;
            PlayerDamage();
        }
        if (Slider.value <= 0)
        {
            Debug.Log("��");
            Animator.Play("Death");
        }
        if (other.gameObject.tag == "Recovery")//�񕜃A�C�e��
        {
            _currentHP += 50;
            Destroy(other.gameObject);
        }
    }

    protected virtual void PlayerDamage() => Slider.value = (float)CurrentHP;

    protected virtual void Attack(InputAction.CallbackContext obj)
    {
        Rb.velocity = Vector3.zero;
        Rb.angularVelocity = Vector3.zero;
        Animator.SetTrigger("attack");

    }
    protected virtual void Jump(InputAction.CallbackContext obj)
    {
        Rb.velocity = Vector3.zero;
        Rb.angularVelocity = Vector3.zero;

        Animator.SetTrigger("jump");
    }
    protected virtual void Kick(InputAction.CallbackContext obj)
    {
        _weapon[1].SetActive(true);
        Rb.velocity = Vector3.zero;
        Rb.angularVelocity = Vector3.zero;

        Animator.SetTrigger("kick");
    }

    protected virtual void Special(InputAction.CallbackContext obj)
    {
        _weapon[0].SetActive(true);
        Rb.velocity = Vector3.zero;
        Rb.angularVelocity = Vector3.zero;
        Animator.SetTrigger("specialAttack");
        //StartCoroutine(SpecialAttack());//�R���[�`���ŋK��̕b���܂��ăE���g
    }
    protected virtual void SpecialAttack() => Instantiate(Effect[0], Sword.transform.position, Quaternion.identity);

    protected virtual Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = PlayerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    protected virtual Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = PlayerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
    protected virtual void SpeedCheck()
    {
        Vector3 playerVelocity = Rb.velocity;
        playerVelocity.y = 0;

        if (playerVelocity.sqrMagnitude > MaxSpeed * MaxSpeed)
        {
            Rb.velocity = playerVelocity.normalized * MaxSpeed;
        }
    }
    protected virtual void LookAt()
    {
        Vector3 direction = Rb.velocity;
        direction.y = 0;

        if (Move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            _targetRotation = Quaternion.LookRotation(direction);
            Rb.rotation = Quaternion.RotateTowards(Rb.rotation, TargetRotation, 900 * Time.deltaTime);
        }
        else
        {
            Rb.angularVelocity = Vector3.zero;
        }
    }
    protected virtual void Pause(InputAction.CallbackContext obj)
    {
        if (!_isFirst)
        {
            _isFirst = true;
            Panel.transform.DOMoveX(500f, 1f);
            Icon.SetActive(true);

        }
        Rb.isKinematic = true;
        _isFirst = false;
    }
    protected virtual void PauseEnd()
    {
        if (!_isFirst)
        {
            _isFirst = true;
            Panel.transform.DOMoveX(-500f, 1f);
            Icon.SetActive(false);
        }
        Rb.isKinematic = false;
        _isFirst = false;
    }
    protected virtual void Change() => _canMove = !_canMove;
    protected virtual void DestroySceneChange(string scene) => Scenemanager.Instance.FadeStart(scene);
    protected virtual void DeathEffect() => Instantiate(Effect[1],transform.position,Quaternion.identity);
    protected virtual void WeaponTrue() => _weapon.ForEach(x => x.gameObject.SetActive(true));
    protected virtual void WeaponFalse() => _weapon.ForEach(x => x.gameObject.SetActive(false));
}
