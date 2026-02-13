using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyChainManager.Shared.Abstractions.Domain
{
    public interface ICreateAuditable
    {
        DateTime? CreatedAt { get; set; }

        string? CreatedBy { get; set; }
    }
}
