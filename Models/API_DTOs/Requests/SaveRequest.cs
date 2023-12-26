using System;

namespace Purchase_Order.Models.API_DTOs.Requests
{
    public class CreateRequest
    {
        public SaveRequest SaveRequest { get; set; }
    }
    public class SaveRequest
    {
        public string? vendor { get; set; }
        public string? vatRegistrationNumber { get; set; }
        public string? createdDate { get; set; }
        public string? expectedArrivalDate { get; set; }
        public string? buyer { get; set; }
        public string? paymentTerms { get; set; }
        public string? referenceDocument { get; set; }
        public string? shoppingPoint { get; set; }
        public string? material { get; set; }
        public DateTime? arrivalDate { get; set; }
        public int quantity { get; set; }
        public string? unitOfMeasure { get; set; }
        public string? unitPrice { get; set; }
        public string? vatPercentage { get; set; }
        public string? amountExcludingVAT { get; set; }
        public string? vatAmount { get; set; }
        public string? totalAmountIncludingVAT { get; set; }
    }
   

}
