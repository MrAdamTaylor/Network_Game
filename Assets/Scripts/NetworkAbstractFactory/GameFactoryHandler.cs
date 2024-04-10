namespace NetworkAbstractFactory
{
    public class GameFactoryHandler
    {
        private readonly IMaterialHandler _materialHandler;
        private readonly ITextHandler _textHandler;
    
        public GameFactoryHandler(IFactory factory)
        {
            _textHandler = factory.CreateTextHandler();
            _materialHandler = factory.CreateMaterial();
        }

        public void CustomizePlayer()
        {
            _materialHandler.SetMaterial();
            _textHandler.SetText();
        }
    }
}