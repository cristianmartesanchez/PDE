using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDE.App.Models;

namespace PDE.App.Services.Statement
{
    public interface IStatementService
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
    }
}
