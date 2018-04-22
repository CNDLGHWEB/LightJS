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
//开始进行内部引用
using Input;
using IOs;
using Usedll;

namespace LightJS
{
    #region Form1类
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void InitJSc(Jurassic.ScriptEngine engine)
        {
            engine.SetGlobalValue("System",new Main(engine));
            engine.SetGlobalValue("fs", new File(engine));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // =- 初始化
            Jurassic.ScriptEngine engine = new Jurassic.ScriptEngine();
            InitJSc(engine);
            // =- 命令行判断
            string openfile;
            if (Environment.GetCommandLineArgs().Length == 1)
            {
                openfile = "lightjs.js";
            }else{
                openfile = Environment.GetCommandLineArgs()[2];
            }
            // =- 读入
            string str=IOs.File.readfile(openfile);
            // =- 执行
            engine.Execute(str);
            
            Application.Exit();
        }
       
    }
    #endregion
    #region System类
    // == Main类
    public class Main : ObjectInstance
    {
        public Main(ScriptEngine engine)
            : base(engine)
        {
            PopulateFunctions();
        }
        // == DLL引用
        [DllImport("user32.dll")]
        private extern static int MessageBoxA(int hwnd,string text,string title,int icons);

        // == JS引用
        [JSFunction(Name = "SuperMsgBox")]
        public static int SuperMsgBox(string text, string title,int icons)
        {
            return MessageBoxA(0, text, title, icons);
        }

        [JSFunction(Name = "MsgBox")]
        public static void MsgBox(string text,string title)
        {
            MessageBox.Show(text,title);
        }

        [JSFunction(Name = "Exit")]
        public static void Exit()
        {
            Application.Exit();
        }

        [JSFunction(Name = "eggs")]
        public static void eggs()
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        [JSFunction(Name = "Input")]
        public static string Input(string text,string title,bool use)
        {
            char pwds = '*';
            if (use)
            {
                return InputBox.PShowInputBox(text, title, pwds);
            }
            return InputBox.ShowInputBox(text, title);
        }
    }
    #endregion
    

}
