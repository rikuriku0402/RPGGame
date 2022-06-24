using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorLock : MonoBehaviour
{
    /// <summary>アイコン</summary>
    public GameObject Icon { get => _icon; set => _icon = value; }

    /// <summary>アイコン</summary>
    [Header("アイコン")]
    [SerializeField]
    GameObject _icon;


    private void Update()
    {
        Icon.transform.position = Input.mousePosition;
    }
}
