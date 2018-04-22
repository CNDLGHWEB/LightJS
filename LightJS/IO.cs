using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Jurassic.Library;
using Jurassic;
using System.Runtime.InteropServices;

namespace IOs
{
    #region 文件操作类
    // == File类
    public class File : ObjectInstance
    {
        public File(ScriptEngine engine)
            : base(engine)
        {
            PopulateFunctions();
        }

        // == JS引用
        [JSFunction(Name = "readfile")]
        public static string readfile(string openfile)
        {
            string str;
            using (FileStream fsRead = new FileStream(openfile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                string myStr = System.Text.Encoding.Default.GetString(heByte);
                str = myStr;
            }
            return str;
        }

        [JSFunction(Name = "savefile")]
        public static void savefile(string openfile, string text)
        {
            using (FileStream fsWrite = new FileStream(openfile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                string msg = text;
                byte[] myByte = System.Text.Encoding.Default.GetBytes(msg);
                fsWrite.Write(myByte, 0, myByte.Length);

            }

        }
    }
    #endregion
}
