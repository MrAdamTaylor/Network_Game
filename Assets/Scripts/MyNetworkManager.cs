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

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();

        player.SetDisplayName($"Player {numPlayers}");
        //Color rndCollor = Random.ColorHSV(0.1f, 0.1f,0.1f, 0.9f,0.9f, 0.9f);
        Color rndCollor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));
        player.SetCollor(rndCollor);
        
        Debug.Log($"There are now {numPlayers} players");
    }
}
