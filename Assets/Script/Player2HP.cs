using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Player2HP : MonoBehaviour,IDamage
{
    /// <summary>
    /// playerのHP
    /// </summary>
    [SerializeField] int m_hp = 10;
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
    public IObservable<Unit> Player2Deth => playerHpSubject;

    [SerializeField] GameManager m_gameManager;
    [SerializeField] AudioClip m_audioClip;
    void Awake()
    {
        hp.Value = m_hp;
    }
    private void Start()
    {
      
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
