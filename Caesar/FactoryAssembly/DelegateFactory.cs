namespace Caesar
{
    public delegate void Consumer<in TInput>(TInput input);
    public delegate void BiConsumer<in T1Input, in T2Input>(T1Input t1Input, T2Input t2Input);

    public delegate TOutput Function<in TInput, out TOutput>(TInput input);
    public delegate TOutput BiFunction<in T1Input, in T2Input, out TOutput>(T1Input t1Input, T2Input t2Input);

    public delegate TIdentity UnaryOperator<TIdentity>(TIdentity identity);
    public delegate TIdentity BinaryOperator<TIdentity>(TIdentity t1Identity, TIdentity t2Identity);

    public delegate bool BiPredicate<in T1Input, in T2Input>(T1Input t1Input, T2Input t2Input);

    public delegate TOutput PrincipalSupplier<out TOutput>();
    public delegate bool BooleanSupplier();
}
