using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : SingletonMonoBehaviour<ShopManager>
{
    /// <summary>�{�^���z��
    /// <para>0�Ԗ�,500�~</para>
    /// <para>1�Ԗ�,1000�~</para>
    /// <para>2�Ԗ�,3000�~</para>
    /// <para>3�Ԗ�,4000�~</para>
    /// <para>4�Ԗ�,5000�~</para>
    /// <para>5�Ԗ�,10000�~</para></summary>
    public Button[] Btns => _btns;

    /// <summary>�R�C���e�L�X�g</summary>
    public Text CoinText => _coinText;

    /// <summary>�o���l�e�L�X�g</summary>
    public Text ExpText => _expText;

    /// <summary>�R�C��</summary>
    public int Coin => _coin;

    ///// <summary>�o���l</summary>
    //public int Exp => _exp;

    /// <summary>�U����</summary>
    public int Power => _power;


    /// <summary>�{�^�����������ɑ傫���Ȃ�Image</summary>
    public List<Image> BigImage => _bigImage;


    /// <summary>�{�^���z��
    /// <para>0�Ԗ�,500�~</para>
    /// <para>1�Ԗ�,1000�~</para>
    /// <para>2�Ԗ�,3000�~</para>
    /// <para>3�Ԗ�,4000�~</para>
    /// <para>4�Ԗ�,5000�~</para>
    /// <para>5�Ԗ�,10000�~</para>
    /// <para>6�Ԗ�,�p���[�A�b�v�C���[�W
    /// <para>7�Ԗ�,����C���[�W</para></para></summary>
    [Header("�{�^���z��")]
    [SerializeField]
    private Button[] _btns;

    /// <summary>�R�C���e�L�X�g</summary>
    [Header("�R�C���e�L�X�g")]
    [SerializeField]
    private Text _coinText;

    /// <summary>�o���l�e�L�X�g</summary>
    [Header("�o���l�e�L�X�g")]
    [SerializeField]
    private Text _expText;

    /// <summary>�R�C��</summary>
    [Header("�R�C��")]
    int _coin;

    ///// <summary>�o���l</summary>
    //[Header("�o���l")]
    //int _exp;

    /// <summary>�U����</summary>
    [Header("�U����")]
    int _power;

    /// <summary>�{�^�����������ɑ傫���Ȃ�Image</summary>
    [Header("�{�^�����������ɑ傫���Ȃ�Image")]
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
        #region �V���b�v
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
        //�X�^�~�i�̂���΁H�H�H�H�H5/28
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
    public void ImageBig(Button back)//�p���[�A�b�v�C���[�W�֐�
    {
        BigImage[0].transform.DOScale(new Vector3(1f, 1f), 1f)
            .SetEase(Ease.Linear);
        back.interactable = false;
        _btns[6].interactable = false;
        _btns[7].interactable = false;
    }
    public void ImageBig1(Button back)//����w���C���[�W�֐�
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
