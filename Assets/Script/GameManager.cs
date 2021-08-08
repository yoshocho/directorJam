using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class GameManager : MonoBehaviour
{

    private bool m_gameStart= false;
    public bool GameStart
    {
        get { return m_gameStart; }
        set { m_gameStart = value; }
    }
    [SerializeField] Text m_player1Text = default;

    [SerializeField] Text m_player2Text = default;

    [SerializeField] Player1HP m_player1Hp;

    [SerializeField] Player2HP m_player2HP;

    void Start()
    {
        m_player1Hp.Player1Deth
             .Subscribe(_ => Player2Win());
        m_player2HP.Player2Deth
            .Subscribe(_ => Player1Win());
    }


   
    void Player1Win()
    {
        m_player1Text.text = "Win!!";
        m_player2Text.text = "Lose....";
    }

   void Player2Win()
    {
        m_player2Text.text = "Win!!";
        m_player1Text.text = "Lose....";
    }

}
