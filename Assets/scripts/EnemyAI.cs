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
    public float _damage = 30;
   [SerializeField] private PlayerHealth _playerhealth;
    
    void Start()
    {
        initcomponentlinks();  
        PickNewPatrolPoint();
        
    }

    private void initcomponentlinks() 
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        
    }


   private void Update()
    {
        
        AttackUpdate();
        NoticedPlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_NavMeshAgent.remainingDistance <= _NavMeshAgent.stoppingDistance)
            {
                 
               _playerhealth.DealDamage(_damage * Time.deltaTime);
            }
        }
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
            if (_NavMeshAgent.remainingDistance == _NavMeshAgent.stoppingDistance)
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
