using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusChangedApproved(Booking booking);
        void TBookingStatusChangedApproved2(int id);

    }
}
