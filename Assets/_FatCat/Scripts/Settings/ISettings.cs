namespace InterfaceHolder
{
    public interface ISettings<T, T1>
    {
        public T CurrentSettings { get; }
        K GetSettings<K>() where K : T1;
        void RegisterInterface<K>(T1 interfaceToRegister) where K : T1;
    }
}