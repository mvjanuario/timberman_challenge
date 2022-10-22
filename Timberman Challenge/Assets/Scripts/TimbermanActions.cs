using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimbermanActions : MonoBehaviour
{
    [Inject]
    private GameSceneManager m_gameSceneManager;
    [Inject]
    private TreeManager m_treeManager;

    [SerializeField]
    private Animator m_playerAnimator;
    
    private Vector3 m_scale;
    private int m_currentSide;

    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        m_scale = this.transform.localScale;
        m_currentSide = -1;
    }

    // Update is called once per frame
    void Update()
    {
        m_playerAnimator.SetBool("Cuting", false);
        if(!dead){
            if(Input.GetMouseButtonDown(0)){
               CutTrunk();
            }
        }
    }

    private void CutTrunk(){
        SetSide();
        if(m_currentSide == m_gameSceneManager.m_sideClicked && m_treeManager.GetFirstBranchSide() == m_currentSide){
            SetDead();
        }

        m_treeManager.DestroyBranch();
        m_playerAnimator.SetBool("Cuting", true);

        m_gameSceneManager.SetScore(1);
    }

    private void SetSide(){
        if(m_gameSceneManager.m_sideClicked != m_currentSide){
            if(m_gameSceneManager.m_sideClicked > 0){
                this.transform.localPosition = new Vector3(2.75f, this.transform.localPosition.y, this.transform.localPosition.z);
                m_currentSide = 1;
            }else if(m_gameSceneManager.m_sideClicked < 0){
                this.transform.localPosition = new Vector3(-2.75f, this.transform.localPosition.y, this.transform.localPosition.z);
                m_currentSide = -1;
            }
            m_scale.x *= -1;
            this.transform.localScale = m_scale;
        }
    }

    public void SetDead(){
        m_scale.x = 1;
        this.transform.localScale = m_scale;
        m_playerAnimator.SetBool("Dead", true);
        dead = true;
        m_gameSceneManager.GameOver();
    }
}
