using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MouseClick : MonoBehaviour
{
    [Inject]
    private GameSceneManager m_gameSceneManager;

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
        m_gameSceneManager.m_sideClicked = side;
    }
}
