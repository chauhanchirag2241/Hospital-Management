﻿using ASMSapi.Model;
using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IEmployeeRepository
    {
        public Task<int> createEmployee(Employee  employee);
    }
}
