﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface ISeansService
    {
        void CreateSeanse(Guid filmId, Guid hallId, decimal price, DateTime start);
    }
}
