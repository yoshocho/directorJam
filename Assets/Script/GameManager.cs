using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    

    bool m_gameStart= false;
    public bool GameStart
    {
        get { return m_gameStart; }
        set { m_gameStart = value; }
    }

    public bool m_gamrEnd;
    [SerializeField] Text m_player1Text = default;

    [SerializeField] Text m_player2Text = default;

    [SerializeField] Player1HP m_player1Hp;

    [SerializeField] Player2HP m_player2HP;

    [SerializeField] SceneChangeFade m_sceneManager;

    [SerializeField] string m_titleScene = "";

    [SerializeField] float m_fadeTime = 2f;

    [SerializeField] GameObject m_retryButton;

    void Start()
    {
       // m_retryButton.gameObject.SetActive(false);
        m_player1Hp.Player1Deth
             .Subscribe(_ => Player2Win());
        m_player2HP.Player2Deth
            .Subscribe(_ => Player1Win());
    }


   
    void Player1Win()
    {
        m_player1Text.text = "Win!!";
        m_player2Text.text = "Lose....";
        m_retryButton.gameObject.SetActive(true);
    }

   void Player2Win()
    {
        m_player2Text.text = "Win!!";
        m_player1Text.text = "Lose....";
        m_retryButton.gameObject.SetActive(true);
    }

    public void Retry()
    {
        //m_sceneManager.LoadSceneWithFade(m_fadeTime, m_retryScene);
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);

    }

    public void Title()
    {
        
        m_sceneManager.LoadSceneWithFade(m_fadeTime, m_titleScene);
    }

}
