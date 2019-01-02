using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LC_Diagnostics
{
    public static class Diagnostics
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
