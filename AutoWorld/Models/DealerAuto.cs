namespace AutoWorld.Models
{
    public class DealerAuto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
