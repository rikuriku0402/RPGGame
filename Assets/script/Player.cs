using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : PlayerBase
{
    /// <summary>敵の配列</summary>
    public GameObject[] Enemy => _enemy;

    /// <summary>敵の配列</summary>
    [SerializeField]
    [Header("敵の配列")]
    GameObject[] _enemy;

    protected override void Awake() => base.Awake();
    protected override void OnEnable() => base.OnEnable();
    protected override void OnDisable() => base.OnDisable();
    protected override void Start() => base.Start();
    protected override void Update()
    {
        base.Update();
        Clear("BigBoss");
    }
        public void Clear(string tagName)
    {
        _enemy = GameObject.FindGameObjectsWithTag(tagName);
        if (Enemy.Length == 0)
        {
            Debug.Log(tagName + "タグのついたオブジェクトはないよ");
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                PlayerPrefs.Save();
                Debug.Log("YOU WIN GAME");
            }
            else
            {
                SceneManager.LoadScene("MenuScene");
                if (NextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.Save();
                    PlayerPrefs.SetInt("levelAt", NextSceneLoad);
                }
            }
        }
}
    protected override void FixedUpdate() => base.FixedUpdate();
    protected override void OnTriggerEnter(Collider other) => base.OnTriggerEnter(other);
    protected override void Attack(InputAction.CallbackContext obj)=> base.Attack(obj);
    protected override void Jump(InputAction.CallbackContext obj) => base.Jump(obj);
    protected override void Kick(InputAction.CallbackContext obj) => base.Kick(obj);
    protected override void Special(InputAction.CallbackContext obj) => base.Special(obj);
    protected override void Pause(InputAction.CallbackContext obj) => base.Pause(obj);
    protected override void SpecialAttack() => base.SpecialAttack();
    protected override Vector3 GetCameraRight(Camera playerCamera) => base.GetCameraRight(playerCamera);
    protected override Vector3 GetCameraForward(Camera playerCamera) => base.GetCameraForward(playerCamera);
    protected override void SpeedCheck() => base.SpeedCheck();
    protected override void LookAt() => base.LookAt();
    protected override void PauseEnd() => base.PauseEnd();
}