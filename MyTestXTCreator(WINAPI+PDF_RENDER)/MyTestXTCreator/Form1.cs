using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestXTCreator
{
    public partial class Form1 : Form
    {
        public string _editor = "editor.exe";


        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(
             [In] int X,
             [In] int Y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            [In] uint dwFlags,
            [In] uint dx,
            [In] uint dy,
            [In] int dwData,
            [In] uint dwExtraInfo);
        public enum MouseEvents
        {
            MOUSEEVENTF_LEFTDOWN = 0x02,
            MOUSEEVENTF_LEFTUP = 0x04,
            MOUSEEVENTF_RIGHTDOWN = 0x08,
            MOUSEEVENTF_RIGHTUP = 0x10,
            MOUSEEVENTF_WHEEL = 0x0800,
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

        public enum KeyBoardEvents
        {
            VK_LBUTTON = 0x01,
            VK_RBUTTON = 0x02,
            VK_MBUTTON = 0x04,
            VK_XBUTTON1 = 0x05,
            VK_XBUTTON2 = 0x06,
            VK_ESCAPE = 0x1B,
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            VK_SHIFT = 0x10,
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_CONTROL = 0x11,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_MENU = 0x12,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5,
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_CAPITAL = 0x14,
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            VK_PAUSE = 0x13,
            VK_CANCEL = 0x03,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_CLEAR = 0x0C,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_PRINT = 0x2A,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,
            VK_0 = 0x30,
            VK_1 = 0x31,
            VK_2 = 0x32,
            VK_3 = 0x33,
            VK_4 = 0x34,
            VK_5 = 0x35,
            VK_6 = 0x36,
            VK_7 = 0x37,
            VK_8 = 0x38,
            VK_9 = 0x39,
            VK_A = 0x41,
            VK_B = 0x42,
            VK_C = 0x43,
            VK_D = 0x44,
            VK_E = 0x45,
            VK_F = 0x46,
            VK_G = 0x47,
            VK_H = 0x48,
            VK_I = 0x49,
            VK_J = 0x4A,
            VK_K = 0x4B,
            VK_L = 0x4C,
            VK_M = 0x4D,
            VK_N = 0x4E,
            VK_O = 0x4F,
            VK_P = 0x50,
            VK_Q = 0x51,
            VK_R = 0x52,
            VK_S = 0x53,
            VK_T = 0x54,
            VK_U = 0x55,
            VK_V = 0x56,
            VK_W = 0x57,
            VK_X = 0x58,
            VK_Y = 0x59,
            VK_Z = 0x5A,
            VK_APPS = 0x5D,
            VK_SLEEP = 0x5F,
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_RETURN = 0x0D,
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_F13 = 0x7C,
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87,
            VK_BROWSER_BACK = 0xA6,
            VK_BROWSER_FORWAR = 0xA7,
            VK_BROWSER_REFRES = 0xA8,
            VK_BROWSER_STOP = 0xA9,
            VK_BROWSER_SEARCH = 0xAA,
            VK_BROWSER_FAVORI = 0xAB,
            VK_BROWSER_HOME = 0xAC,
            VK_VOLUME_MUTE = 0xAD,
            VK_VOLUME_DOWN = 0xAE,
            VK_VOLUME_UP = 0xAF,
            VK_MEDIA_NEXT_TRA = 0xB0,
            VK_MEDIA_PREV_TRA = 0xB1,
            VK_MEDIA_STOP = 0xB2,
            VK_MEDIA_PLAY_PAU = 0xB3,
            VK_LAUNCH_MAIL = 0xB4,
            VK_LAUNCH_MEDIA_S = 0xB5,
            VK_LAUNCH_APP1 = 0xB6,
            VK_LAUNCH_APP2 = 0xB7,
            VK_OEM_1 = 0xBA,
            VK_OEM_PLUS = 0xBB,
            VK_OEM_COMMA = 0xBC,
            VK_OEM_MINUS = 0xBD,
            VK_OEM_PERIOD = 0xBE,
            VK_OEM_2 = 0xBF,
            VK_OEM_3 = 0xC0,
            VK_OEM_4 = 0xDB,
            VK_OEM_5 = 0xDC,
            VK_OEM_6 = 0xDD,
            VK_OEM_7 = 0xDE,
            VK_OEM_8 = 0xDF,
            VK_OEM_102 = 0xE2,
            VK_PROCESSKEY = 0xE5,
            VK_PACKET = 0xE7,
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE,
            VK_KANA = 0x15,
            VK_IME_ON = 0x16,
            VK_JUNJA = 0x17,
            VK_FINAL = 0x18,
            VK_KANJI = 0x19,
            VK_IME_OFF = 0x1A,
            VK_CONVERT = 0x1C,
            VK_NONCONVERT = 0x1D,
            VK_ACCEPT = 0x1E,
            VK_MODECHANGE = 0x1F,
            KEYEVENTF_KEYUP = 0x0002,
        }


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private void BringToFront(Process pTemp)
        {
            SetForegroundWindow(pTemp.MainWindowHandle);
        }


        void Render(string source_path, string dest_name, bool delete_source = true)
        {
            string pyton_render_file = "ptest.py"; // -i input, -o output file name
            try { Process.Start(new ProcessStartInfo { FileName = pyton_render_file, Arguments = $" -i \"{Path.GetFullPath(source_path)}\" -o \"{dest_name}\"", WindowStyle = ProcessWindowStyle.Hidden }).WaitForExit(); } catch { } // render
            //HtmlConverter.ConvertToPdf(new FileInfo(ipath), new FileInfo(opath)); //iText.Html2pdf
            if (delete_source) { try { File.Delete(source_path); } catch { } }
        }

        void TAB()
        {
            keybd_event((uint)KeyBoardEvents.VK_TAB, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_TAB, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
        }
        void SHIFT_TAB()
        {
            keybd_event((uint)KeyBoardEvents.VK_LSHIFT, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_TAB, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_TAB, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_LSHIFT, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
        }
        void LEFT()
        {
            keybd_event((uint)KeyBoardEvents.VK_LEFT, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_LEFT, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
        }
        void DOWN()
        {
            keybd_event((uint)KeyBoardEvents.VK_DOWN, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_DOWN, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
        }
        void CTRL_A()
        {
            keybd_event((uint)KeyBoardEvents.VK_CONTROL, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_A, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_A, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_CONTROL, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
        }
        void CTRL_C()
        {
            keybd_event((uint)KeyBoardEvents.VK_CONTROL, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_C, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_C, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
            keybd_event((uint)KeyBoardEvents.VK_CONTROL, 0, (uint)KeyBoardEvents.KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(10);
        }
        void Click(uint X, uint Y)
        {
            SetCursorPos((int)X, (int)Y);
            mouse_event((uint)MouseEvents.MOUSEEVENTF_LEFTDOWN | (uint)MouseEvents.MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        void TakeScreenShot(string filename = "tmp.jpg")
        {
            try { File.Delete(filename); } catch { }
            Point editor_offset = new Point { X = 634, Y = 221 }; // 226
            Point editor_size = new Point { X = 818, Y = 694 }; //693

            System.Drawing.Rectangle bounds = Screen.GetBounds(Point.Empty); // размер фулового окна        
            //using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            using (Bitmap bitmap = new Bitmap(editor_size.X, editor_size.Y)) // создание фотки
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    g.CopyFromScreen(editor_offset, Point.Empty, bounds.Size);
                }
                bitmap.Save(filename, ImageFormat.Jpeg);
            }
        }
        string RemoveLastEnter(string input)
        {
            if (input.Length > 2)
            {
                if ((input[input.Length - 1] == '\r') || (input[input.Length - 1] == '\n'))
                {
                    return input.Remove(input.Length - 1, 1);
                }
                if ((input[input.Length - 2] == '\r') || (input[input.Length - 2] == '\n'))
                {
                    return input.Remove(input.Length - 2, 1);
                }
            }
            else { return input.Replace("\r", "").Replace("\n", ""); }
            return input;
        }
        void start_Click(object sender, EventArgs e)
        {
            string tmp_dir = "tmp";
            string tmp_file = "main.txt";
            string quession = "";
            (bool, string) result = SelectFile();
            if (!result.Item1) { return; }
            log.Text = $"Sel: {Path.GetFileName(result.Item2)}";
            Process editor = Process.Start(_editor, "\""+result.Item2+"\"");
            //System.Threading.Thread.Sleep(4000);

            //add window focus
            //BringToFront(editor);

            System.Threading.Thread.Sleep(3000);
            BringToFront(Process.GetCurrentProcess());
            //-----------------------------
            GetData wnd = new GetData();
            wnd.label_text = "Get Count Quession";
            wnd.ShowDialog();
            if (!wnd.getdata) { try { editor.Kill(); } catch { } log.Text = $""; return; }
            int count = int.Parse(wnd._data);
            System.Threading.Thread.Sleep(1000);
            Click(471, 259); // left bar focus
            try { Directory.Delete(tmp_dir, true); } catch { }
            try { Directory.CreateDirectory(tmp_dir); } catch { }
            //------------------------------ON EDITOR------

            List<string> que = new List<string>();
            for (int i = 0; i < count; i++)
            {
                TAB();
                System.Threading.Thread.Sleep(10);
                TAB();
                System.Threading.Thread.Sleep(80);
                CTRL_A();
                System.Threading.Thread.Sleep(80);
                CTRL_C();
                System.Threading.Thread.Sleep(80);
                quession = Clipboard.GetText();
                //que.Add(RemoveLastEnter(quession)); //??
                que.Add(quession.Replace("\r", "").Replace("\n", ""));
                LEFT(); // disable select blue text ctrl+a
                System.Threading.Thread.Sleep(80);
                TakeScreenShot($"{i}.jpg");
                try { File.Move($"{i}.jpg", $"{tmp_dir}\\{i}.jpg"); } catch { }
                //-----ADD-----------------------------


                System.Threading.Thread.Sleep(10);
                try { File.Delete($"{i}.jpg"); } catch { }
                //---------------------------

                //Click(471, 259); // left bar focus
                SHIFT_TAB();
                System.Threading.Thread.Sleep(80);
                SHIFT_TAB();
                if ((i + 1) < count)
                {
                    DOWN();
                    System.Threading.Thread.Sleep(80); //500
                }
            }
            File.WriteAllLines($"{tmp_dir}\\{tmp_file}", que.ToArray());

            //string filename = $"{name}_{DateTime.Now.ToString("dd.MM.yyyy_HH-mm-ss")}.pdf";
            string file = $"{Path.GetFileNameWithoutExtension(result.Item2)}.pdf";
            // render
            RenderPDF(tmp_dir, file);
            try { Directory.Delete(tmp_dir, true); } catch { }
            //-------END

            try { editor.Kill(); } catch { }
            try { File.Move(file, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\{file}"); } catch { }
            log.Text = $"";
            MessageBox.Show("OK!", "By Diktor");
            BringToFront(Process.GetCurrentProcess());
        }

        void RenderPDF(string path, string outfile)
        {
            var baseFont = BaseFont.CreateFont(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
            using (FileStream fs = new FileStream(outfile, FileMode.Create))
            {
                List<string> que = File.ReadAllLines(path + "\\MAIN.txt").ToList();
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                document.AddAuthor("by Diktor");
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                //-------------------------------------------------


                for (int i = 0; i < que.Count; i++)
                {
                    document.NewPage();
                    Paragraph p = new Paragraph();
                    p.Font = font;
                    p.Add(que[i] + "\n\n\n");
                    using (var item = new FileStream(path + $"\\{i}.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        try
                        {
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(item);
                            image.ScalePercent(65);
                            p.Add(image);
                        }
                        catch { }
                    }
                    document.Add(p);
                }

                //------CLOSE PDF

                //p.Add("                                               ●▬▬▬▬▬▬▬▬▬▬▬ஜ۩۞۩ஜ▬▬▬▬▬▬▬▬▬▬▬●\n");
                //p.Add("                                                ░░░░░░░░░░░░░░ BY DIKTOR ░░░░░░░░░░░░░\n");
                //p.Add("                                               ●▬▬▬▬▬▬▬▬▬▬▬ஜ۩۞۩ஜ▬▬▬▬▬▬▬▬▬▬▬●\n");


                //----------------------------------------------
                document.Close();
                writer.Close();
            }
        }



        /*string save_loa_pdf(string name, string path, string appdatapath, ref List<string> test, bool fix_new)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo APDT = new DirectoryInfo(appdatapath);
            var baseFont = BaseFont.CreateFont(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
            //string filename = $"{name}_{DateTime.Now.ToString("dd.MM.yyyy_HH-mm-ss")}.pdf";
            string filename = $"{name}.pdf";
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            if (!APDT.Exists)
            {
                APDT.Create();
            }
            using (FileStream fs = new FileStream(path + $"\\{filename}", FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                document.AddAuthor("by Diktor");
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                Paragraph p = new Paragraph();
                p.Font = font;

                foreach (var q in test)
                {
                    if (q.done)
                    {
                        p.Add("# " + fixstr_universal(q.quession) + '\n');
                        if (q.png_quession)
                        {
                            foreach (var url_p in q.url_png_que)
                            {
                                wc.DownloadFile(url_p, appdatapath + "\\1.png");
                                System.Threading.Thread.Sleep(10);
                                using (var i = new FileStream(appdatapath + "\\1.png", FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    try
                                    {
                                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(i);
                                        image.ScalePercent(50);
                                        p.Add(image);
                                    }
                                    catch { p.Add(url_p + "\n"); }
                                }
                                System.Threading.Thread.Sleep(10);
                                try { File.Delete(appdatapath + "\\1.png"); }
                                catch { }
                            }
                            p.Add('\n' + @"\/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/" + '\n');
                        }
                        bool t = false;
                        foreach (var c in q.correct)
                        {
                            if (c.Key)
                            {
                                if (!t)
                                {
                                    p.Add("++  ++  ++  ++  ++  ++  ++  ++  ++  ++  ++  ++  ++  ++  ++\n");
                                }
                                t = true;
                                wc.DownloadFile(c.Value, appdatapath + "\\2.png");
                                System.Threading.Thread.Sleep(10);
                                using (var i = new FileStream(appdatapath + "\\2.png", FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    try
                                    {
                                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(i);
                                        image.ScalePercent(70);
                                        p.Add(image);
                                        p.Add("" + '\n');
                                    }
                                    catch { p.Add(c.Value + "\n"); }
                                }
                                System.Threading.Thread.Sleep(10);
                                try { File.Delete(appdatapath + "\\2.png"); }
                                catch { }
                            }
                            else
                            { p.Add("+ " + fixstr_universal(c.Value) + '\n'); t = false; }
                        }

                        bool f = false;
                        foreach (var ic in q.incorrect)
                        {
                            if (ic.Key)
                            {
                                if (!f)
                                {
                                    p.Add("-----  -----  -----  -----  -----  -----  -----  -----  -----  -----\n");
                                }
                                f = true;
                                wc.DownloadFile(ic.Value, appdatapath + "\\3.png");
                                System.Threading.Thread.Sleep(10);
                                using (var i = new FileStream(appdatapath + "\\3.png", FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    try
                                    {
                                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(i);
                                        image.ScalePercent(70);
                                        p.Add(image);
                                        p.Add("" + '\n');
                                    }
                                    catch { p.Add(ic.Value + "\n"); }
                                }
                                System.Threading.Thread.Sleep(10);
                                try { File.Delete(appdatapath + "\\3.png"); }
                                catch { }
                            }
                            else { p.Add(fixstr_universal(ic.Value) + '\n'); f = false; }
                        }
                        p.Add("" + '\n');
                    }
                }



                p.Add("                                               ●▬▬▬▬▬▬▬▬▬▬▬ஜ۩۞۩ஜ▬▬▬▬▬▬▬▬▬▬▬●\n");
                p.Add("                                                ░░░░░░░░░░░░░░ BY DIKTOR ░░░░░░░░░░░░░\n");
                p.Add("                                               ●▬▬▬▬▬▬▬▬▬▬▬ஜ۩۞۩ஜ▬▬▬▬▬▬▬▬▬▬▬●\n");

                document.Add(p);
                document.Close();
                writer.Close();
            }
        }*/


        (bool, string) SelectFile()
        {
            test.Filter = "MyTestFile (*.mtf)|*.mtf|All Files (*.*)|*.*";
            return ((test.ShowDialog() == DialogResult.OK), test.FileName);
        }

        public Form1()
          => InitializeComponent();


    }
}
