using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class GameManager : MonoBehaviour
{
    [SerializeField] SceneChangeFade m_sceneChange;

    [SerializeField] Text m_player1Text = default;

    [SerializeField] Text m_player2Text = default;

    [SerializeField] Player1HP m_player1Hp;

    [SerializeField] Player2HP m_player2HP;

    void Start()
    {
        m_player1Hp.Player1Deth
             .Subscribe(_ => Player2Win());
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
