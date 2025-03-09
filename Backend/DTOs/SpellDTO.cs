namespace Backend.DTOs
{
    public class SpellDTO // Görüntüleme için
    {
        public int SpellID { get; set; }
        public required string Name { get; set; }
        public required string Damage { get; set; }
        public required string DamageType { get; set; }
        public required string Description { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public required string CastingTime { get; set; }
        public required string School { get; set; }
        public bool IsCantrip { get; set; }
        public required List<string> Components { get; init; } = new();
    }

    public class SpellCreateDTO
    {
        public required string Name { get; set; }
        public required string Damage { get; set; }
        public int DamageTypeID { get; set; }
        public required string Description { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public required string CastingTime { get; set; }
        public required string School { get; set; }
        public bool IsCantrip { get; set; }
        public required List<int> ComponentIDs { get; init; } = new();
    }

    public class SpellUpdateDTO
    {
        public required string Name { get; set; }
        public required string Damage { get; set; }
        public int DamageTypeID { get; set; }
        public required string Description { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public required string CastingTime { get; set; }
        public required string School { get; set; }
        public bool IsCantrip { get; set; }
        public required List<int> ComponentIDs { get; init; } = new();
    }
}