using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeChanger.Ani.FilterTypes
{
    internal static class FilterController
    {
        internal static int GetFilterType(string TypeString)
        {
            switch (TypeString.ToLower())
            {
                case "replace":
                    return (int)TypeInt.Replace;
                case "whitelist":
                    return (int)TypeInt.Whitelist;
                case "blacklist":
                    return (int)TypeInt.Blacklist;
                case "removefromstart":
                    return (int)TypeInt.RemoveFromStart;
                case "removefromchar":
                    return (int)TypeInt.RemoveFromChar;
                case "removeinbetween":
                    return (int)TypeInt.RemoveInBetween;
                case "basicadd":
                    return (int)TypeInt.BasicAdd;
                default:
                    return (int)TypeInt.BasicFilter;
            }
        }
    }
}
