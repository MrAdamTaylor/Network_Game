using Mirror;
using UnityEngine;


public class MyNetworkManager : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log("We are connected!");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        
        Debug.Log($"There are now {numPlayers} players");
    }
}
