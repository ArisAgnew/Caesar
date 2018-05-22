namespace Caesar.FactoryAssembly
{
    public delegate (T1, T2) TupleDelegate<in T, T1, T2>(T entryType);
    public delegate (T1, T2, T3) TupleDelegate<in T, T1, T2, T3>(T entryType);
    public delegate (T1, T2, T3, T4) TupleDelegate<in T, T1, T2, T3, T4>(T entryType);
    public delegate (T1, T2, T3, T4, T5) TupleDelegate<in T, T1, T2, T3, T4, T5>(T entryType);
}
