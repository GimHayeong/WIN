//#define TRIAL
//#define KEYDOWN
//#define CURVE
//#define FORMEVENT
//#define EVENTVIEW
//#define TIMER
//#define GDIPLUS
//#define IMAGE
//#define MENU
//#define CONTROLS
//#define LISTVIEW
//#define TREENODE
//#define PANEL
//#define FILESTREAM
//#define REGISTRY
//#define PRINT
//#define CLIPBOARD
#define ADONET
//#define DATASET

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if TRIAL
            CreateForm();
#endif

#if KEYDOWN
            Application.Run(new MouseDownForm());
#elif CURVE
            Application.Run(new CurveForm());
#elif FORMEVENT
            Application.Run(new FormLoadForm());
#elif EVENTVIEW
            Application.Run(new EventViewerForm());
#elif TIMER
            Application.Run(new TimerForm());
#elif GDIPLUS
            Application.Run(new GDIPlusForm());
#elif IMAGE
            Application.Run(new ImageForm());
#elif MENU
            Application.Run(new MenuForm());
#elif CONTROLS
            Application.Run(new ControlForm());
#elif LISTVIEW
            Application.Run(new ListViewForm());
#elif TREENODE
            Application.Run(new TreeViewForm());
#elif PANEL
            Application.Run(new PanelForm());
#elif FILESTREAM
            Application.Run(new FileStreamForm());
#elif REGISTRY
            Application.Run(new RegistryForm());
#elif PRINT
            Application.Run(new PrintForm());
#elif CLIPBOARD
            Application.Run(new ClipboardForm());
#elif ADONET
            Application.Run(new ADOForm());
#elif DATASET
            Application.Run(new DataSetForm());
#else
            Application.Run(new MDHForm());
#endif

        }

        private static void CreateForm()
        {
#if TRIAL
            MDHForm frm = new MDHForm();
            frm.Text = "MDH로 만든 폼";
            frm.Width = 400;
            frm.Height = 200;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.MaximizeBox = false;
            frm.BackColor = System.Drawing.Color.Blue;
            frm.Opacity = 0.8;
            Application.Run(frm);
#endif
        }
    }
}
