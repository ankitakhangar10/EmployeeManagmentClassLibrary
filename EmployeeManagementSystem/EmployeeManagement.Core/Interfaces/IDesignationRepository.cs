using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IDesignationRepository
    {
        Task<List<Designations>> getAllDesignation();
        Task AddDsignation(Designations designation);
    }
}