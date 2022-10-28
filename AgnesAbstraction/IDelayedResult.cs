public interface IDelayedResult<T>
{
	bool IsCompleted { get; }

	T Result { get; }
}