using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyChainManager.Shared.Abstractions.Domain
{
    public interface IUpdateAuditable
    {
        DateTime? UpdatedAt { get; set; }

        string? UpdatedBy { get; set; }
    }
}
