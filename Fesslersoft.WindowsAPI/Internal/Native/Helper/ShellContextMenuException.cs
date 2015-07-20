#region

using System;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.Helper
{
    internal class ShellContextMenuException : Exception
    {
        internal ShellContextMenuException()
        {
        }

        internal ShellContextMenuException(string message) : base(message)
        {
        }
    }
}