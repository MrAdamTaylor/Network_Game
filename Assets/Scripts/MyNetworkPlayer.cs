using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text _displayNameText = null;
    [SerializeField] private Renderer _displayColourRenderer = null;
    
    [SyncVar(hook = nameof(HandleDisplayTextUpdated))] 
    [SerializeField] private string _displayName = "Missing Name";
    [SyncVar(hook = nameof(HandleDisplayColourUpdated))] 
    [SerializeField] private Color _playerColor;

    #region Server

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        _displayName = newDisplayName;
    }

    [Server]
    public void SetCollor(Color color)
    {
        _playerColor = color;
    }

    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        //TODO - расширить обработку...
        if (newDisplayName.Length < 2 || newDisplayName.Length > 20)
            return;

        RpcLogNewName(newDisplayName);
        SetDisplayName(newDisplayName);
    }

    #endregion

    #region Client

    private void HandleDisplayColourUpdated(Color oldColor, Color newColor)
    {
        _displayColourRenderer.material.SetColor("_BaseColor", newColor);
    }

    private void HandleDisplayTextUpdated(string oldText, string newText)
    {
        _displayNameText.text = newText;
    }

    [ContextMenu("SetMyName")]
    private void SetMyName()
    {
        CmdSetDisplayName("My New Name");
    }

    [ClientRpc]
    private void RpcLogNewName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }

    #endregion
}
