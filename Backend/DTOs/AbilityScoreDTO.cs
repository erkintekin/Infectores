namespace Backend.DTOs
{
    public class AbilityScoreDTO
    {
        public int AbilityScoreID { get; set; }
        public int Score { get; set; }
        public int Modifier { get; set; }
        public string Description { get; set; }
    }

    public class AbilityScoreCreateDTO
    {
        public int Score { get; set; }
        public string Description { get; set; }
    }

    public class AbilityScoreUpdateDTO
    {
        public int Score { get; set; }
        public string Description { get; set; }
    }
}