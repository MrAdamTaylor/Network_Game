using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;

    private Camera _mainCamera;
    
    #region Server
    [Command(requiresAuthority = true)]
    private void CmdMove(Vector3 position)
    {
        if (!NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
        {
            return;
        }

        _agent.SetDestination(position);
    }
    
    #endregion

    #region Client

    [ClientCallback]
    private void Update()
    {
        if (!isOwned) { return; }

        if (!Input.GetMouseButtonDown(1)) { return; }

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) { return; }
        
        CmdMove(hit.point);
    }

    public override void OnStartAuthority()
    {
       _mainCamera = Camera.main;
    }

    #endregion
}