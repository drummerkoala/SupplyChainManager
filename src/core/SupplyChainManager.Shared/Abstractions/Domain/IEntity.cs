using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyChainManager.Shared.Abstractions.Domain
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }

    // default is Guid
    public interface IEntity : IEntity<Guid> { }
}
