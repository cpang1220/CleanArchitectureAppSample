namespace JediAcademy.Back.Domain.Entities
{
    public class JediStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Species { get; set; }
        // Edited by CPang 2020-07-17 Challenge 3
        public string Planet { get; set; }
    }
}