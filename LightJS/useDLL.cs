using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jurassic.Library;
using Jurassic;
using System.Runtime.InteropServices;

namespace Usedll
{
    class useDLL
    {
        #region DLL类
        public class dll
        {
            // == DLL引用
            [DllImport("kernel32")]
            public static extern int LoadLibraryA(string lib);
            [DllImport("kernel32")]
            public static extern void FreeLibrary(int dll);
            [DllImport("kernel32")]
            public static extern void GetProcAddress(int dll,string f);
            
        }

        #endregion
    }
}
