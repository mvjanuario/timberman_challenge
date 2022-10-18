using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]
    private GameSceneManager m_SceneManager;
    [SerializeField]
    private int side;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        m_SceneManager.m_sideClicked = side;
    }
}
