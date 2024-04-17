using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

public class NewPlayerMove : NetworkBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent = null;

    private Camera _mainCamera;
    
    private void Update()
    {
        if (isLocalPlayer)
        {
            if (!Input.GetMouseButtonDown(1)) { return; }

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) { return; }
            
            MakeStep(hit.point);
        }

    }

    private void MakeStep(Vector3 position)
    {
        if (!NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
        {
            return;
        }

        _agent.SetDestination(position);
    }
    
    public override void OnStartAuthority()
    {
        _mainCamera = Camera.main;
    }
}
