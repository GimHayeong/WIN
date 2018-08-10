using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfPhotoGallery
{
    public partial class WinPhotoGallery 
    {
        [DllImport("comctl32.dll"
            , EntryPoint = "TaskDialog"
            , PreserveSig = false
            , CharSet = CharSet.Unicode)]
        static extern TaskDialogResult TaskDialog(IntPtr hwndParent
            , IntPtr hInstance
            , string title
            , string mainInstruction
            , string content
            , TaskDialogButtons buttons
            , TaskDialogIcon icon);

        //        [DllImport("comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "TaskDialog")]
        //        static extern int TaskDialog(IntPtr hWndParent, IntPtr hInstance, String pszWindowTitle,
        //String pszMainInstruction, String pszContent, TaskDialogButtons dwCommonButtons, TaskDialogIcon pszIcon, out int pnButton);

        enum TaskDialogResult
        {
            Ok = 1,
            Cancel = 2,
            Retry = 4,
            Yes = 6,
            No = 7,
            Close = 8
        }

        [Flags]
        enum TaskDialogButtons
        {
            Ok = 0x0001,
            Yes = 0x0002,
            No = 0x0004,
            Cancel = 0x0008,
            Retry = 0x0010,
            Close = 0x0020
        }

        enum TaskDialogIcon
        {
            Warning = 65535,
            Error = 65534,
            Information = 65533,
            Shield = 65532
        }
    }
}
