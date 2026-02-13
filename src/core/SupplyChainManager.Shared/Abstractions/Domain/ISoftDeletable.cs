using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyChainManager.Shared.Abstractions.Domain
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedAt { get; set; }

        string? DeletedBy { get; set; }
    }
}
