namespace Knox.DDD.Abstractions
{
	public abstract class EntityBase<TId>
	{
		protected EntityBase(TId id)
		{
            Id = id;
		}

		public TId Id { get; protected set; }

		public override bool Equals(object obj)
		{
			if (obj is not EntityBase<TId> other)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (GetUnproxiedType(this) != GetUnproxiedType(other))
				return false;

			if (Id.Equals(default) || other.Id.Equals(default))
				return false;

			return Id.Equals(other.Id);
		}

		public static bool operator ==(EntityBase<TId> a, EntityBase<TId> b)
		{
			if (a is null && b is null)
				return true;

			if (a is null || b is null)
				return false;

			return a.Equals(b);
		}

		public static bool operator !=(EntityBase<TId> a, EntityBase<TId> b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return (GetUnproxiedType(this).ToString() + Id).GetHashCode();
		}
	}
}