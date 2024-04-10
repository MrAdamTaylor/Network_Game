using UnityEngine;

namespace NetworkAbstractFactory.PlayerFactory
{
    class PlayerMaterialHandler : IMaterialHandler
    {
        private MyNetworkPlayer _networkPlayer;
    
        public PlayerMaterialHandler(MyNetworkPlayer player)
        {

            _networkPlayer = player;
        
        }

        public void SetMaterial()
        {
            Color rndCollor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f));
        
            _networkPlayer.SetCollor(rndCollor);
        }
    }
}