namespace IoonSistema
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid UserId { get; set; }
        public Guid CommerceId { get; set; }
        public Guid State { get; set; }
    }

}
