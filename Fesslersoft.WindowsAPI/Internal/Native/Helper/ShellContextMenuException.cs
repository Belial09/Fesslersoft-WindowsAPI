#region

using System;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.Helper
{
    internal class ShellContextMenuException : Exception
    {
        /// <summary>Default contructor</summary>
        internal ShellContextMenuException()
        {
        }

        /// <summary>Constructor with message</summary>
        /// <param name="message">Message</param>
        internal ShellContextMenuException(string message)
            : base(message)
        {
        }
    }
}