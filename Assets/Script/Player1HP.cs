using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;

public class Player1HP : MonoBehaviour,IDamage
{
    /// <summary>
    /// playerのHP
    /// </summary>
    [SerializeField] int m_maxHp = 10;
    /// <summary>
    /// HPのリアクティブプロパティ
    /// </summary>
    public ReactiveProperty<int> hp = new ReactiveProperty<int>();
    /// <summary>
    /// イベント発行のインスタンス
    /// </summary>
    private Subject<Unit> playerHpSubject = new Subject<Unit>();
    /// <summary>
    /// イベントの購読のみ公開
    /// </summary>
    public IObservable<Unit> Player1Deth => playerHpSubject;

    //[SerializeField] Slider m_Player1HPbar;

    [SerializeField] AudioClip m_audioClip;

    [SerializeField] GameManager m_gameManager;

    void Awake()
    {
        hp.Value = m_maxHp;
    }
    private void Start()
    {
       

        //m_Player1HPbar.value = 1;
    }
    public void AddDamage(int damage)
    {
        AudioSource.PlayClipAtPoint(m_audioClip, transform.position);
        hp.Value -= damage;
        Debug.Log(hp.Value);
        if (hp.Value <= 0 && m_gameManager.m_gamrEnd == true)
        {
            playerHpSubject.OnNext(Unit.Default);
            m_gameManager.m_gamrEnd = false;
        }
    }
}
