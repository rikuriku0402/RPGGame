using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcon : MonoBehaviour
{
	/// <summary>アイコンが動くスピード</summary>
    public float IconSpeed { get => _iconSpeed; set => _iconSpeed = value; }

	/// <summary>画面内に収まる縦横幅</summary>
	public RectTransform Rect { get => _rect; set => _rect = value; }

	/// <summary></summary>
	public Vector2 Offset { get => _offset; set => _offset = value; }

	/// <summary>アイコンのサイズ取得で使用</summary>
	[Header("アイコンのサイズ取得で使用")]
	[SerializeField]
	float _iconSpeed = Screen.width;

	/// <summary>アイコンが画面内に収まる為のオフセット値</summary>
	[Header("アイコンが画面内に収まる為のオフセット値")]
	private RectTransform _rect;

	/// <summary>オフセット</summary>
	[Header("オフセット")]
	private Vector2 _offset;


    void Start()
	{
		Rect = GetComponent<RectTransform>();
		//　オフセット値をアイコンのサイズの半分で設定
		Offset = new Vector2(Rect.sizeDelta.x / 2f, Rect.sizeDelta.y / 2f);
	}

	void Update()
	{

		//　移動キーを押していなければ何もしない
		if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0f) && Mathf.Approximately(Input.GetAxis("Vertical"), 0f))
		{
			return;
		}
		//　移動先を計算
		var pos = Rect.anchoredPosition + new Vector2(Input.GetAxis("Horizontal") * IconSpeed, Input.GetAxis("Vertical") * IconSpeed) * Time.deltaTime;

		//　アイコンが画面外に出ないようにする
		pos.x = Mathf.Clamp(pos.x, -Screen.width * 0.5f + Offset.x, Screen.width * 0.5f - Offset.x);
		pos.y = Mathf.Clamp(pos.y, -Screen.height * 0.5f + Offset.y, Screen.height * 0.5f - Offset.y);
		//　アイコン位置を設定
		Rect.anchoredPosition = pos;
	}
}
