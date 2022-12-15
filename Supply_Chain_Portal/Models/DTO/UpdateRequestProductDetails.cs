namespace Supply_Chain_Portal.Models.DTO
{
    public class UpdateRequestProductDetails
    {
        public string BoardNumber { get; set; }
        public string PartNumber { get; set; }
        public String ProductType { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
