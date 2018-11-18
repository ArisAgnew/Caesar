namespace Caesar
{
    public interface ISupplier<T>
    {
        /// <summary>
        /// It gets some result
        /// </summary>
        /// <returns>
        /// a <typeparamref name="T"/> result
        /// </returns>
        T Get();
    }
}
