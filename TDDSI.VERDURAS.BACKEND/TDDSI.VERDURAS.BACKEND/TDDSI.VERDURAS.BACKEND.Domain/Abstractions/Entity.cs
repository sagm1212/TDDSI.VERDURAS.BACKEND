﻿namespace TDDSI.VERDURAS.BACKEND.Domain.Abstractions;
public abstract class Entity<T> : DomainEntity, IEntityBase<T> {
    protected Entity( bool enabled ) => Enabled = enabled;
    protected Entity() { }
    public virtual T Id { get; init; } = default!;
    public bool Enabled { get; init; }
}