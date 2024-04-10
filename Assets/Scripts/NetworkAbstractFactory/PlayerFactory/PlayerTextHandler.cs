namespace NetworkAbstractFactory.PlayerFactory
{
    class PlayerTextHandler : ITextHandler
    {
        private MyNetworkPlayer _player;
        private int _count;
    
        public PlayerTextHandler(MyNetworkPlayer player, int playerCount)
        {
            _player = player;
            _count = playerCount;
        }


        public void SetText()
        {
            _player.SetDisplayName($"Player {_count}");
        }
    }
}