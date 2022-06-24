using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorLock : MonoBehaviour
{
    /// <summary>�A�C�R��</summary>
    public GameObject Icon { get => _icon; set => _icon = value; }

    /// <summary>�A�C�R��</summary>
    [Header("�A�C�R��")]
    [SerializeField]
    GameObject _icon;


    private void Update()
    {
        Icon.transform.position = Input.mousePosition;
    }
}
