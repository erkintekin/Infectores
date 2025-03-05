namespace Backend.DTOs
{
    public class SpellDTO // Görüntüleme için
    {
        public int SpellID { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string Description { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public string CastingTime { get; set; }
        public string School { get; set; }
        public bool IsCantrip { get; set; }
        public List<string> Components { get; set; }
    }

    public class SpellCreateDTO
    {
        public string Name { get; set; }
        public string Damage { get; set; }
        public int DamageTypeID { get; set; }
        public string Description { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public string CastingTime { get; set; }
        public string School { get; set; }
        public bool IsCantrip { get; set; }
        public List<int> ComponentIDs { get; set; }
    }

    public class SpellUpdateDTO
    {
        public string Name { get; set; }
        public string Damage { get; set; }
        public int DamageTypeID { get; set; }
        public string Description { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public string CastingTime { get; set; }
        public string School { get; set; }
        public bool IsCantrip { get; set; }
        public List<int> ComponentIDs { get; set; }
    }
}