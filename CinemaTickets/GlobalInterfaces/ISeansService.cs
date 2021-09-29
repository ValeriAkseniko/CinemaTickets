using System;

namespace CinemaTickets.GlobalInterfaces
{
    public interface ISeansService
    {
        void CreateSeanse(Guid filmId, Guid hallId, decimal price, DateTime start);
    }
}
