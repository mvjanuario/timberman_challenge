using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverScreen : MonoBehaviour
{
    [Inject]
    private GameSceneManager m_gameSceneManager;

    [SerializeField]
    private Text m_scoreText;
    [SerializeField]
    private Text m_bestScoreText;
    [SerializeField]
    private Text m_lastScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.SetLastScore();
    }

    public void SetLastScore(){
        m_lastScoreText.text = m_scoreText.text;
    }

    public void Restart(){
        m_gameSceneManager.RestartGame();
    }

    public void ShowScreen(){
        gameObject.SetActive(true);
    }

    public void HideScreen(){
        gameObject.SetActive(false);
    }
}
