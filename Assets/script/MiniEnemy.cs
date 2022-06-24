using UnityEngine;

public class MiniEnemy : EnemyBase
{
    protected override void Start() => base.Start();
    protected override void Update() => base.Update();
    protected override void OnTriggerEnter(Collider other) => base.OnTriggerEnter(other);
    protected override void OnTriggerStay(Collider other) => base.OnTriggerStay(other);
    protected override void OnDestroy() => base.OnDestroy();
    protected override void OnTriggerExit(Collider other) => base.OnTriggerExit(other);
    protected override void Destroy() => base.Destroy();
}
