using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : SingletonMonoBehaviour<ShopManager>
{
    /// <summary>ボタン配列
    /// <para>0番目,500円</para>
    /// <para>1番目,1000円</para>
    /// <para>2番目,3000円</para>
    /// <para>3番目,4000円</para>
    /// <para>4番目,5000円</para>
    /// <para>5番目,10000円</para></summary>
    public Button[] Btns => _btns;

    /// <summary>コインテキスト</summary>
    public Text CoinText => _coinText;

    /// <summary>経験値テキスト</summary>
    public Text ExpText => _expText;

    /// <summary>コイン</summary>
    public int Coin => _coin;

    ///// <summary>経験値</summary>
    //public int Exp => _exp;

    /// <summary>攻撃力</summary>
    public int Power => _power;


    /// <summary>ボタン押した時に大きくなるImage</summary>
    public List<Image> BigImage => _bigImage;


    /// <summary>ボタン配列
    /// <para>0番目,500円</para>
    /// <para>1番目,1000円</para>
    /// <para>2番目,3000円</para>
    /// <para>3番目,4000円</para>
    /// <para>4番目,5000円</para>
    /// <para>5番目,10000円</para>
    /// <para>6番目,パワーアップイメージ
    /// <para>7番目,武器イメージ</para></para></summary>
    [Header("ボタン配列")]
    [SerializeField]
    private Button[] _btns;

    /// <summary>コインテキスト</summary>
    [Header("コインテキスト")]
    [SerializeField]
    private Text _coinText;

    /// <summary>経験値テキスト</summary>
    [Header("経験値テキスト")]
    [SerializeField]
    private Text _expText;

    /// <summary>コイン</summary>
    [Header("コイン")]
    int _coin;

    ///// <summary>経験値</summary>
    //[Header("経験値")]
    //int _exp;

    /// <summary>攻撃力</summary>
    [Header("攻撃力")]
    int _power;

    /// <summary>ボタン押した時に大きくなるImage</summary>
    [Header("ボタン押した時に大きくなるImage")]
    [SerializeField]
    List<Image> _bigImage= new List<Image>();


    protected override void Awake(){}
    void Start()
    {
        _coin = PlayerPrefs.GetInt("COIN");
        _power = PlayerPrefs.GetInt("POWER");

        Debug.Log(Coin);
        CoinText.text = Coin.ToString();

        if (Coin <= 0)
        {
            Btns[0].interactable = false;
            Btns[1].interactable = false;
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 500)
        {
            Btns[0].interactable = false;
            Btns[1].interactable = false;
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 1000)
        {
            Btns[1].interactable = false;
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 3000)
        {
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 4000)
        {
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 5000)
        {
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 10000)
        {
            Btns[5].interactable = false;
        }
    }
    public void BuyCoin(int item)
    {
        _coin -= item;
        CoinText.text = Coin.ToString();
        #region ショップ
        if (Coin <= 0)
        {
            Btns[0].interactable = false;
            Btns[1].interactable = false;
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 500)
        {
            Btns[0].interactable = false;
            Btns[1].interactable = false;
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 1000)
        {
            Btns[1].interactable = false;
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 3000)
        {
            Btns[2].interactable = false;
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 4000)
        {
            Btns[3].interactable = false;
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 5000)
        {
            Btns[4].interactable = false;
            Btns[5].interactable = false;
        }
        if (Coin <= 10000)
        {
            Btns[5].interactable = false;
        }
        #endregion
        Debug.Log(Coin);
        //PlayerPrefasSet();
    }
    public void Weapon1(int weapon)
    {
        PlayerPrefs.SetInt("WEAPON", weapon);
        Debug.Log(weapon);
    }
    public void Weapon2(int weapon)
    {
        PlayerPrefs.SetInt("WEAPON", weapon);
        Debug.Log(weapon);
    }
    public void Weapon3(int weapon)
    {
        PlayerPrefs.SetInt("WEAPON", weapon);
        Debug.Log(weapon);
    }
    public void PowerUp(int power)
    {
        PlayerPrefs.SetInt("POWER", _power += power);
        //Debug.Log(Power1.ToString());
        //スタミナのやつやれば？？？？？5/28
    }
    public void SceneChage(string scene)
    {
        Scenemanager.Instance.FadeStart(scene);
    }
    public void PlayerPrefasSet()
    {
        PlayerPrefs.SetInt("COIN", Coin);
        PlayerPrefs.SetInt("POWER", Power);
        PlayerPrefs.Save();
    }
    public void ImageBig(Button back)//パワーアップイメージ関数
    {
        BigImage[0].transform.DOScale(new Vector3(1f, 1f), 1f)
            .SetEase(Ease.Linear);
        back.interactable = false;
        _btns[6].interactable = false;
        _btns[7].interactable = false;
    }
    public void ImageBig1(Button back)//武器購入イメージ関数
    {
        BigImage[1].transform.DOScale(new Vector3(1f, 1f), 1f)
            .SetEase(Ease.Linear);
        back.interactable = false;
        Btns[6].interactable = false;
        Btns[7].interactable = false;
    }
    public void CloseBtn(Button back)
    {
        BigImage[0] .transform.DOScale(new Vector3(0f, 0f), 1f);
        BigImage[1] .transform.DOScale(new Vector3(0f, 0f), 1f);
        back.interactable = true;
        Btns[6].interactable = true;
        Btns[7].interactable = true;
    }
}
