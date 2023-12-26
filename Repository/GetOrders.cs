using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Purchase_Order.Context;
using Purchase_Order.Interfaces;
using Purchase_Order.Models;
using Purchase_Order.Models.API_DTOs.Requests;
using Purchase_Order.Models.DbDTOs.Responses;

namespace Purchase_Order.Repository
{
    public class GetOrders : IGetOrders
    {
        public readonly taskContext _taskContext;
        public GetOrders(taskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public List<Orders> getallOrders()
        {
            var orders = from ph in _taskContext.TblPurHeaders
                        join v in _taskContext.TblVendors on ph.VendorId equals v.VendorId into vendorGroup
                        from vendor in vendorGroup.DefaultIfEmpty()
                        join pd in _taskContext.TblPurDetails on ph.PurHeaderId equals pd.PurHeaderId into detailGroup
                        from detail in detailGroup.DefaultIfEmpty()
                        select new 
                        {
                            Reference = ph.PurReference,
                            Vendor = vendor.Name,
                            CreatedDate = detail.CreatedDate.ToString("dd/MM/yyyy"),
                            Buyer = (vendor.Name == "Vendor 3" || vendor.Name == "Vendor 4" || vendor.Name == "Vendor 2") ? "John" : "Sara",
                            ExpectedArrivalDate = detail.PurExpectedArrivalDate,
                            ReferenceDocument = (vendor.Name == "Vendor 3" || vendor.Name == "Vendor 4") ? "123" : "S123",
                            AmountInclVAT = detail.PurAmountInclVat.ToString()
                        };

            var result = orders.OrderByDescending(item => item.Reference).ToList();
            var formattedOrders = result.AsEnumerable().Select(o => new Orders
            {
                Reference = o.Reference,
                Vendor = o.Vendor,
                CreatedDate = o.CreatedDate,
                Buyer = o.Buyer,
                ExpectedArrivalDate = o.ExpectedArrivalDate.ToString("dd/MM/yyyy"),
                ReferenceDocument = o.ReferenceDocument,
                AmountInclVAT = o.AmountInclVAT
            }).ToList();
            if (formattedOrders.Count() > 0)
            {
                return formattedOrders;
            }
            else
            {
                return null;
            }
        }

        public string savedata(SaveRequest save)
        {
            int id = 0;
            int venid = 0;
            int Purid = 0;
            int vendorID = 0;
            int PurDID = 0;
            id = _taskContext.TblMaterials.Max(u => u.MatId);

            if (save.vendor.Equals("Vendor 1"))
            {
                vendorID = 1;
            }
            if (save.vendor.Equals("Vendor 2"))
            {
                vendorID = 2;
            }
            if (save.vendor.Equals("Vendor 3"))
            {
                vendorID = 3;
            }
            _taskContext.Add(new TblMaterial()
            {
                MatRef = "MAT00" + id + 1,
                MatDesc = "Material " + id + 1,
                MatUom = "UOM" + id + 1,
                MatStandardCost = id + 1 * 100,
                CreatedDate = DateTime.ParseExact(save.createdDate, "yyyy-MM-dd", null),
                LastUpdatedDate = null
            });
            _taskContext.SaveChanges();
            venid = _taskContext.TblVendors.Max(u => u.VendorId);
            _taskContext.Add(new TblVendor()
            {
                Name = save.vendor,
                Tel = "123456789" + venid + 1,
                ExtAccNo = "EXT00" + venid + 1,
                Fax = "098765432" + venid + 1,
                Email = "vendor" + venid + 1 + "@example.com",
                Contact = "Contact " + venid + 1,
                Street = "Street " + venid + 1,
                Suburb = "Suburb " + venid + 1,
                City = "City" + venid + 1,
                PostalCode = "1234" + venid + 4,
                Country = "Country " + venid + 1,
                Vatno = "VAT00" + venid + 1,
                RegNo = save.vatRegistrationNumber,
                Vatperc = Decimal.Parse(save.vatPercentage)

            });
            _taskContext.SaveChanges();
            Purid = _taskContext.TblPurHeaders.Max(u => u.PurHeaderId);
            _taskContext.Add(new TblPurHeader()
            {
                PurReference = "PUR00" + Purid + 1,
                VendorId = vendorID,
                PurCreatedDate = DateTime.ParseExact(save.createdDate, "yyyy-MM-dd", null),
                PurExpectedArrivalDate = DateTime.ParseExact(save.expectedArrivalDate, "yyyy-MM-dd", null),
                PurSourceReference = "SRC00" + Purid + 1,
                PurAmountExclVat = Decimal.Parse(save.amountExcludingVAT),
                PurAmountVat = Decimal.Parse(save.vatAmount),
                PurAmountInclVat = Decimal.Parse(save.totalAmountIncludingVAT),
                Notes = "Note " + Purid + 1,
                CreatedDate =  DateTime.ParseExact(save.createdDate, "yyyy-MM-dd", null),
            });
            _taskContext.SaveChanges();
            Purid = _taskContext.TblPurHeaders.Max(u => u.PurHeaderId);
            id = _taskContext.TblMaterials.Max(u => u.MatId);

            PurDID = _taskContext.TblPurDetails.Max(u => u.PurDetailId);
            _taskContext.Add(new TblPurDetail()
            {
                PurHeaderId=Purid,
                PurMatId=id,
                PurExpectedArrivalDate= DateTime.ParseExact(save.expectedArrivalDate, "yyyy-MM-dd", null),
                PurQty=save.quantity,
                PurUoM=id,
                PurUnitPrice= Decimal.Parse(save.unitPrice),
                PurAmountExclVat= Decimal.Parse(save.amountExcludingVAT),
                PurAmountVat= Decimal.Parse(save.vatAmount),
                PurAmountInclVat= Decimal.Parse(save.totalAmountIncludingVAT),
                CreatedDate= DateTime.ParseExact(save.createdDate, "yyyy-MM-dd", null),
            });
            _taskContext.SaveChanges();

            return "Success";
        }
    }
}
