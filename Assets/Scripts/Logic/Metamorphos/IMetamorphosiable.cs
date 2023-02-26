namespace Logic
{
    public interface IMetamorphosable
    {
        MetamorphosData GetMetamorphosData();
        void Metamorphos(MetamorphosData enteringMetamorphosData);
    }
}