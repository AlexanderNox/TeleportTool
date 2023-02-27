namespace Logic.Metamorphos
{
    public interface IMetamorphosable
    {
        MetamorphosData GetMetamorphosData();
        void Metamorphos(MetamorphosData enteringMetamorphosData);
    }
}