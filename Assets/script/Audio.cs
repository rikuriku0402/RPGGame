using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    /// <summary>–Â‚ç‚µ‚½‚¢‰¹</summary>
    public AudioClip[] Sound1 => _sound1;

    /// <summary>AudioSource</summary>
    public AudioSource AudioSource => _audioSource;

    /// <summary>–Â‚ç‚µ‚½‚¢‰¹</summary>
    [Header("–Â‚ç‚µ‚½‚¢‰¹")]
    [SerializeField]
    AudioClip[] _sound1;

    /// <summary>AudioSource</summary>
    AudioSource _audioSource;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void AttackSE()
    {
        AudioSource.PlayOneShot(Sound1[0]);
    }
    public void SpecialAttackSE()
    {
        AudioSource.PlayOneShot(Sound1[1]);
    }
    public void KickSE()
    {
        AudioSource.PlayOneShot(Sound1[2]);
    }
    public void WalkSE()
    {
        AudioSource.PlayOneShot(Sound1[3]);
    }
    public void WalkStopSE()
    {
        AudioSource.Stop();
    }
}
