namespace Backend.DTOs
{
    public class ItemDTO // Görüntüleme için
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float GP { get; set; }
        public string ItemType { get; set; }
    }

    public class ItemCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float GP { get; set; }
        public int ItemTypeID { get; set; }
    }

    public class ItemUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float GP { get; set; }
        public int ItemTypeID { get; set; }
    }
}