namespace EatThis.Bll
{
    public interface IProduct
    {
        public decimal? Price { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Nutrients? Nutrients { get; set; }
        public double Calories { get; set; }
    }
}