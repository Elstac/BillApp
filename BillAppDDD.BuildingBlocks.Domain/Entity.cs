using System;
using System.ComponentModel.DataAnnotations;

namespace BillAppDDD.BuildingBlocks.Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
