using Mirror;
using NetworkAbstractFactory;
using NetworkAbstractFactory.PlayerFactory;
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

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        var playerFactory = new PlayerFactory(player, numPlayers);
        var factoryHandler = new GameFactoryHandler(playerFactory);
        factoryHandler.CustomizePlayer();

        Debug.Log($"There are now {numPlayers} players");
    }
}