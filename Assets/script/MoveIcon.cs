using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcon : MonoBehaviour
{
	/// <summary>�A�C�R���������X�s�[�h</summary>
    public float IconSpeed { get => _iconSpeed; set => _iconSpeed = value; }

	/// <summary>��ʓ��Ɏ��܂�c����</summary>
	public RectTransform Rect { get => _rect; set => _rect = value; }

	/// <summary></summary>
	public Vector2 Offset { get => _offset; set => _offset = value; }

	/// <summary>�A�C�R���̃T�C�Y�擾�Ŏg�p</summary>
	[Header("�A�C�R���̃T�C�Y�擾�Ŏg�p")]
	[SerializeField]
	float _iconSpeed = Screen.width;

	/// <summary>�A�C�R������ʓ��Ɏ��܂�ׂ̃I�t�Z�b�g�l</summary>
	[Header("�A�C�R������ʓ��Ɏ��܂�ׂ̃I�t�Z�b�g�l")]
	private RectTransform _rect;

	/// <summary>�I�t�Z�b�g</summary>
	[Header("�I�t�Z�b�g")]
	private Vector2 _offset;


    void Start()
	{
		Rect = GetComponent<RectTransform>();
		//�@�I�t�Z�b�g�l���A�C�R���̃T�C�Y�̔����Őݒ�
		Offset = new Vector2(Rect.sizeDelta.x / 2f, Rect.sizeDelta.y / 2f);
	}

	void Update()
	{

		//�@�ړ��L�[�������Ă��Ȃ���Ή������Ȃ�
		if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0f) && Mathf.Approximately(Input.GetAxis("Vertical"), 0f))
		{
			return;
		}
		//�@�ړ�����v�Z
		var pos = Rect.anchoredPosition + new Vector2(Input.GetAxis("Horizontal") * IconSpeed, Input.GetAxis("Vertical") * IconSpeed) * Time.deltaTime;

		//�@�A�C�R������ʊO�ɏo�Ȃ��悤�ɂ���
		pos.x = Mathf.Clamp(pos.x, -Screen.width * 0.5f + Offset.x, Screen.width * 0.5f - Offset.x);
		pos.y = Mathf.Clamp(pos.y, -Screen.height * 0.5f + Offset.y, Screen.height * 0.5f - Offset.y);
		//�@�A�C�R���ʒu��ݒ�
		Rect.anchoredPosition = pos;
	}
}
