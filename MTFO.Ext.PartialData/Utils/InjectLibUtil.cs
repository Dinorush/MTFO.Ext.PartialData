using BepInEx.Unity.IL2CPP;

namespace MTFO.Ext.PartialData.Utils
{
    internal static class InjectLibUtil
    {
        public const string GUID = "GTFO.InjectLib";
        public static readonly bool HasInjectLib;

        static InjectLibUtil()
        {
            HasInjectLib = IL2CPPChainloader.Instance.Plugins.ContainsKey(GUID);
        }
    }
}
