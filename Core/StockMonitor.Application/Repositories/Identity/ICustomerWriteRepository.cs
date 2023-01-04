﻿using StockMonitor.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor.Application.Repositories.Identity
{
    public interface ICustomerWriteRepository : IWriteRepository<Customer>
    {
    }
}
