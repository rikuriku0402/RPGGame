using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.InputSystem;

/// <summary>PlayerのBaseClass</summary>
public class PlayerBase : MonoBehaviour
{
    #region プロパティ
    /// <summary>PS4コントローラー,キーボード入力判定</summary>
    public PS4 PlayerActionsAsset => _playerActionsAsset;

    /// <summary>コントローラーで動かすためのシステム</summary>
    public InputAction Move => _move;

    /// <summary>剛体</summary>
    public Rigidbody Rb => _rb;

    /// <summary>動くスピード</summary>
    public float MaxSpeed => _maxSpeed;

    /// <summary>力の方向</summary>
    public Vector3 ForceDirection => _forceDirection;

    /// <summary>Player追跡カメラ</summary>
    public Camera PlayerCamera => _playerCamera;

    /// <summary>アニメーション</summary>
    public Animator Animator => _animator;

    /// <summary>カメラの回転</summary>
    public Quaternion TargetRotation => _targetRotation;

    /// <summary>動くか動かないか判断する</summary>
    public bool CanMove => _canMove;

    /// <summary>マックス体力</summary>
    public int MaxHP => _maxHP;

    /// <summary>現時点の体力</summary>
    public int CurrentHP => _currentHP;

    /// <summary>PlayerHPスライダー</summary>
    public Slider Slider => slider;

    /// <summary>敵の配列</summary>
    public GameObject[] Enemy => _enemy;

    /// <summary>次のレベルのシーン数</summary>
    public int NextSceneLoad => _nextSceneLoad;

    /// <summary>クリアした時のイメージ</summary>
    public Image GameClearImage => _gameClearImage;

    /// <summary>ポーズ時のパネル</summary>
    public RectTransform Panel => _panel;

    /// <summary>アイコンイメージ</summary>
    public GameObject Icon => _icon;

    /// <summary>攻撃エフェクト</summary>
    public List <GameObject> Effect => _effect;

    /// <summary>剣</summary>
    public GameObject Sword => _sword;

    /// <summary>武器</summary>
    public List<GameObject> Weapon  => _weapon;

    /// <summary>Playerの攻撃力</summary>
    public int PlayerPower => _playerPower;

    /// <summary>雑魚敵の攻撃リスト</summary>
    public List <int> MobAttack => _mobAttack;

    /// <summary>ボスの攻撃リスト</summary>
    public List <int> BossAttack => _bossAttack;

    #endregion

    #region 変数
    /// <summary>PS4コントローラー,キーボード入力判定</summary>
    [Header("PS4コントローラー,キーボード入力判定")]
    PS4 _playerActionsAsset;

    /// <summary></summary>
    [Header("コントローラーで動かすためのシステム")]
    InputAction _move;

    /// <summary></summary>
    [Header("剛体")]
    Rigidbody _rb;

    /// <summary>歩行スピード</summary>
    [Header("歩行スピード")]
    [SerializeField]
    const float _maxSpeed = 5f;//歩行スピード

    /// <summary>力の方向</summary>
    [Header("力の方向")]
    Vector3 _forceDirection = Vector3.zero;

    /// <summary>Player追跡カメラ</summary>
    [Header("Player追跡カメラ")]
    [SerializeField]
    Camera _playerCamera;

    /// <summary>アニメーション</summary>
    [Header("アニメーション")]
    Animator _animator;

    /// <summary>カメラの回転</summary>
    [Header("カメラの回転")]
    Quaternion _targetRotation;

    /// <summary>動くか動かないか判断する</summary>
    [Header("動くか動かないか判断する")]
    bool _canMove;

    /// <summary>最大体力値</summary>
    [Header("最大体力値")]
    [SerializeField]
    int _maxHP;

    /// <summary>現在の体力</summary>
    [Header("現在の体力")]
    int _currentHP;

    /// <summary>体力バー</summary>
    [Header("体力バー")]
    [SerializeField]
    Slider slider;

    /// <summary>敵の配列</summary>
    [Header("敵の配列")]
    [SerializeField]
    GameObject[] _enemy;

    /// <summary>次のステージ解放</summary>
    [Header("次のステージ解放")]
    [SerializeField]
    int _nextSceneLoad;

    /// <summary>クリアイメージ</summary>
    [Header("クリアイメージ")]
    [SerializeField]
    Image _gameClearImage;

    /// <summary>ポーズ時のパネル</summary>
    [Header("ポーズ時のパネル")]
    [SerializeField]
    RectTransform _panel;

    /// <summary>アイコン</summary>
    [Header("アイコン")]
    [SerializeField]
    GameObject _icon;

    /// <summary>エフェクト</summary>
    [Header("エフェクト")]
    [SerializeField]
    List <GameObject> _effect = new List<GameObject>();

    /// <summary>剣</summary>
    [Header("剣")]
    [SerializeField]
    GameObject _sword;

    /// <summary>武器</summary>
    [Header("武器")]
    [SerializeField]
    List<GameObject> _weapon = new List<GameObject>();

    /// <summary>Playerの攻撃力</summary>
    [Header("Playerの攻撃力")]
    int _playerPower;

    /// <summary>一回だけの処理</summary>
    [Header("一回だけの処理")]
    bool _isFirst = false;

    /// <summary>雑魚の攻撃リスト</summary>
    [Header("雑魚敵の攻撃の最小数")]
    List <int> _mobAttack = new List<int>();

    /// <summary>ボスの攻撃リスト</summary>
    [Header("ボスの攻撃リスト")]
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
            Debug.Log(tagName + "タグのついたオブジェクトはないよ");
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
            Debug.Log("死");
            Animator.Play("Death");
        }
        if (other.gameObject.tag == "Recovery")//回復アイテム
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
        //StartCoroutine(SpecialAttack());//コルーチンで規定の秒数まってウルト
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
