namespace NetworkAbstractFactory
{
    public interface IFactory
    {
        public IMaterialHandler CreateMaterial();


        public ITextHandler CreateTextHandler();

    }
}