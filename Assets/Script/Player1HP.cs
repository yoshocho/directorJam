﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Player1HP : MonoBehaviour,IDamage
{
    /// <summary>
    /// playerのHP
    /// </summary>
    [SerializeField] int m_hp = 10;
    /// <summary>
    /// HPのリアクティブプロパティ
    /// </summary>
    ReactiveProperty<int> hp = new ReactiveProperty<int>();
    /// <summary>
    /// イベント発行のインスタンス
    /// </summary>
    private Subject<Unit> playerHpSubject = new Subject<Unit>();
    /// <summary>
    /// イベントの購読のみ公開
    /// </summary>
    public IObservable<Unit> Player1Deth => playerHpSubject;

    [SerializeField] GameManager m_gameManager;
    private void Start()
    {
        hp.Value = m_hp;
    }
    public void AddDamage(int damage)
    {
        hp.Value -= damage;
        if (hp.Value <= 0 && m_gameManager.m_gamrEnd == true)
        {
            playerHpSubject.OnNext(Unit.Default);
            m_gameManager.m_gamrEnd = false;
        }
    }
}
