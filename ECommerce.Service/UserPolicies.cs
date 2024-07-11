
using ECommerce.Service.Attributes;

namespace ECommerce.Service
{
    public enum Policy
    {
        [Roles([Role.Admin])]
        AdminRights,

        [Roles([Role.Customer,Role.Admin])]
        BuyerRights,
    }
}
