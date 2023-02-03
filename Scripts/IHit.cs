namespace SnowballFight
{
    public interface IHit
    {
        public ThrowerType ThrowerType { get; }

        public void Hit();
    }
}