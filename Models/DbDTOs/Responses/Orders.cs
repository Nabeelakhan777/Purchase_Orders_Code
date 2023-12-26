namespace Purchase_Order.Models.DbDTOs.Responses
{
    public class Orders
    {
        public string Reference { get; set; }
        public string Vendor { get; set; }
        public string CreatedDate { get; set; }
        public string Buyer { get; set; }
        public string? ExpectedArrivalDate { get; set; }
        public string ReferenceDocument { get; set; }
        public string AmountInclVAT { get; set; }
    }
}
