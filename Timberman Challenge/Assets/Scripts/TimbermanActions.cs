using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimbermanActions : MonoBehaviour
{
    [SerializeField]
    private GameSceneManager m_SceneManager;
    [SerializeField]
    private TreeManager m_TreeManager;
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
        if(m_currentSide == m_SceneManager.m_sideClicked && m_TreeManager.GetFirstBranchSide() == m_currentSide){
            SetDead();
        }

        m_TreeManager.DestroyBranch();
        m_playerAnimator.SetBool("Cuting", true);

        m_SceneManager.SetScore(1);
    }

    private void SetSide(){
        if(m_SceneManager.m_sideClicked != m_currentSide){
            if(m_SceneManager.m_sideClicked > 0){
                this.transform.localPosition = new Vector3(2.75f, this.transform.localPosition.y, this.transform.localPosition.z);
                m_currentSide = 1;
            }else if(m_SceneManager.m_sideClicked < 0){
                this.transform.localPosition = new Vector3(-2.75f, this.transform.localPosition.y, this.transform.localPosition.z);
                m_currentSide = -1;
            }
            m_scale.x *= -1;
            this.transform.localScale = m_scale;
        }
    }

    public void SetDead(){
        m_playerAnimator.SetBool("Dead", true);
        dead = true;
        m_SceneManager.GameOver();
    }
}
