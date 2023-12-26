using Purchase_Order.Models.API_DTOs.Requests;
using Purchase_Order.Models.DbDTOs.Responses;

namespace Purchase_Order.Interfaces
{
    public interface IGetOrders
    {
        List<Orders> getallOrders();
        string savedata(SaveRequest save);
    }
}
