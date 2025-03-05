namespace Backend.DTOs
{
    public class ArmorDTO
    {
        public string Name { get; set; }
        public int BaseAC { get; set; }
        public int DexterityModifier { get; set; }
        public bool StealthDisadvantage { get; set; }
    }
}