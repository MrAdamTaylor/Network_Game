namespace NetworkAbstractFactory.PlayerFactory
{
    public class PlayerFactory : IFactory
    {
        private MyNetworkPlayer _player;
        private int _playerCount;
        public PlayerFactory(MyNetworkPlayer player, int playersCount)
        {
            _player = player;
            _playerCount = playersCount;
        }

        public IMaterialHandler CreateMaterial()
        {
            return new PlayerMaterialHandler(_player);
        }

        public ITextHandler CreateTextHandler()
        {
            return new PlayerTextHandler(_player, _playerCount);
        }
    }
}