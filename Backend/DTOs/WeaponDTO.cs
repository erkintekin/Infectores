namespace Backend.DTOs
{
    public class WeaponDTO
    {
        public required string Name { get; set; }
        public required string DamageDice { get; set; }
        public int Range { get; set; }
        public float Weight { get; set; }
    }
}