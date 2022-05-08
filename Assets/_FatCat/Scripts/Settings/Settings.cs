using Sirenix.OdinInspector;

namespace ChoojlandGames
{
    public abstract class Settings<T, T1> : SerializedScriptableObject, ISettings<T, T1> where T : Settings<T, T1> where T1 : ISettingsInfo
    {
        public abstract T CurrentSettings { get; }

        public abstract K GetSettings<K>() where K : T1;

        public abstract void RegisterInterface<K>(T1 interfaceToRegister) where K : T1;
    }
}