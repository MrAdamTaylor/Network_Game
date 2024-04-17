using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMoveTest : NetworkBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        if (isLocalPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 playerMovement = new Vector3(h * 0.25f, v * 0.25f, 0);

            var transform1 = transform;
            transform1.position = transform1.position + playerMovement * _speed * Time.deltaTime;
        }
    }
}
