namespace Backend.DTOs
{
    public class ArmorDTO
    {
        public int ArmorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public float Weight { get; set; }
        public float Cost { get; set; }
        public bool StealthDisadvantage { get; set; }
        public int StrengthRequirement { get; set; }
    }

    public class ArmorCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArmorClass { get; set; }
        public int ArmorTypeID { get; set; }
        public float Weight { get; set; }
        public float Cost { get; set; }
        public bool StealthDisadvantage { get; set; }
        public int StrengthRequirement { get; set; }
    }

    public class ArmorUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArmorClass { get; set; }
        public int ArmorTypeID { get; set; }
        public float Weight { get; set; }
        public float Cost { get; set; }
        public bool StealthDisadvantage { get; set; }
        public int StrengthRequirement { get; set; }
    }
}