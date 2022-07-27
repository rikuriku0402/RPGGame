using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PlayerBase
{
    protected override void Awake() => base.Awake();
    protected override void OnEnable() => base.OnEnable();
    protected override void OnDisable() => base.OnDisable();
    protected override void Start() => base.Start();
    protected override void Update() => base.Update();
    protected override void Clear(string tagName) => base.Clear(tagName);
    protected override void FixedUpdate() => base.FixedUpdate();
    protected override void OnTriggerEnter(Collider other) => base.OnTriggerEnter(other);
    protected override void Attack(InputAction.CallbackContext obj)=> base.Attack(obj);
    protected override void Jump(InputAction.CallbackContext obj) => base.Jump(obj);
    protected override void Kick(InputAction.CallbackContext obj) => base.Kick(obj);
    protected override void Special(InputAction.CallbackContext obj) => base.Special(obj);
    protected override void SpecialAttack() => base.SpecialAttack();
    protected override Vector3 GetCameraRight(Camera playerCamera) => base.GetCameraRight(playerCamera);
    protected override Vector3 GetCameraForward(Camera playerCamera) => base.GetCameraForward(playerCamera);
    protected override void SpeedCheck() => base.SpeedCheck();
    protected override void LookAt() => base.LookAt();
    protected override void Pause(InputAction.CallbackContext obj) => base.Pause(obj);
    protected override void PauseEnd() => base.PauseEnd();
}