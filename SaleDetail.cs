namespace IoonSistema
{
    public class SaleDetail
    {
        public Guid DetailId { get; set; }
        public Guid SaleId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
