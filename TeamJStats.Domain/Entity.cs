using System;

namespace TeamJStats.Domain
{
    public abstract class Entity : IEntity
    {
        public long Id { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public DateTime DateUpdatedUtc { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public bool Active { get; set; }
    }
}