using BepInEx.Unity.IL2CPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTFO.Ext.PartialData.Utils
{
    internal static class InheritanceUtil
    {
        public const string GUID = "Dinorush.InheritanceDataBlocks";
        public static readonly bool HasInheritance;

        static InheritanceUtil()
        {
            HasInheritance = IL2CPPChainloader.Instance.Plugins.ContainsKey(GUID);
        }
    }
}
