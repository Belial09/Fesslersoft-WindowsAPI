#region

using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.SHFileOperation
{
    internal static class DllImports
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        internal static extern int SHFileOperation(ref Structs.SHFILEOPSTRUCT FileOp);
    }
}