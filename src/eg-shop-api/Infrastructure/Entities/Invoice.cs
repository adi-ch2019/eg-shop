namespace EgShopApi.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
