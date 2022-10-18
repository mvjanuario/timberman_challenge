using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_trunkPrefab;
    [SerializeField]
    private GameObject m_leftBranchPrefab;
    [SerializeField]
    private GameObject m_rightBranchPrefab;

    private List<GameObject> m_branches;

    // Start is called before the first frame update
    void Start()
    {
        m_branches = new List<GameObject>();
        StartTree();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartTree(){
        GameObject initialTrunk = Instantiate(m_trunkPrefab);
        initialTrunk.transform.parent = this.transform;
        initialTrunk.transform.localPosition = new Vector3(0, 0, 0);
        m_branches.Add(initialTrunk);

        for(int i = 1; i < 10; i++){
            GameObject randomBranch = Instantiate(SetBranch());
            randomBranch.transform.parent = this.transform;
            randomBranch.transform.localPosition = new Vector3(0, (i * 2.43f), 0);
            m_branches.Add(randomBranch);
        }
    }

    private void CreateNewBranch(){
        for(int i = 0; i < m_branches.Count; i++){
            m_branches[i].transform.localPosition = new Vector3(0, ((i * 2.43f) - 2.43f), 0);
        }

        GameObject randomBranch = Instantiate(SetBranch());
        randomBranch.transform.parent = this.transform;
        randomBranch.transform.localPosition = new Vector3(0, (11 * 2.43f), 0);
        m_branches.Add(randomBranch);
    }

    private GameObject SetBranch(){
        int random = Random.Range(0, 3);
        if(random == 0){
            return m_trunkPrefab;
        }else if(random == 1){
            return m_leftBranchPrefab;
        }else{
            return m_rightBranchPrefab;
        }
    }

    public void DestroyBranch(){
        CreateNewBranch();
        Destroy(m_branches[0]);
        m_branches.RemoveAt(0);
    }

    public int GetFirstBranchSide(){
        if(m_branches[1].GetComponent<Branch>().side == -1){
            return -1;
        }else if(m_branches[1].GetComponent<Branch>().side == 1){
            return 1;
        }else{
            return 0;
        }
    }
}
