using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private TimbermanActions m_timberman;
    [SerializeField]
    private GameOverScreen m_GameOverScreen;
    [SerializeField]
    private Text m_scoreText;
    [SerializeField]
    private Image m_lifeBar;

    private int m_score;
    private float m_totalTime = 10.0f;
    private float m_currentTime;

    public int m_sideClicked;

    void Start(){
        m_sideClicked = 0;

        m_score = 0;
        this.SetScore(m_score);

        m_currentTime = m_totalTime;
        this.SetLifeBar(m_currentTime / m_totalTime);
    }

    void Update()
    {
        m_currentTime -= Time.deltaTime;
        this.SetLifeBar(m_currentTime / m_totalTime);

        if(m_currentTime <= 0){
            m_timberman.SetDead();
        }
        Debug.Log(m_currentTime);
    }

    public void SetScore(int value){
        m_score += value;
        m_scoreText.text = "" + (m_score);
        m_currentTime += 0.30f;
    }

    public void SetLifeBar(float value){
        float total = 179.2f;
        m_lifeBar.transform.localPosition = new Vector3(0.2f - (total - (value * total)), m_lifeBar.transform.localPosition.y, m_lifeBar.transform.localPosition.z);
    }

    public void GameOver(){
       m_GameOverScreen.ShowScreen();
    }

    public void RestartGame(){
        m_GameOverScreen.HideScreen();

        string currentScene = SceneManager.GetActiveScene().name; 
        SceneManager.LoadScene(currentScene);
    }
}
