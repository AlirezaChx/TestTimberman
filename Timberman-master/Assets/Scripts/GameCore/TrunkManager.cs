using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class TrunkManager : MonoBehaviour
{
    [SerializeField] GameObject trunkPrefab;
    [SerializeField] GameObject branchLeftPrefab;
    [SerializeField] GameObject branchRightPrefab;

    private List<GameObject> branches;
    private bool hasRoomToCreate;

    void Start()
    {
        branches = new List<GameObject>();
        for (int i = 0; i < 10; i += 2)
        {
            GameObject trunkEmpty = Instantiate(trunkPrefab, gameObject.transform, true);
            trunkEmpty.transform.localPosition = new Vector3(0, i * 2.43f, 0);
            branches.Add(trunkEmpty);
            //makes the first Branch Empty so the player Doesnt Die at Start
            
            GameObject trunkBranch = Instantiate(GetRandomBranch(), gameObject.transform, true);
            trunkBranch.transform.localPosition = new Vector3(0, (i + 1)*2.43f, 0);
            branches.Add(trunkBranch);
            //Get Branches Randomly From the prefabs..
        }
        
        
    }

    private GameObject GetRandomBranch()
    {
        int random = Random.Range(0, 100);
        if (random <= 10)
        {
            return trunkPrefab;
        }
        else if (random <= 55)
        {
            return branchLeftPrefab;
        }
        
        return branchRightPrefab;
    }
    public void CutTrunk(string _playerDirection)
    {
        branches[0].GetComponent<Trunk>().PlayDestroyAnimation(_playerDirection);
        //Destroy(branches[0]);
        branches.RemoveAt(0);

        int i = 0;
        for (i = 0; i < branches.Count; i++)
        {
            branches[i].transform.localPosition = new Vector3(branches[i].transform.localPosition.x, i * 2.43f,
                branches[i].transform.localPosition.z);
        }
        
        GameObject trunkEmpty = Instantiate(hasRoomToCreate ? trunkPrefab:GetRandomBranch(), gameObject.transform, true);
        trunkEmpty.transform.localPosition = new Vector3(0, i * 2.43f, 0);
        branches.Add(trunkEmpty);

        hasRoomToCreate = !hasRoomToCreate;
    }

    public string GetFirstTrunkDirection()
    {
        return branches[0].GetComponent<Trunk>().direction;
    }

    public void ResetTrunk()
    {
        for (int i = 0; i < branches.Count; i++)
        {
            Destroy(branches[i]);
        }
        branches.RemoveRange(0,branches.Count);
        Start();
    }
}
