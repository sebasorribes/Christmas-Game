namespace Assets.Scripts.Interface
{
    public interface IEvolve
    {
        public int GetPointsToEvolve();
        public void SetPointsToEvolve(int points);
        public bool CanEvolve(int points);
        public void Evolve();
    }
}
