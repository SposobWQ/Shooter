using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public float _viewAngle;
    private bool _isPlayerNoticed;
    public List<Transform> PatrolPoint;
    private NavMeshAgent _NavMeshAgent;
    public PlayerController Player;
    void Start()
    {
        initcomponentlinks();
        
        PickNewPatrolPoint();
    }

    private void initcomponentlinks() 
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        
        NoticedPlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        
    }
    private void NoticedPlayerUpdate()
    {
         var direction = Player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < _viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
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
            if (_NavMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _NavMeshAgent.destination = Player.transform.position;
        }

    }
    private void PickNewPatrolPoint()
    {
        _NavMeshAgent.destination = PatrolPoint[Random.Range(0, PatrolPoint.Count)].position;
    }
}
