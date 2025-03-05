namespace Backend.DTOs
{
    public class ClassDTO // Görüntüleme için
    {
        public int ClassID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HitDice { get; set; }
        public string PrimaryAbility { get; set; }
    }

    public class ClassCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int HitDice { get; set; }
        public string PrimaryAbility { get; set; }
    }

    public class ClassUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int HitDice { get; set; }
        public string PrimaryAbility { get; set; }
    }
}