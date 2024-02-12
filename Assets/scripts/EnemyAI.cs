using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public float _viewAngle;
    private bool _isPlayerNoticed;
    public List<Transform> patrolPoint;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    void Start()
    {
        initcomponentlinks();
        
        PickNewPatrolPoint();
    }

    private void initcomponentlinks() 
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        Debug.Log(_isPlayerNoticed);
        NoticedPlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        
    }
    private void NoticedPlayerUpdate()
    {
         var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < _viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
                
            }
            
        }
    }
    private void PatrolUpdate() 
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }

    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoint[Random.Range(0, patrolPoint.Count)].position;
    }
}
