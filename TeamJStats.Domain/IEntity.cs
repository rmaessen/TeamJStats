using System;

namespace TeamJStats.Domain
{
    public interface IEntity
    {
        long Id { get; set; }

        DateTime DateCreatedUtc { get; set; }

        DateTime DateUpdatedUtc { get; set; }

        EntityStatus EntityStatus { get; set; }
        
        bool Active { get; set; }
    }
}
