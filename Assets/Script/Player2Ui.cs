using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class Player2Ui : MonoBehaviour
{
    [SerializeField] Player2HP m_player2Hp;
    [SerializeField] Slider m_hpBar;
    int m_maxHp;
    void Start()
    {
        m_hpBar.value = 1;
        m_maxHp = m_player2Hp.hp.Value;
        m_player2Hp.hp.Subscribe(hp => UpdateHP(hp));
    }

    void UpdateHP(int hp)
    {
        m_hpBar.value = hp / (float)m_maxHp;
    }
}
