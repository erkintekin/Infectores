namespace Backend.DTOs
{
    public class ItemDTO // Görüntüleme için
    {
        public int ItemID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public float GP { get; set; }
        public required string ItemType { get; set; }
    }

    public class ItemCreateDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public float GP { get; set; }
        public int ItemTypeID { get; set; }
    }

    public class ItemUpdateDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public float GP { get; set; }
        public int ItemTypeID { get; set; }
    }
}