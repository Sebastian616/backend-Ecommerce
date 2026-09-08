namespace OrbisaAsp.Data.Models
{
    public class Product
    {
        private int id {  get; set; }
        private List<string> images { get; set; }
        private string name { get; set; }
        private SizeType size { get; set; }
        private string color { get; set; }
        private GenderType gender { get; set; }
        private string description { get; set; }
        private bool isAbled { get; set; }
    }

    public enum SizeType
    {
        XS = 1,
        S = 2,
        M = 3,
        L = 4,
        XL = 5,
        XXL = 6
    }

    public enum GenderType
    {
        MALE = 1,
        FEMALE = 2,
        UNISEX = 3
    }
}
