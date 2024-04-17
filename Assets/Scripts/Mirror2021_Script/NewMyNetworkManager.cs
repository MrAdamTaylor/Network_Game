using Mirror;
using NetworkAbstractFactory;
using NetworkAbstractFactory.PlayerFactory;
using UnityEngine;


public class NewMyNetworkManager : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log("We are connected!");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        //MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();

        NewNetworkPlayer player = conn.identity.GetComponent<NewNetworkPlayer>();

        player.SetDisplayName($"Player {numPlayers}");

        Color displayColour = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));

        player.SetColor(displayColour);
        
        /*MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        var playerFactory = new PlayerFactory(player, numPlayers);
        var factoryHandler = new GameFactoryHandler(playerFactory);
        factoryHandler.CustomizePlayer();*/

        Debug.Log($"There are now {numPlayers} players");
    }
}