namespace Backend.DTOs
{
    public class ClassDTO // Görüntüleme için
    {
        public int ClassID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int HitDice { get; set; }
        public required string PrimaryAbility { get; set; }
    }

    public class ClassCreateDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int HitDice { get; set; }
        public required string PrimaryAbility { get; set; }
    }

    public class ClassUpdateDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int HitDice { get; set; }
        public required string PrimaryAbility { get; set; }
    }
}