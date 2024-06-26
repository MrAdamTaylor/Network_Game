using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class NewNetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text _displayNameText = null;
    [SerializeField] private Renderer _displayColourRenderer = null;

    [SyncVar(hook = nameof(HandleDisplayTextUpdated))] 
    [SerializeField] private string _displayName = "Missing Name";
    [SyncVar(hook = nameof(HandleDisplayColourUpdated))] 
    [SerializeField] private Color _playerColor;

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        _displayName = newDisplayName;
    }

    [Server]
    public void SetColor(Color color)
    {
        _playerColor = color;
    }

    private void HandleDisplayColourUpdated(Color oldColor, Color newColor)
    {
        _displayColourRenderer.material.SetColor("_BaseColor", newColor);
    }

    private void HandleDisplayTextUpdated(string oldText, string newText)
    {
        _displayNameText.text = newText;
    }
}
