using System.Runtime.InteropServices;

namespace Fluent.Metro.Native
{
#pragma warning disable 1591
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {     
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public RECT rcMonitor = new RECT(); 
        public RECT rcWork = new RECT();           
        public int dwFlags = 0;
    }
}