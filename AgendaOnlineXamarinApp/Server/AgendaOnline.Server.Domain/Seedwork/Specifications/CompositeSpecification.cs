﻿namespace AgendaOnline.Server.Domain.Seedwork.Specifications
{
    /// <summary>
    /// Base class for composite specifications
    /// </summary>
    /// <typeparam name="TEntity">Type of entity that check this specification</typeparam>
    public abstract class CompositeSpecification<TEntity>
         : Specification<TEntity>
         where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Left side specification for this composite element
        /// </summary>
        public abstract Specification<TEntity> LeftSideSpecification { get; }

        /// <summary>
        /// Right side specification for this composite element
        /// </summary>
        public abstract Specification<TEntity> RightSideSpecification { get; }

        #endregion
    }
}
