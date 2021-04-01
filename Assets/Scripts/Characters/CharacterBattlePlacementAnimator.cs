using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattlePlacementAnimator : MonoBehaviour
{
    List<Character> _listOfTargets = new List<Character>();
    List <int> _listOfTargetIndex = new List<int>(); 
    BattlePlacement[] _targetBattlePlacements;
    Vector3 _initialPosition;
    
    // Start is called before the first frame update
    void Awake()
    {
        _initialPosition = transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     public virtual void SetBattlePlacements(List<int> index, BattlePlacement[] targetBattlePlacements, List<Character> listOfTargets)
    {
            _listOfTargets = listOfTargets;
            _listOfTargetIndex = index;
            _targetBattlePlacements = targetBattlePlacements;
    }

    public virtual void TeleportToBattlePlacement()
    {
        StartCoroutine(MoveToBattlePlacement(_targetBattlePlacements[_listOfTargetIndex[0]].frontBattlePlacement.transform.position, 1000f));
    }

    public virtual void TeleportToRangedBattlePlacement()
    {
        StartCoroutine(MoveToBattlePlacement(_targetBattlePlacements[_listOfTargetIndex[0]].rangedBattlePlacement.transform.position, 1000f));     
    }

    public virtual void TeleportBackToInitialPos()
    {
        StartCoroutine(MoveToBattlePlacement(_initialPosition, 1000f));
    }

    public IEnumerator MoveToBattlePlacement(Vector3 target, float speed)
    {
        while(Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target , speed*Time.deltaTime);
            yield return null;
        }
    }

}
