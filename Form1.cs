using Helper;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.Globalization;

namespace TestKeys3
{
    public partial class Form1 : Form
    {
        KeyHelper kh = new KeyHelper();
        private bool ctrl, shift, escape;
        private string lang;
        string currentLanguage;




        ArrayList keys = new ArrayList();
        Dictionary<string, int> keysCount = new Dictionary<string, int>();
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int shwCmds);

        public Form1()
        {
            InitializeComponent();
            kh.KeyDown += Kh_KeyDown;
            kh.KeyUp += Kh_KeyUp;
            kh.LanguageChanged += Kh_LanguageChanged;

        }

        public string GetKeyboardLayout()
        {
            string currentLayout = InputLanguage.CurrentInputLanguage.Culture.EnglishName;
            return currentLayout;
        }
        private void Kh_LanguageChanged(object sender, EventArgs e)
        {

            currentLanguage = kh.GetInputLanguage();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "keysReport.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(KeyPress.Text);
                writer.WriteLine("");
                foreach (var i in keysCount)
                {
                    writer.WriteLine("{0}: {1}", i.Key, i.Value);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.button1.Focus();
            label3.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            KeyPress.Text = "";
            keys.Clear();
            //ShowWindow(this.Handle, 0);
            this.Opacity = 0;
        }
        private void Kh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey) ctrl = false;
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey) shift = false;
            string check = KeyPress.Text.ToLower();
            check = check.Replace("shift", "");
            if (check.Contains(label1.Text.ToLower()))
            {
                //ShowWindow(this.Handle, 1);
                this.Opacity = 1;
                string path = "keysReport.txt";
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(KeyPress.Text);
                    writer.WriteLine();
                    foreach (var i in keysCount)
                    {
                        writer.WriteLine("{0}: {1}", i.Key, i.Value);
                    }
                }
            }
            //label3.Text = lang;

        }

        private void Kh_KeyDown(object sender, KeyEventArgs e)
        {
            bool numLock = Console.NumberLock;
            
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey) shift = true;
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey) ctrl = true;
            currentLanguage = kh.GetInputLanguage();
            lang = GetKeyboardLayout();
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;

            label3.Text = currentLanguage;
            //currentLanguage.Contains("Ukrainian")
            if (myCurrentLanguage.Culture.Name == "uk-UA") //якщо мова введення українська
            {
                if (e.KeyValue == 81 && shift)
                {
                    keys.Add("Й");
                    keysCount["Й"] = keysCount.ContainsKey("Й") ? keysCount["Й"] + 1 : 1;
                }
                else if (e.KeyValue == 81 && !shift)
                {
                    keys.Add("й");
                    keysCount["й"] = keysCount.ContainsKey("й") ? keysCount["й"] + 1 : 1;
                }
                if (e.KeyValue == 87 && shift)
                {
                    keys.Add("Ц");
                    keysCount["Ц"] = keysCount.ContainsKey("Ц") ? keysCount["Ц"] + 1 : 1;
                }
                else if (e.KeyValue == 87 && !shift)
                {
                    keys.Add("ц");
                    keysCount["ц"] = keysCount.ContainsKey("ц") ? keysCount["ц"] + 1 : 1;
                }
                if (e.KeyValue == 69 && shift)
                {
                    keys.Add("У");
                    keysCount["У"] = keysCount.ContainsKey("У") ? keysCount["У"] + 1 : 1;
                }
                else if (e.KeyValue == 69 && !shift)
                {
                    keys.Add("у");
                    keysCount["у"] = keysCount.ContainsKey("у") ? keysCount["у"] + 1 : 1;
                }
                if (e.KeyValue == 82 && shift)
                {
                    keys.Add("К");
                    keysCount["К"] = keysCount.ContainsKey("К") ? keysCount["К"] + 1 : 1;
                }
                else if (e.KeyValue == 82 && !shift)
                {
                    keys.Add("к");
                    keysCount["к"] = keysCount.ContainsKey("к") ? keysCount["к"] + 1 : 1;
                }
                if (e.KeyValue == 84 && shift)
                {
                    keys.Add("Е");
                    keysCount["Е"] = keysCount.ContainsKey("Е") ? keysCount["Е"] + 1 : 1;
                }
                else if (e.KeyValue == 84 && !shift)
                {
                    keys.Add("е");
                    keysCount["е"] = keysCount.ContainsKey("е") ? keysCount["е"] + 1 : 1;
                }
                if (e.KeyValue == 89 && shift)
                {
                    keys.Add("Н");
                    keysCount["Н"] = keysCount.ContainsKey("Н") ? keysCount["Н"] + 1 : 1;
                }
                else if (e.KeyValue == 89 && !shift)
                {
                    keys.Add("н");
                    keysCount["н"] = keysCount.ContainsKey("н") ? keysCount["н"] + 1 : 1;
                }
                if (e.KeyValue == 85 && shift)
                {
                    keys.Add("Г");
                    keysCount["Г"] = keysCount.ContainsKey("Г") ? keysCount["Г"] + 1 : 1;
                }
                else if (e.KeyValue == 85 && !shift)
                {
                    keys.Add("г");
                    keysCount["г"] = keysCount.ContainsKey("г") ? keysCount["г"] + 1 : 1;
                }
                if (e.KeyValue == 73 && shift)
                {
                    keys.Add("Ш");
                    keysCount["Ш"] = keysCount.ContainsKey("Ш") ? keysCount["Ш"] + 1 : 1;
                }
                else if (e.KeyValue == 73 && !shift)
                {
                    keys.Add("ш");
                    keysCount["ш"] = keysCount.ContainsKey("ш") ? keysCount["ш"] + 1 : 1;
                }
                if (e.KeyValue == 79 && shift)
                {
                    keys.Add("Щ");
                    keysCount["Щ"] = keysCount.ContainsKey("Щ") ? keysCount["Щ"] + 1 : 1;
                }
                else if (e.KeyValue == 79 && !shift)
                {
                    keys.Add("щ");
                    keysCount["щ"] = keysCount.ContainsKey("щ") ? keysCount["щ"] + 1 : 1;
                }
                if (e.KeyValue == 80 && shift)
                {
                    keys.Add("З");
                    keysCount["З"] = keysCount.ContainsKey("З") ? keysCount["З"] + 1 : 1;
                }
                else if (e.KeyValue == 80 && !shift)
                {
                    keys.Add("з");
                    keysCount["з"] = keysCount.ContainsKey("з") ? keysCount["з"] + 1 : 1;
                }
                if (e.KeyValue == 219 && shift)
                {
                    keys.Add("Х");
                    keysCount["Х"] = keysCount.ContainsKey("Х") ? keysCount["Х"] + 1 : 1;
                }
                else if (e.KeyValue == 219 && !shift)
                {
                    keys.Add("х");
                    keysCount["х"] = keysCount.ContainsKey("х") ? keysCount["х"] + 1 : 1;
                }
                if (e.KeyValue == 221 && shift)
                {
                    keys.Add("Ї");
                    keysCount["Ї"] = keysCount.ContainsKey("Ї") ? keysCount["Ї"] + 1 : 1;
                }
                else if (e.KeyValue == 221 && !shift)
                {
                    keys.Add("ї");
                    keysCount["ї"] = keysCount.ContainsKey("ї") ? keysCount["ї"] + 1 : 1;
                }
                if (e.KeyValue == 65 && shift)
                {
                    keys.Add("Ф");
                    keysCount["Ф"] = keysCount.ContainsKey("Ф") ? keysCount["Ф"] + 1 : 1;
                }
                else if (e.KeyValue == 65 && !shift)
                {
                    keys.Add("ф");
                    keysCount["ф"] = keysCount.ContainsKey("ф") ? keysCount["ф"] + 1 : 1;
                }
                if (e.KeyValue == 83 && shift)
                {
                    keys.Add("І");
                    keysCount["І"] = keysCount.ContainsKey("І") ? keysCount["І"] + 1 : 1;
                }
                else if (e.KeyValue == 83 && !shift)
                {
                    keys.Add("і");
                    keysCount["і"] = keysCount.ContainsKey("і") ? keysCount["і"] + 1 : 1;
                }
                if (e.KeyValue == 68 && shift)
                {
                    keys.Add("В");
                    keysCount["В"] = keysCount.ContainsKey("В") ? keysCount["В"] + 1 : 1;
                }
                else if (e.KeyValue == 68 && !shift)
                {
                    keys.Add("в");
                    keysCount["в"] = keysCount.ContainsKey("в") ? keysCount["в"] + 1 : 1;
                }
                if (e.KeyValue == 70 && shift)
                {
                    keys.Add("А");
                    keysCount["А"] = keysCount.ContainsKey("А") ? keysCount["А"] + 1 : 1;
                }
                else if (e.KeyValue == 70 && !shift)
                {
                    keys.Add("а");
                    keysCount["а"] = keysCount.ContainsKey("а") ? keysCount["а"] + 1 : 1;
                }
                if (e.KeyValue == 71 && shift)
                {
                    keys.Add("П");
                    keysCount["П"] = keysCount.ContainsKey("П") ? keysCount["П"] + 1 : 1;
                }
                else if (e.KeyValue == 71 && !shift)
                {
                    keys.Add("п");
                    keysCount["п"] = keysCount.ContainsKey("п") ? keysCount["п"] + 1 : 1;
                }
                if (e.KeyValue == 72 && shift)
                {
                    keys.Add("Р");
                    keysCount["Р"] = keysCount.ContainsKey("Р") ? keysCount["Р"] + 1 : 1;
                }
                else if (e.KeyValue == 72 && !shift)
                {
                    keys.Add("р");
                    keysCount["р"] = keysCount.ContainsKey("р") ? keysCount["р"] + 1 : 1;
                }
                if (e.KeyValue == 74 && shift)
                {
                    keys.Add("О");
                    keysCount["О"] = keysCount.ContainsKey("О") ? keysCount["О"] + 1 : 1;
                }
                else if (e.KeyValue == 74 && !shift)
                {
                    keys.Add("о");
                    keysCount["о"] = keysCount.ContainsKey("о") ? keysCount["о"] + 1 : 1;
                }
                if (e.KeyValue == 75 && shift)
                {
                    keys.Add("Л");
                    keysCount["Л"] = keysCount.ContainsKey("Л") ? keysCount["Л"] + 1 : 1;
                }
                else if (e.KeyValue == 75 && !shift)
                {
                    keys.Add("л");
                    keysCount["л"] = keysCount.ContainsKey("л") ? keysCount["л"] + 1 : 1;
                }
                if (e.KeyValue == 76 && shift)
                {
                    keys.Add("Д");
                    keysCount["Д"] = keysCount.ContainsKey("Д") ? keysCount["Д"] + 1 : 1;
                }
                else if (e.KeyValue == 76 && !shift)
                {
                    keys.Add("д");
                    keysCount["д"] = keysCount.ContainsKey("д") ? keysCount["д"] + 1 : 1;
                }
                if (e.KeyValue == 186 && shift)
                {
                    keys.Add("Ж");
                    keysCount["Ж"] = keysCount.ContainsKey("Ж") ? keysCount["Ж"] + 1 : 1;
                }
                else if (e.KeyValue == 186 && !shift)
                {
                    keys.Add("ж");
                    keysCount["ж"] = keysCount.ContainsKey("ж") ? keysCount["ж"] + 1 : 1;
                }
                if (e.KeyValue == 222 && shift)
                {
                    keys.Add("Є");
                    keysCount["Є"] = keysCount.ContainsKey("Є") ? keysCount["Є"] + 1 : 1;
                }
                else if (e.KeyValue == 222 && !shift)
                {
                    keys.Add("є");
                    keysCount["є"] = keysCount.ContainsKey("є") ? keysCount["є"] + 1 : 1;
                }
                if (e.KeyValue == 220 && shift)
                {
                    keys.Add("/");
                    keysCount["/"] = keysCount.ContainsKey("/") ? keysCount["/"] + 1 : 1;
                }
                else if (e.KeyValue == 220 && !shift)
                {
                    keys.Add("\\");
                    keysCount["\\"] = keysCount.ContainsKey("\\") ? keysCount["\\"] + 1 : 1;
                }
                if (e.KeyValue == 226 && shift)
                {
                    keys.Add("Ґ");
                    keysCount["Ґ"] = keysCount.ContainsKey("Ґ") ? keysCount["Ґ"] + 1 : 1;
                }
                else if (e.KeyValue == 226 && !shift)
                {
                    keys.Add("ґ");
                    keysCount["ґ"] = keysCount.ContainsKey("ґ") ? keysCount["ґ"] + 1 : 1;
                }
                if (e.KeyValue == 90 && shift)
                {
                    keys.Add("Я");
                    keysCount["Я"] = keysCount.ContainsKey("Я") ? keysCount["Я"] + 1 : 1;
                }
                else if (e.KeyValue == 90 && !shift)
                {
                    keys.Add("я");
                    keysCount["я"] = keysCount.ContainsKey("я") ? keysCount["я"] + 1 : 1;
                }
                if (e.KeyValue == 88 && shift)
                {
                    keys.Add("Ч");
                    keysCount["Ч"] = keysCount.ContainsKey("Ч") ? keysCount["Ч"] + 1 : 1;
                }
                else if (e.KeyValue == 88 && !shift)
                {
                    keys.Add("ч");
                    keysCount["ч"] = keysCount.ContainsKey("ч") ? keysCount["ч"] + 1 : 1;
                }
                if (e.KeyValue == 67 && shift)
                {
                    keys.Add("С");
                    keysCount["С"] = keysCount.ContainsKey("С") ? keysCount["С"] + 1 : 1;
                }
                else if (e.KeyValue == 67 && !shift)
                {
                    keys.Add("с");
                    keysCount["с"] = keysCount.ContainsKey("с") ? keysCount["с"] + 1 : 1;
                }
                if (e.KeyValue == 86 && shift)
                {
                    keys.Add("М");
                    keysCount["М"] = keysCount.ContainsKey("М") ? keysCount["М"] + 1 : 1;
                }
                else if (e.KeyValue == 86 && !shift)
                {
                    keys.Add("м");
                    keysCount["м"] = keysCount.ContainsKey("м") ? keysCount["м"] + 1 : 1;
                }
                if (e.KeyValue == 66 && shift)
                {
                    keys.Add("И");
                    keysCount["И"] = keysCount.ContainsKey("И") ? keysCount["И"] + 1 : 1;
                }
                else if (e.KeyValue == 66 && !shift)
                {
                    keys.Add("и");
                    keysCount["и"] = keysCount.ContainsKey("и") ? keysCount["и"] + 1 : 1;
                }
                if (e.KeyValue == 78 && shift)
                {
                    keys.Add("Т");
                    keysCount["Т"] = keysCount.ContainsKey("Т") ? keysCount["Т"] + 1 : 1;
                }
                else if (e.KeyValue == 78 && !shift)
                {
                    keys.Add("т");
                    keysCount["т"] = keysCount.ContainsKey("т") ? keysCount["т"] + 1 : 1;
                }
                if (e.KeyValue == 77 && shift)
                {
                    keys.Add("Ь");
                    keysCount["Ь"] = keysCount.ContainsKey("Ь") ? keysCount["Ь"] + 1 : 1;
                }
                else if (e.KeyValue == 77 && !shift)
                {
                    keys.Add("ь");
                    keysCount["ь"] = keysCount.ContainsKey("ь") ? keysCount["ь"] + 1 : 1;
                }
                if (e.KeyValue == 188 && shift)
                {
                    keys.Add("Б");
                    keysCount["Б"] = keysCount.ContainsKey("Б") ? keysCount["Б"] + 1 : 1;
                }
                else if (e.KeyValue == 188 && !shift)
                {
                    keys.Add("б");
                    keysCount["б"] = keysCount.ContainsKey("б") ? keysCount["б"] + 1 : 1;
                }
                if (e.KeyValue == 190 && shift)
                {
                    keys.Add("Ю");
                    keysCount["Ю"] = keysCount.ContainsKey("Ю") ? keysCount["Ю"] + 1 : 1;
                }
                else if (e.KeyValue == 190 && !shift)
                {
                    keys.Add("ю");
                    keysCount["ю"] = keysCount.ContainsKey("ю") ? keysCount["ю"] + 1 : 1;
                }
                if (e.KeyValue == 191 && shift)
                {
                    keys.Add(",");
                    keysCount[","] = keysCount.ContainsKey(",") ? keysCount[","] + 1 : 1;
                }
                else if (e.KeyValue == 191 && !shift)
                {
                    keys.Add(".");
                    keysCount["."] = keysCount.ContainsKey(".") ? keysCount["."] + 1 : 1;
                }
                if (e.KeyValue == 192 && shift)
                {
                    keys.Add("₴");
                    keysCount["₴"] = keysCount.ContainsKey("₴") ? keysCount["₴"] + 1 : 1;
                }
                else if (e.KeyValue == 192 && !shift)
                {
                    keys.Add("\'");
                    keysCount["\'"] = keysCount.ContainsKey("\'") ? keysCount["\'"] + 1 : 1;
                }
                if (e.KeyValue == 49 && shift)
                {
                    keys.Add("!");
                    keysCount["!"] = keysCount.ContainsKey("!") ? keysCount["!"] + 1 : 1;
                }
                else if (e.KeyValue == 49 && !shift)
                {
                    keys.Add("1");
                    keysCount["1"] = keysCount.ContainsKey("1") ? keysCount["1"] + 1 : 1;
                }
                if (e.KeyValue == 50 && shift)
                {
                    keys.Add("\"");
                    keysCount["\""] = keysCount.ContainsKey("\"") ? keysCount["\""] + 1 : 1;
                }
                else if (e.KeyValue == 50 && !shift)
                {
                    keys.Add("2");
                    keysCount["2"] = keysCount.ContainsKey("2") ? keysCount["2"] + 1 : 1;
                }
                if (e.KeyValue == 51 && shift)
                {
                    keys.Add("№");
                    keysCount["№"] = keysCount.ContainsKey("№") ? keysCount["№"] + 1 : 1;
                }
                else if (e.KeyValue == 51 && !shift)
                {
                    keys.Add("3");
                    keysCount["3"] = keysCount.ContainsKey("3") ? keysCount["3"] + 1 : 1;
                }
                if (e.KeyValue == 52 && shift)
                {
                    keys.Add(";");
                    keysCount[";"] = keysCount.ContainsKey(";") ? keysCount[";"] + 1 : 1;
                }
                else if (e.KeyValue == 52 && !shift)
                {
                    keys.Add("4");
                    keysCount["4"] = keysCount.ContainsKey("4") ? keysCount["4"] + 1 : 1;
                }
                if (e.KeyValue == 53 && shift)
                {
                    keys.Add("%");
                    keysCount["%"] = keysCount.ContainsKey("%") ? keysCount["%"] + 1 : 1;
                }
                else if (e.KeyValue == 53 && !shift)
                {
                    keys.Add("5");
                    keysCount["5"] = keysCount.ContainsKey("5") ? keysCount["5"] + 1 : 1;
                }
                if (e.KeyValue == 54 && shift)
                {
                    keys.Add(":");
                    keysCount[":"] = keysCount.ContainsKey(":") ? keysCount[":"] + 1 : 1;
                }
                else if (e.KeyValue == 54 && !shift)
                {
                    keys.Add("6");
                    keysCount["6"] = keysCount.ContainsKey("6") ? keysCount["6"] + 1 : 1;
                }
                if (e.KeyValue == 55 && shift)
                {
                    keys.Add("?");
                    keysCount["?"] = keysCount.ContainsKey("?") ? keysCount["?"] + 1 : 1;
                }
                else if (e.KeyValue == 55 && !shift)
                {
                    keys.Add("7");
                    keysCount["7"] = keysCount.ContainsKey("7") ? keysCount["7"] + 1 : 1;
                }
                if (e.KeyValue == 56 && shift)
                {
                    keys.Add("*");
                    keysCount["*"] = keysCount.ContainsKey("*") ? keysCount["*"] + 1 : 1;
                }
                else if (e.KeyValue == 56 && !shift)
                {
                    keys.Add("8");
                    keysCount["8"] = keysCount.ContainsKey("8") ? keysCount["8"] + 1 : 1;
                }
                if (e.KeyValue == 57 && shift)
                {
                    keys.Add("(");
                    keysCount["("] = keysCount.ContainsKey("(") ? keysCount["("] + 1 : 1;
                }
                else if (e.KeyValue == 57 && !shift)
                {
                    keys.Add("9");
                    keysCount["9"] = keysCount.ContainsKey("9") ? keysCount["9"] + 1 : 1;
                }
                if (e.KeyValue == 48 && shift)
                {
                    keys.Add(")");
                    keysCount[")"] = keysCount.ContainsKey(")") ? keysCount[")"] + 1 : 1;
                }
                else if (e.KeyValue == 48 && !shift)
                {
                    keys.Add("0");
                    keysCount["0"] = keysCount.ContainsKey("0") ? keysCount["0"] + 1 : 1;
                }
                if (e.KeyValue == 189 && shift)
                {
                    keys.Add("_");
                    keysCount["_"] = keysCount.ContainsKey("_") ? keysCount["_"] + 1 : 1;
                }
                else if (e.KeyValue == 189 && !shift)
                {
                    keys.Add("-");
                    keysCount["-"] = keysCount.ContainsKey("-") ? keysCount["-"] + 1 : 1;
                }
                if (e.KeyValue == 187 && shift)
                {
                    keys.Add("+");
                    keysCount["+"] = keysCount.ContainsKey("+") ? keysCount["+"] + 1 : 1;
                }
                else if (e.KeyValue == 187 && !shift)
                {
                    keys.Add("=");
                    keysCount["="] = keysCount.ContainsKey("=") ? keysCount["="] + 1 : 1;
                }

                //Other keyys
                if (e.KeyValue == 32 && shift || e.KeyValue == 32 && !shift)
                {
                    keys.Add(" ");
                    keysCount["Space"] = keysCount.ContainsKey("Space") ? keysCount["Space"] + 1 : 1;

                }
                if (e.KeyValue == 27)
                {
                    if (keys.Count >= 0 && !keys.Contains("Esc"))
                    {
                        keys.Add("Esc");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Esc") keys.Add("Esc");
                    keysCount["Esc"] = keysCount.ContainsKey("Esc") ? keysCount["Esc"] + 1 : 1;
                }
                if (e.KeyValue == 162 || e.KeyValue == 163)
                {
                    if (keys.Count >= 0 && !keys.Contains("Ctrl"))
                    {
                        keys.Add("Ctrl");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Ctrl") keys.Add("Ctrl");
                    keysCount["Ctrl"] = keysCount.ContainsKey("Ctrl") ? keysCount["Ctrl"] + 1 : 1;
                }
                if (e.KeyValue == 160 || e.KeyValue == 161)
                {
                    if (keys.Count >= 0 && !keys.Contains("Shift"))
                    {
                        keys.Add("Shift");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Shift") keys.Add("Shift");
                    keysCount["Shift"] = keysCount.ContainsKey("Shift") ? keysCount["Shift"] + 1 : 1;
                }
                if (e.KeyValue == 9)
                {
                    if (keys.Count >= 0 && !keys.Contains("Tab"))
                    {
                        keys.Add("Tab");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Tab") keys.Add("Tab");
                    keysCount["Tab"] = keysCount.ContainsKey("Tab") ? keysCount["Tab"] + 1 : 1;
                }
                if (e.KeyValue == 20)
                {
                    if (keys.Count >= 0 && !keys.Contains("CapsLock"))
                    {
                        keys.Add("CapsLock");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "CapsLock") keys.Add("CapsLock");
                    keysCount["CapsLock"] = keysCount.ContainsKey("CapsLock") ? keysCount["CapsLock"] + 1 : 1;
                }
                if (e.KeyValue == 164)
                {
                    if (keys.Count >= 0 && !keys.Contains("Alt"))
                    {
                        keys.Add("Alt");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Alt") keys.Add("Alt");
                    keysCount["Alt"] = keysCount.ContainsKey("Alt") ? keysCount["Alt"] + 1 : 1;
                }
                //Keys F1-F12
                if (e.KeyValue >= 112 && e.KeyValue <= 123)
                {
                    if (keys.Count >= 0 && !keys.Contains(e.KeyCode.ToString()))
                    {
                        keys.Add(e.KeyCode.ToString());
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != e.KeyCode.ToString()) keys.Add(e.KeyCode.ToString());
                    keysCount[e.KeyCode.ToString()] = keysCount.ContainsKey(e.KeyCode.ToString()) ? keysCount[e.KeyCode.ToString()] + 1 : 1;
                }
                if (e.KeyValue == 8)
                {
                    if (keys.Count >= 0 && !keys.Contains("Back"))
                    {
                        keys.Add("Back");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Back") keys.Add("Back");
                    keysCount["Back"] = keysCount.ContainsKey("Back") ? keysCount["Back"] + 1 : 1;
                }
                if (e.KeyValue == 13)
                {
                    if (keys.Count >= 0 && !keys.Contains("Enter"))
                    {
                        keys.Add("Enter");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Enter") keys.Add("Enter");
                    keysCount["Enter"] = keysCount.ContainsKey("Enter") ? keysCount["Enter"] + 1 : 1;
                }
                if (e.KeyValue == 44)
                {
                    if (keys.Count >= 0 && !keys.Contains("PrtScn"))
                    {
                        keys.Add("PrtScn");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "PrtScn") keys.Add("PrtScn");
                    keysCount["PrtScn"] = keysCount.ContainsKey("PrtScn") ? keysCount["PrtScn"] + 1 : 1;
                }
                if (e.KeyValue == 145)
                {
                    if (keys.Count >= 0 && !keys.Contains("Scroll"))
                    {
                        keys.Add("Scroll");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Scroll") keys.Add("Scroll");
                    keysCount["Scroll"] = keysCount.ContainsKey("Scroll") ? keysCount["Scroll"] + 1 : 1;
                }
                if (e.KeyValue == 19)
                {
                    if (keys.Count >= 0 && !keys.Contains("Pause"))
                    {
                        keys.Add("Pause");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Pause") keys.Add("Pause");
                    keysCount["Pause"] = keysCount.ContainsKey("Pause") ? keysCount["Pause"] + 1 : 1;
                }
                if (e.KeyValue == 45)
                {
                    if (keys.Count >= 0 && !keys.Contains("Ins"))
                    {
                        keys.Add("Ins");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Ins") keys.Add("Ins");
                    keysCount["Ins"] = keysCount.ContainsKey("Ins") ? keysCount["Ins"] + 1 : 1;
                }
                if (e.KeyValue == 46)
                {
                    if (keys.Count >= 0 && !keys.Contains("Del"))
                    {
                        keys.Add("Del");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Del") keys.Add("Del");
                    keysCount["Del"] = keysCount.ContainsKey("Del") ? keysCount["Del"] + 1 : 1;
                }
                if (e.KeyValue == 36)
                {
                    if (keys.Count >= 0 && !keys.Contains("Home"))
                    {
                        keys.Add("Home");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Home") keys.Add("Home");
                    keysCount["Home"] = keysCount.ContainsKey("Home") ? keysCount["Home"] + 1 : 1;
                }
                if (e.KeyValue == 35)
                {
                    if (keys.Count >= 0 && !keys.Contains("End"))
                    {
                        keys.Add("End");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "End") keys.Add("End");
                    keysCount["End"] = keysCount.ContainsKey("End") ? keysCount["End"] + 1 : 1;
                }
                if (e.KeyValue == 33)
                {
                    if (keys.Count >= 0 && !keys.Contains("PageUp"))
                    {
                        keys.Add("PageUp");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "PageUp") keys.Add("PageUp");
                    keysCount["PageUp"] = keysCount.ContainsKey("PageUp") ? keysCount["PageUp"] + 1 : 1;
                }
                if (e.KeyValue == 34)
                {
                    if (keys.Count >= 0 && !keys.Contains("PageDown"))
                    {
                        keys.Add("PageDown");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "PageDown") keys.Add("PageDown");
                    keysCount["PageDown"] = keysCount.ContainsKey("PageDown") ? keysCount["PageDown"] + 1 : 1;
                }
                if (e.KeyValue == 38)
                {
                    if (keys.Count >= 0 && !keys.Contains("↑"))
                    {
                        keys.Add("↑");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "↑") keys.Add("↑");
                    keysCount["↑"] = keysCount.ContainsKey("↑") ? keysCount["↑"] + 1 : 1;
                }
                if (e.KeyValue == 37)
                {
                    if (keys.Count >= 0 && !keys.Contains("←"))
                    {
                        keys.Add("←");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "←") keys.Add("←");
                    keysCount["←"] = keysCount.ContainsKey("←") ? keysCount["←"] + 1 : 1;
                }
                if (e.KeyValue == 39)
                {
                    if (keys.Count >= 0 && !keys.Contains("→"))
                    {
                        keys.Add("→");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "→") keys.Add("→");
                    keysCount["→"] = keysCount.ContainsKey("→") ? keysCount["→"] + 1 : 1;
                }
                if (e.KeyValue == 40)
                {
                    if (keys.Count >= 0 && !keys.Contains("↓"))
                    {
                        keys.Add("↓");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "↓") keys.Add("↓");
                    keysCount["↓"] = keysCount.ContainsKey("↓") ? keysCount["↓"] + 1 : 1;
                }
                if (numLock)
                {
                    if (e.KeyValue == 96 && shift)
                    {
                        keys.Add("Ins");
                        keysCount["Ins"] = keysCount.ContainsKey("Ins") ? keysCount["Ins"] + 1 : 1;
                    }
                    else if (e.KeyValue == 96 && !shift)
                    {
                        keys.Add("0");
                        keysCount["0"] = keysCount.ContainsKey("0") ? keysCount["0"] + 1 : 1;
                    }
                    if (e.KeyValue == 97 && shift)
                    {
                        keys.Add("End");
                        keysCount["End"] = keysCount.ContainsKey("End") ? keysCount["End"] + 1 : 1;
                    }
                    else if (e.KeyValue == 97 && !shift)
                    {
                        keys.Add("1");
                        keysCount["1"] = keysCount.ContainsKey("1") ? keysCount["1"] + 1 : 1;
                    }
                    if (e.KeyValue == 98 && shift)
                    {
                        keys.Add("↓");
                        keysCount["↓"] = keysCount.ContainsKey("↓") ? keysCount["↓"] + 1 : 1;
                    }
                    else if (e.KeyValue == 98 && !shift)
                    {
                        keys.Add("2");
                        keysCount["2"] = keysCount.ContainsKey("2") ? keysCount["2"] + 1 : 1;
                    }
                    if (e.KeyValue == 99 && shift)
                    {
                        keys.Add("PageDown");
                        keysCount["PageDown"] = keysCount.ContainsKey("PageDown") ? keysCount["PageDown"] + 1 : 1;
                    }
                    else if (e.KeyValue == 99 && !shift)
                    {
                        keys.Add("3");
                        keysCount["3"] = keysCount.ContainsKey("3") ? keysCount["3"] + 1 : 1;
                    }
                    if (e.KeyValue == 100 && shift)
                    {
                        keys.Add("←");
                        keysCount["←"] = keysCount.ContainsKey("←") ? keysCount["←"] + 1 : 1;
                    }
                    else if (e.KeyValue == 100 && !shift)
                    {
                        keys.Add("4");
                        keysCount["4"] = keysCount.ContainsKey("4") ? keysCount["4"] + 1 : 1;
                    }
                    //При натисканні Shift+NumPad5 з активованим NumLock потрібно детальніше перевірити обробку цієї ситуації
                    if (e.KeyValue == 101 && shift)
                    {
                        keys.Add("Clear");
                        keysCount["Clear"] = keysCount.ContainsKey("Clear") ? keysCount["Clear"] + 1 : 1;
                    }
                    else if (e.KeyValue == 101 && !shift)
                    {
                        keys.Add("5");
                        keysCount["5"] = keysCount.ContainsKey("5") ? keysCount["5"] + 1 : 1;
                    }
                    if (e.KeyValue == 102 && shift)
                    {
                        keys.Add("→");
                        keysCount["→"] = keysCount.ContainsKey("→") ? keysCount["→"] + 1 : 1;
                    }
                    else if (e.KeyValue == 102 && !shift)
                    {
                        keys.Add("6");
                        keysCount["6"] = keysCount.ContainsKey("6") ? keysCount["6"] + 1 : 1;
                    }
                    if (e.KeyValue == 103 && shift)
                    {
                        keys.Add("Home");
                        keysCount["Home"] = keysCount.ContainsKey("Home") ? keysCount["Home"] + 1 : 1;
                    }
                    else if (e.KeyValue == 103 && !shift)
                    {
                        keys.Add("7");
                        keysCount["7"] = keysCount.ContainsKey("7") ? keysCount["7"] + 1 : 1;
                    }
                    if (e.KeyValue == 104 && shift)
                    {
                        keys.Add("↑");
                        keysCount["↑"] = keysCount.ContainsKey("↑") ? keysCount["↑"] + 1 : 1;
                    }
                    else if (e.KeyValue == 104 && !shift)
                    {
                        keys.Add("8");
                        keysCount["8"] = keysCount.ContainsKey("8") ? keysCount["8"] + 1 : 1;
                    }
                    if (e.KeyValue == 105 && shift)
                    {
                        keys.Add("PageUp");
                        keysCount["PageUp"] = keysCount.ContainsKey("PageUp") ? keysCount["PageUp"] + 1 : 1;
                    }
                    else if (e.KeyValue == 105 && !shift)
                    {
                        keys.Add("9");
                        keysCount["9"] = keysCount.ContainsKey("9") ? keysCount["9"] + 1 : 1;
                    }
                    if (e.KeyValue == 111)
                    {
                        keys.Add("/");
                        keysCount["/"] = keysCount.ContainsKey("/") ? keysCount["/"] + 1 : 1;
                    }
                    if (e.KeyValue == 106)
                    {
                        keys.Add("*");
                        keysCount["*"] = keysCount.ContainsKey("*") ? keysCount["*"] + 1 : 1;
                    }
                    if (e.KeyValue == 107)
                    {
                        keys.Add("+");
                        keysCount["+"] = keysCount.ContainsKey("+") ? keysCount["+"] + 1 : 1;
                    }
                    if (e.KeyValue == 109)
                    {
                        keys.Add("-");
                        keysCount["-"] = keysCount.ContainsKey("-") ? keysCount["-"] + 1 : 1;
                    }
                    if (e.KeyValue == 110)
                    {
                        keys.Add("Del");
                        keysCount["Del"] = keysCount.ContainsKey("Del") ? keysCount["Del"] + 1 : 1;
                    }

                }
                else if (!numLock)
                {
                    if (e.KeyValue == 12 && shift)
                    {
                        if (keys.Count >= 0 && !keys.Contains("Clear"))
                        {
                            keys.Add("Clear");
                        }
                        else if (keys.Count > 0 && keys[keys.Count - 1] != "Clear") keys.Add("Clear");
                        keysCount["Clear"] = keysCount.ContainsKey("Clear") ? keysCount["Clear"] + 1 : 1;
                    }
                    else if (e.KeyValue == 12 && !shift)
                    {
                        keys.Add("5");
                        keysCount["5"] = keysCount.ContainsKey("5") ? keysCount["5"] + 1 : 1;
                    }
                    if (e.KeyValue == 110)
                    {
                        keys.Add("Del");
                        keysCount["Del"] = keysCount.ContainsKey("Del") ? keysCount["Del"] + 1 : 1;
                    }
                    if (e.KeyValue == 111)
                    {
                        keys.Add("/");
                        keysCount["/"] = keysCount.ContainsKey("/") ? keysCount["/"] + 1 : 1;
                    }
                    if (e.KeyValue == 106)
                    {
                        keys.Add("*");
                        keysCount["*"] = keysCount.ContainsKey("*") ? keysCount["*"] + 1 : 1;
                    }
                    if (e.KeyValue == 107)
                    {
                        keys.Add("+");
                        keysCount["+"] = keysCount.ContainsKey("+") ? keysCount["+"] + 1 : 1;
                    }
                    if (e.KeyValue == 109)
                    {
                        keys.Add("-");
                        keysCount["-"] = keysCount.ContainsKey("-") ? keysCount["-"] + 1 : 1;
                    }
                }
                //keys.Add(e.KeyCode);
                //keys.Add(e.KeyValue);
                //keys.Add(numLock);

            }
            if (myCurrentLanguage.Culture.Name == "en-US") //якщо мова введення англійська
            {
                if (e.KeyValue == 81 && shift)
                {
                    keys.Add("Q");
                    keysCount["Q"] = keysCount.ContainsKey("Q") ? keysCount["Q"] + 1 : 1;
                }
                else if (e.KeyValue == 81 && !shift)
                {
                    keys.Add("q");
                    keysCount["q"] = keysCount.ContainsKey("q") ? keysCount["q"] + 1 : 1;
                }
                if (e.KeyValue == 87 && shift)
                {
                    keys.Add("W");
                    keysCount["W"] = keysCount.ContainsKey("W") ? keysCount["W"] + 1 : 1;
                }
                else if (e.KeyValue == 87 && !shift)
                {
                    keys.Add("w");
                    keysCount["w"] = keysCount.ContainsKey("w") ? keysCount["w"] + 1 : 1;
                }
                if (e.KeyValue == 69 && shift)
                {
                    keys.Add("E");
                    keysCount["E"] = keysCount.ContainsKey("E") ? keysCount["E"] + 1 : 1;
                }
                else if (e.KeyValue == 69 && !shift)
                {
                    keys.Add("e");
                    keysCount["e"] = keysCount.ContainsKey("e") ? keysCount["e"] + 1 : 1;
                }
                if (e.KeyValue == 82 && shift)
                {
                    keys.Add("R");
                    keysCount["R"] = keysCount.ContainsKey("R") ? keysCount["R"] + 1 : 1;
                }
                else if (e.KeyValue == 82 && !shift)
                {
                    keys.Add("r");
                    keysCount["r"] = keysCount.ContainsKey("r") ? keysCount["r"] + 1 : 1;
                }
                if (e.KeyValue == 84 && shift)
                {
                    keys.Add("T");
                    keysCount["T"] = keysCount.ContainsKey("T") ? keysCount["T"] + 1 : 1;
                }
                else if (e.KeyValue == 84 && !shift)
                {
                    keys.Add("t");
                    keysCount["t"] = keysCount.ContainsKey("t") ? keysCount["t"] + 1 : 1;
                }
                if (e.KeyValue == 89 && shift)
                {
                    keys.Add("Y");
                    keysCount["Y"] = keysCount.ContainsKey("Y") ? keysCount["Y"] + 1 : 1;
                }
                else if (e.KeyValue == 89 && !shift)
                {
                    keys.Add("y");
                    keysCount["y"] = keysCount.ContainsKey("y") ? keysCount["y"] + 1 : 1;
                }
                if (e.KeyValue == 85 && shift)
                {
                    keys.Add("U");
                    keysCount["U"] = keysCount.ContainsKey("U") ? keysCount["U"] + 1 : 1;
                }
                else if (e.KeyValue == 85 && !shift)
                {
                    keys.Add("u");
                    keysCount["u"] = keysCount.ContainsKey("u") ? keysCount["u"] + 1 : 1;
                }
                if (e.KeyValue == 73 && shift)
                {
                    keys.Add("I");
                    keysCount["I"] = keysCount.ContainsKey("I") ? keysCount["I"] + 1 : 1;
                }
                else if (e.KeyValue == 73 && !shift)
                {
                    keys.Add("i");
                    keysCount["i"] = keysCount.ContainsKey("i") ? keysCount["i"] + 1 : 1;
                }
                if (e.KeyValue == 79 && shift)
                {
                    keys.Add("O");
                    keysCount["O"] = keysCount.ContainsKey("O") ? keysCount["O"] + 1 : 1;
                }
                else if (e.KeyValue == 79 && !shift)
                {
                    keys.Add("o");
                    keysCount["o"] = keysCount.ContainsKey("o") ? keysCount["o"] + 1 : 1;
                }
                if (e.KeyValue == 80 && shift)
                {
                    keys.Add("P");
                    keysCount["P"] = keysCount.ContainsKey("P") ? keysCount["P"] + 1 : 1;
                }
                else if (e.KeyValue == 80 && !shift)
                {
                    keys.Add("p");
                    keysCount["p"] = keysCount.ContainsKey("p") ? keysCount["p"] + 1 : 1;
                }
                if (e.KeyValue == 219 && shift)
                {
                    keys.Add("{");
                    keysCount["{"] = keysCount.ContainsKey("{") ? keysCount["{"] + 1 : 1;
                }
                else if (e.KeyValue == 219 && !shift)
                {
                    keys.Add("[");
                    keysCount["["] = keysCount.ContainsKey("[") ? keysCount["["] + 1 : 1;
                }
                if (e.KeyValue == 221 && shift)
                {
                    keys.Add("}");
                    keysCount["}"] = keysCount.ContainsKey("}") ? keysCount["}"] + 1 : 1;
                }
                else if (e.KeyValue == 221 && !shift)
                {
                    keys.Add("]");
                    keysCount["]"] = keysCount.ContainsKey("]") ? keysCount["]"] + 1 : 1;
                }
                if (e.KeyValue == 65 && shift)
                {
                    keys.Add("A");
                    keysCount["A"] = keysCount.ContainsKey("A") ? keysCount["A"] + 1 : 1;
                }
                else if (e.KeyValue == 65 && !shift)
                {
                    keys.Add("a");
                    keysCount["a"] = keysCount.ContainsKey("a") ? keysCount["a"] + 1 : 1;
                }
                if (e.KeyValue == 83 && shift)
                {
                    keys.Add("S");
                    keysCount["S"] = keysCount.ContainsKey("S") ? keysCount["S"] + 1 : 1;
                }
                else if (e.KeyValue == 83 && !shift)
                {
                    keys.Add("s");
                    keysCount["s"] = keysCount.ContainsKey("s") ? keysCount["s"] + 1 : 1;
                }
                if (e.KeyValue == 68 && shift)
                {
                    keys.Add("D");
                    keysCount["D"] = keysCount.ContainsKey("D") ? keysCount["D"] + 1 : 1;
                }
                else if (e.KeyValue == 68 && !shift)
                {
                    keys.Add("d");
                    keysCount["d"] = keysCount.ContainsKey("d") ? keysCount["d"] + 1 : 1;
                }
                if (e.KeyValue == 70 && shift)
                {
                    keys.Add("F");
                    keysCount["F"] = keysCount.ContainsKey("F") ? keysCount["F"] + 1 : 1;
                }
                else if (e.KeyValue == 70 && !shift)
                {
                    keys.Add("f");
                    keysCount["f"] = keysCount.ContainsKey("f") ? keysCount["f"] + 1 : 1;
                }
                if (e.KeyValue == 71 && shift)
                {
                    keys.Add("G");
                    keysCount["G"] = keysCount.ContainsKey("G") ? keysCount["G"] + 1 : 1;
                }
                else if (e.KeyValue == 71 && !shift)
                {
                    keys.Add("g");
                    keysCount["g"] = keysCount.ContainsKey("g") ? keysCount["g"] + 1 : 1;
                }
                if (e.KeyValue == 72 && shift)
                {
                    keys.Add("H");
                    keysCount["H"] = keysCount.ContainsKey("H") ? keysCount["H"] + 1 : 1;
                }
                else if (e.KeyValue == 72 && !shift)
                {
                    keys.Add("h");
                    keysCount["h"] = keysCount.ContainsKey("h") ? keysCount["h"] + 1 : 1;
                }
                if (e.KeyValue == 74 && shift)
                {
                    keys.Add("J");
                    keysCount["J"] = keysCount.ContainsKey("J") ? keysCount["J"] + 1 : 1;
                }
                else if (e.KeyValue == 74 && !shift)
                {
                    keys.Add("j");
                    keysCount["j"] = keysCount.ContainsKey("j") ? keysCount["j"] + 1 : 1;
                }
                if (e.KeyValue == 75 && shift)
                {
                    keys.Add("K");
                    keysCount["K"] = keysCount.ContainsKey("K") ? keysCount["K"] + 1 : 1;
                }
                else if (e.KeyValue == 75 && !shift)
                {
                    keys.Add("k");
                    keysCount["k"] = keysCount.ContainsKey("k") ? keysCount["k"] + 1 : 1;
                }
                if (e.KeyValue == 76 && shift)
                {
                    keys.Add("L");
                    keysCount["L"] = keysCount.ContainsKey("L") ? keysCount["L"] + 1 : 1;
                }
                else if (e.KeyValue == 76 && !shift)
                {
                    keys.Add("l");
                    keysCount["l"] = keysCount.ContainsKey("l") ? keysCount["l"] + 1 : 1;
                }
                if (e.KeyValue == 186 && shift)
                {
                    keys.Add(":");
                    keysCount[":"] = keysCount.ContainsKey(":") ? keysCount[":"] + 1 : 1;
                }
                else if (e.KeyValue == 186 && !shift)
                {
                    keys.Add(";");
                    keysCount[";"] = keysCount.ContainsKey(";") ? keysCount[";"] + 1 : 1;
                }
                if (e.KeyValue == 222 && shift)
                {
                    keys.Add("\"");
                    keysCount["\""] = keysCount.ContainsKey("\"") ? keysCount["\""] + 1 : 1;
                }
                else if (e.KeyValue == 222 && !shift)
                {
                    keys.Add("\'");
                    keysCount["\'"] = keysCount.ContainsKey("\'") ? keysCount["\'"] + 1 : 1;
                }
                if (e.KeyValue == 220 && shift)
                {
                    keys.Add("|");
                    keysCount["|"] = keysCount.ContainsKey("|") ? keysCount["|"] + 1 : 1;
                }
                else if (e.KeyValue == 220 && !shift)
                {
                    keys.Add("\\");
                    keysCount["\\"] = keysCount.ContainsKey("\\") ? keysCount["\\"] + 1 : 1;
                }
                if (e.KeyValue == 226 && shift)
                {
                    keys.Add("|");
                    keysCount["|"] = keysCount.ContainsKey("|") ? keysCount["|"] + 1 : 1;
                }
                else if (e.KeyValue == 226 && !shift)
                {
                    keys.Add("\\");
                    keysCount["\\"] = keysCount.ContainsKey("\\") ? keysCount["\\"] + 1 : 1;
                }
                if (e.KeyValue == 90 && shift)
                {
                    keys.Add("Z");
                    keysCount["Z"] = keysCount.ContainsKey("Z") ? keysCount["Z"] + 1 : 1;
                }
                else if (e.KeyValue == 90 && !shift)
                {
                    keys.Add("z");
                    keysCount["z"] = keysCount.ContainsKey("z") ? keysCount["z"] + 1 : 1;
                }
                if (e.KeyValue == 88 && shift)
                {
                    keys.Add("X");
                    keysCount["X"] = keysCount.ContainsKey("X") ? keysCount["X"] + 1 : 1;
                }
                else if (e.KeyValue == 88 && !shift)
                {
                    keys.Add("x");
                    keysCount["x"] = keysCount.ContainsKey("x") ? keysCount["x"] + 1 : 1;
                }
                if (e.KeyValue == 67 && shift)
                {
                    keys.Add("C");
                    keysCount["C"] = keysCount.ContainsKey("C") ? keysCount["C"] + 1 : 1;
                }
                else if (e.KeyValue == 67 && !shift)
                {
                    keys.Add("c");
                    keysCount["c"] = keysCount.ContainsKey("c") ? keysCount["c"] + 1 : 1;
                }
                if (e.KeyValue == 86 && shift)
                {
                    keys.Add("V");
                    keysCount["V"] = keysCount.ContainsKey("V") ? keysCount["V"] + 1 : 1;
                }
                else if (e.KeyValue == 86 && !shift)
                {
                    keys.Add("v");
                    keysCount["v"] = keysCount.ContainsKey("v") ? keysCount["v"] + 1 : 1;
                }
                if (e.KeyValue == 66 && shift)
                {
                    keys.Add("B");
                    keysCount["B"] = keysCount.ContainsKey("B") ? keysCount["B"] + 1 : 1;
                }
                else if (e.KeyValue == 66 && !shift)
                {
                    keys.Add("b");
                    keysCount["b"] = keysCount.ContainsKey("b") ? keysCount["b"] + 1 : 1;
                }
                if (e.KeyValue == 78 && shift)
                {
                    keys.Add("N");
                    keysCount["N"] = keysCount.ContainsKey("N") ? keysCount["N"] + 1 : 1;
                }
                else if (e.KeyValue == 78 && !shift)
                {
                    keys.Add("n");
                    keysCount["n"] = keysCount.ContainsKey("n") ? keysCount["n"] + 1 : 1;
                }
                if (e.KeyValue == 77 && shift)
                {
                    keys.Add("M");
                    keysCount["M"] = keysCount.ContainsKey("M") ? keysCount["M"] + 1 : 1;
                }
                else if (e.KeyValue == 77 && !shift)
                {
                    keys.Add("m");
                    keysCount["m"] = keysCount.ContainsKey("m") ? keysCount["m"] + 1 : 1;
                }
                if (e.KeyValue == 188 && shift)
                {
                    keys.Add("<");
                    keysCount["<"] = keysCount.ContainsKey("<") ? keysCount["<"] + 1 : 1;
                }
                else if (e.KeyValue == 188 && !shift)
                {
                    keys.Add(",");
                    keysCount[","] = keysCount.ContainsKey(",") ? keysCount[","] + 1 : 1;
                }
                if (e.KeyValue == 190 && shift)
                {
                    keys.Add(">");
                    keysCount[">"] = keysCount.ContainsKey(">") ? keysCount[">"] + 1 : 1;
                }
                else if (e.KeyValue == 190 && !shift)
                {
                    keys.Add(".");
                    keysCount["."] = keysCount.ContainsKey(".") ? keysCount["."] + 1 : 1;
                }
                if (e.KeyValue == 191 && shift)
                {
                    keys.Add("?");
                    keysCount["?"] = keysCount.ContainsKey("?") ? keysCount["?"] + 1 : 1;
                }
                else if (e.KeyValue == 191 && !shift)
                {
                    keys.Add("/");
                    keysCount["/"] = keysCount.ContainsKey("/") ? keysCount["/"] + 1 : 1;
                }
                if (e.KeyValue == 192 && shift)
                {
                    keys.Add("~");
                    keysCount["~"] = keysCount.ContainsKey("~") ? keysCount["~"] + 1 : 1;
                }
                else if (e.KeyValue == 192 && !shift)
                {
                    keys.Add("`");
                    keysCount["`"] = keysCount.ContainsKey("`") ? keysCount["`"] + 1 : 1;
                }
                if (e.KeyValue == 49 && shift)
                {
                    keys.Add("!");
                    keysCount["!"] = keysCount.ContainsKey("!") ? keysCount["!"] + 1 : 1;
                }
                else if (e.KeyValue == 49 && !shift)
                {
                    keys.Add("1");
                    keysCount["1"] = keysCount.ContainsKey("1") ? keysCount["1"] + 1 : 1;
                }
                if (e.KeyValue == 50 && shift)
                {
                    keys.Add("@");
                    keysCount["@"] = keysCount.ContainsKey("@") ? keysCount["@"] + 1 : 1;
                }
                else if (e.KeyValue == 50 && !shift)
                {
                    keys.Add("2");
                    keysCount["2"] = keysCount.ContainsKey("2") ? keysCount["2"] + 1 : 1;
                }
                if (e.KeyValue == 51 && shift)
                {
                    keys.Add("#");
                    keysCount["#"] = keysCount.ContainsKey("#") ? keysCount["#"] + 1 : 1;
                }
                else if (e.KeyValue == 51 && !shift)
                {
                    keys.Add("3");
                    keysCount["3"] = keysCount.ContainsKey("3") ? keysCount["3"] + 1 : 1;
                }
                if (e.KeyValue == 52 && shift)
                {
                    keys.Add("$");
                    keysCount["$"] = keysCount.ContainsKey("$") ? keysCount["$"] + 1 : 1;
                }
                else if (e.KeyValue == 52 && !shift)
                {
                    keys.Add("4");
                    keysCount["4"] = keysCount.ContainsKey("4") ? keysCount["4"] + 1 : 1;
                }
                if (e.KeyValue == 53 && shift)
                {
                    keys.Add("%");
                    keysCount["%"] = keysCount.ContainsKey("%") ? keysCount["%"] + 1 : 1;
                }
                else if (e.KeyValue == 53 && !shift)
                {
                    keys.Add("5");
                    keysCount["5"] = keysCount.ContainsKey("5") ? keysCount["5"] + 1 : 1;
                }
                if (e.KeyValue == 54 && shift)
                {
                    keys.Add("^");
                    keysCount["^"] = keysCount.ContainsKey("^") ? keysCount["^"] + 1 : 1;
                }
                else if (e.KeyValue == 54 && !shift)
                {
                    keys.Add("6");
                    keysCount["6"] = keysCount.ContainsKey("6") ? keysCount["6"] + 1 : 1;
                }
                if (e.KeyValue == 55 && shift)
                {
                    keys.Add("&");
                    keysCount["&"] = keysCount.ContainsKey("&") ? keysCount["&"] + 1 : 1;
                }
                else if (e.KeyValue == 55 && !shift)
                {
                    keys.Add("7");
                    keysCount["7"] = keysCount.ContainsKey("7") ? keysCount["7"] + 1 : 1;
                }
                if (e.KeyValue == 56 && shift)
                {
                    keys.Add("*");
                    keysCount["*"] = keysCount.ContainsKey("*") ? keysCount["*"] + 1 : 1;
                }
                else if (e.KeyValue == 56 && !shift)
                {
                    keys.Add("8");
                    keysCount["8"] = keysCount.ContainsKey("8") ? keysCount["8"] + 1 : 1;
                }
                if (e.KeyValue == 57 && shift)
                {
                    keys.Add("(");
                    keysCount["("] = keysCount.ContainsKey("(") ? keysCount["("] + 1 : 1;
                }
                else if (e.KeyValue == 57 && !shift)
                {
                    keys.Add("9");
                    keysCount["9"] = keysCount.ContainsKey("9") ? keysCount["9"] + 1 : 1;
                }
                if (e.KeyValue == 48 && shift)
                {
                    keys.Add(")");
                    keysCount[")"] = keysCount.ContainsKey(")") ? keysCount[")"] + 1 : 1;
                }
                else if (e.KeyValue == 48 && !shift)
                {
                    keys.Add("0");
                    keysCount["0"] = keysCount.ContainsKey("0") ? keysCount["0"] + 1 : 1;
                }
                if (e.KeyValue == 189 && shift)
                {
                    keys.Add("_");
                    keysCount["_"] = keysCount.ContainsKey("_") ? keysCount["_"] + 1 : 1;
                }
                else if (e.KeyValue == 189 && !shift)
                {
                    keys.Add("-");
                    keysCount["-"] = keysCount.ContainsKey("-") ? keysCount["-"] + 1 : 1;
                }
                if (e.KeyValue == 187 && shift)
                {
                    keys.Add("+");
                    keysCount["+"] = keysCount.ContainsKey("+") ? keysCount["+"] + 1 : 1;
                }
                else if (e.KeyValue == 187 && !shift)
                {
                    keys.Add("=");
                    keysCount["="] = keysCount.ContainsKey("=") ? keysCount["="] + 1 : 1;
                }

                //Other keyys
                if (e.KeyValue == 32 && shift || e.KeyValue == 32 && !shift)
                {
                    keys.Add(" ");
                    keysCount["Space"] = keysCount.ContainsKey("Space") ? keysCount["Space"] + 1 : 1;

                }
                if (e.KeyValue == 27)
                {
                    if (keys.Count >= 0 && !keys.Contains("Esc"))
                    {
                        keys.Add("Esc");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Esc") keys.Add("Esc");
                    keysCount["Esc"] = keysCount.ContainsKey("Esc") ? keysCount["Esc"] + 1 : 1;
                }
                if (e.KeyValue == 162 || e.KeyValue == 163)
                {
                    if (keys.Count >= 0 && !keys.Contains("Ctrl"))
                    {
                        keys.Add("Ctrl");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Ctrl") keys.Add("Ctrl");
                    keysCount["Ctrl"] = keysCount.ContainsKey("Ctrl") ? keysCount["Ctrl"] + 1 : 1;
                }
                if (e.KeyValue == 160 || e.KeyValue == 161)
                {
                    if (keys.Count >= 0 && !keys.Contains("Shift"))
                    {
                        keys.Add("Shift");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Shift") keys.Add("Shift");
                    keysCount["Shift"] = keysCount.ContainsKey("Shift") ? keysCount["Shift"] + 1 : 1;
                }
                if (e.KeyValue == 9)
                {
                    if (keys.Count >= 0 && !keys.Contains("Tab"))
                    {
                        keys.Add("Tab");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Tab") keys.Add("Tab");
                    keysCount["Tab"] = keysCount.ContainsKey("Tab") ? keysCount["Tab"] + 1 : 1;
                }
                if (e.KeyValue == 20)
                {
                    if (keys.Count >= 0 && !keys.Contains("CapsLock"))
                    {
                        keys.Add("CapsLock");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "CapsLock") keys.Add("CapsLock");
                    keysCount["CapsLock"] = keysCount.ContainsKey("CapsLock") ? keysCount["CapsLock"] + 1 : 1;
                }
                if (e.KeyValue == 164)
                {
                    if (keys.Count >= 0 && !keys.Contains("Alt"))
                    {
                        keys.Add("Alt");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Alt") keys.Add("Alt");
                    keysCount["Alt"] = keysCount.ContainsKey("Alt") ? keysCount["Alt"] + 1 : 1;
                }
                //Keys F1-F12
                if (e.KeyValue >= 112 && e.KeyValue <= 123)
                {
                    if (keys.Count >= 0 && !keys.Contains(e.KeyCode.ToString()))
                    {
                        keys.Add(e.KeyCode.ToString());
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != e.KeyCode.ToString()) keys.Add(e.KeyCode.ToString());
                    keysCount[e.KeyCode.ToString()] = keysCount.ContainsKey(e.KeyCode.ToString()) ? keysCount[e.KeyCode.ToString()] + 1 : 1;
                }
                if (e.KeyValue == 8)
                {
                    if (keys.Count >= 0 && !keys.Contains("Back"))
                    {
                        keys.Add("Back");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Back") keys.Add("Back");
                    keysCount["Back"] = keysCount.ContainsKey("Back") ? keysCount["Back"] + 1 : 1;
                }
                if (e.KeyValue == 13)
                {
                    if (keys.Count >= 0 && !keys.Contains("Enter"))
                    {
                        keys.Add("Enter");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Enter") keys.Add("Enter");
                    keysCount["Enter"] = keysCount.ContainsKey("Enter") ? keysCount["Enter"] + 1 : 1;
                }
                if (e.KeyValue == 44)
                {
                    if (keys.Count >= 0 && !keys.Contains("PrtScn"))
                    {
                        keys.Add("PrtScn");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "PrtScn") keys.Add("PrtScn");
                    keysCount["PrtScn"] = keysCount.ContainsKey("PrtScn") ? keysCount["PrtScn"] + 1 : 1;
                }
                if (e.KeyValue == 145)
                {
                    if (keys.Count >= 0 && !keys.Contains("Scroll"))
                    {
                        keys.Add("Scroll");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Scroll") keys.Add("Scroll");
                    keysCount["Scroll"] = keysCount.ContainsKey("Scroll") ? keysCount["Scroll"] + 1 : 1;
                }
                if (e.KeyValue == 19)
                {
                    if (keys.Count >= 0 && !keys.Contains("Pause"))
                    {
                        keys.Add("Pause");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Pause") keys.Add("Pause");
                    keysCount["Pause"] = keysCount.ContainsKey("Pause") ? keysCount["Pause"] + 1 : 1;
                }
                if (e.KeyValue == 45)
                {
                    if (keys.Count >= 0 && !keys.Contains("Ins"))
                    {
                        keys.Add("Ins");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Ins") keys.Add("Ins");
                    keysCount["Ins"] = keysCount.ContainsKey("Ins") ? keysCount["Ins"] + 1 : 1;
                }
                if (e.KeyValue == 46)
                {
                    if (keys.Count >= 0 && !keys.Contains("Del"))
                    {
                        keys.Add("Del");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Del") keys.Add("Del");
                    keysCount["Del"] = keysCount.ContainsKey("Del") ? keysCount["Del"] + 1 : 1;
                }
                if (e.KeyValue == 36)
                {
                    if (keys.Count >= 0 && !keys.Contains("Home"))
                    {
                        keys.Add("Home");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "Home") keys.Add("Home");
                    keysCount["Home"] = keysCount.ContainsKey("Home") ? keysCount["Home"] + 1 : 1;
                }
                if (e.KeyValue == 35)
                {
                    if (keys.Count >= 0 && !keys.Contains("End"))
                    {
                        keys.Add("End");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "End") keys.Add("End");
                    keysCount["End"] = keysCount.ContainsKey("End") ? keysCount["End"] + 1 : 1;
                }
                if (e.KeyValue == 33)
                {
                    if (keys.Count >= 0 && !keys.Contains("PageUp"))
                    {
                        keys.Add("PageUp");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "PageUp") keys.Add("PageUp");
                    keysCount["PageUp"] = keysCount.ContainsKey("PageUp") ? keysCount["PageUp"] + 1 : 1;
                }
                if (e.KeyValue == 34)
                {
                    if (keys.Count >= 0 && !keys.Contains("PageDown"))
                    {
                        keys.Add("PageDown");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "PageDown") keys.Add("PageDown");
                    keysCount["PageDown"] = keysCount.ContainsKey("PageDown") ? keysCount["PageDown"] + 1 : 1;
                }
                if (e.KeyValue == 38)
                {
                    if (keys.Count >= 0 && !keys.Contains("↑"))
                    {
                        keys.Add("↑");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "↑") keys.Add("↑");
                    keysCount["↑"] = keysCount.ContainsKey("↑") ? keysCount["↑"] + 1 : 1;
                }
                if (e.KeyValue == 37)
                {
                    if (keys.Count >= 0 && !keys.Contains("←"))
                    {
                        keys.Add("←");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "←") keys.Add("←");
                    keysCount["←"] = keysCount.ContainsKey("←") ? keysCount["←"] + 1 : 1;
                }
                if (e.KeyValue == 39)
                {
                    if (keys.Count >= 0 && !keys.Contains("→"))
                    {
                        keys.Add("→");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "→") keys.Add("→");
                    keysCount["→"] = keysCount.ContainsKey("→") ? keysCount["→"] + 1 : 1;
                }
                if (e.KeyValue == 40)
                {
                    if (keys.Count >= 0 && !keys.Contains("↓"))
                    {
                        keys.Add("↓");
                    }
                    else if (keys.Count > 0 && keys[keys.Count - 1] != "↓") keys.Add("↓");
                    keysCount["↓"] = keysCount.ContainsKey("↓") ? keysCount["↓"] + 1 : 1;
                }
                if (numLock)
                {
                    if (e.KeyValue == 96 && shift)
                    {
                        keys.Add("Ins");
                        keysCount["Ins"] = keysCount.ContainsKey("Ins") ? keysCount["Ins"] + 1 : 1;
                    }
                    else if (e.KeyValue == 96 && !shift)
                    {
                        keys.Add("0");
                        keysCount["0"] = keysCount.ContainsKey("0") ? keysCount["0"] + 1 : 1;
                    }
                    if (e.KeyValue == 110 && shift)
                    {
                        keys.Add("Del");
                        keysCount["Del"] = keysCount.ContainsKey("Del") ? keysCount["Del"] + 1 : 1;
                    }
                    else if (e.KeyValue == 110 && !shift)
                    {
                        keys.Add(".");
                        keysCount["."] = keysCount.ContainsKey(".") ? keysCount["."] + 1 : 1;
                    }
                    if (e.KeyValue == 97 && shift)
                    {
                        keys.Add("End");
                        keysCount["End"] = keysCount.ContainsKey("End") ? keysCount["End"] + 1 : 1;
                    }
                    else if (e.KeyValue == 97 && !shift)
                    {
                        keys.Add("1");
                        keysCount["1"] = keysCount.ContainsKey("1") ? keysCount["1"] + 1 : 1;
                    }
                    if (e.KeyValue == 98 && shift)
                    {
                        keys.Add("↓");
                        keysCount["↓"] = keysCount.ContainsKey("↓") ? keysCount["↓"] + 1 : 1;
                    }
                    else if (e.KeyValue == 98 && !shift)
                    {
                        keys.Add("2");
                        keysCount["2"] = keysCount.ContainsKey("2") ? keysCount["2"] + 1 : 1;
                    }
                    if (e.KeyValue == 99 && shift)
                    {
                        keys.Add("PageDown");
                        keysCount["PageDown"] = keysCount.ContainsKey("PageDown") ? keysCount["PageDown"] + 1 : 1;
                    }
                    else if (e.KeyValue == 99 && !shift)
                    {
                        keys.Add("3");
                        keysCount["3"] = keysCount.ContainsKey("3") ? keysCount["3"] + 1 : 1;
                    }
                    if (e.KeyValue == 100 && shift)
                    {
                        keys.Add("←");
                        keysCount["←"] = keysCount.ContainsKey("←") ? keysCount["←"] + 1 : 1;
                    }
                    else if (e.KeyValue == 100 && !shift)
                    {
                        keys.Add("4");
                        keysCount["4"] = keysCount.ContainsKey("4") ? keysCount["4"] + 1 : 1;
                    }
                    //При натисканні Shift+NumPad5 з активованим NumLock потрібно детальніше перевірити обробку цієї ситуації
                    if (e.KeyValue == 101 && shift)
                    {
                        keys.Add("Clear");
                        keysCount["Clear"] = keysCount.ContainsKey("Clear") ? keysCount["Clear"] + 1 : 1;
                    }
                    else if (e.KeyValue == 101 && !shift)
                    {
                        keys.Add("5");
                        keysCount["5"] = keysCount.ContainsKey("5") ? keysCount["5"] + 1 : 1;
                    }
                    if (e.KeyValue == 102 && shift)
                    {
                        keys.Add("→");
                        keysCount["→"] = keysCount.ContainsKey("→") ? keysCount["→"] + 1 : 1;
                    }
                    else if (e.KeyValue == 102 && !shift)
                    {
                        keys.Add("6");
                        keysCount["6"] = keysCount.ContainsKey("6") ? keysCount["6"] + 1 : 1;
                    }
                    if (e.KeyValue == 103 && shift)
                    {
                        keys.Add("Home");
                        keysCount["Home"] = keysCount.ContainsKey("Home") ? keysCount["Home"] + 1 : 1;
                    }
                    else if (e.KeyValue == 103 && !shift)
                    {
                        keys.Add("7");
                        keysCount["7"] = keysCount.ContainsKey("7") ? keysCount["7"] + 1 : 1;
                    }
                    if (e.KeyValue == 104 && shift)
                    {
                        keys.Add("↑");
                        keysCount["↑"] = keysCount.ContainsKey("↑") ? keysCount["↑"] + 1 : 1;
                    }
                    else if (e.KeyValue == 104 && !shift)
                    {
                        keys.Add("8");
                        keysCount["8"] = keysCount.ContainsKey("8") ? keysCount["8"] + 1 : 1;
                    }
                    if (e.KeyValue == 105 && shift)
                    {
                        keys.Add("PageUp");
                        keysCount["PageUp"] = keysCount.ContainsKey("PageUp") ? keysCount["PageUp"] + 1 : 1;
                    }
                    else if (e.KeyValue == 105 && !shift)
                    {
                        keys.Add("9");
                        keysCount["9"] = keysCount.ContainsKey("9") ? keysCount["9"] + 1 : 1;
                    }
                    if (e.KeyValue == 111)
                    {
                        keys.Add("/");
                        keysCount["/"] = keysCount.ContainsKey("/") ? keysCount["/"] + 1 : 1;
                    }
                    if (e.KeyValue == 106)
                    {
                        keys.Add("*");
                        keysCount["*"] = keysCount.ContainsKey("*") ? keysCount["*"] + 1 : 1;
                    }
                    if (e.KeyValue == 107)
                    {
                        keys.Add("+");
                        keysCount["+"] = keysCount.ContainsKey("+") ? keysCount["+"] + 1 : 1;
                    }
                    if (e.KeyValue == 109)
                    {
                        keys.Add("-");
                        keysCount["-"] = keysCount.ContainsKey("-") ? keysCount["-"] + 1 : 1;
                    }

                }
                else if (!numLock)
                {
                    if (e.KeyValue == 12 && shift)
                    {
                        if (keys.Count >= 0 && !keys.Contains("Clear"))
                        {
                            keys.Add("Clear");
                        }
                        else if (keys.Count > 0 && keys[keys.Count - 1] != "Clear") keys.Add("Clear");
                        keysCount["Clear"] = keysCount.ContainsKey("Clear") ? keysCount["Clear"] + 1 : 1;
                    }
                    else if (e.KeyValue == 12 && !shift)
                    {
                        keys.Add("5");
                        keysCount["5"] = keysCount.ContainsKey("5") ? keysCount["5"] + 1 : 1;
                    }
                    if (e.KeyValue == 110 && shift)
                    {
                        keys.Add("Del");
                        keysCount["Del"] = keysCount.ContainsKey("Del") ? keysCount["Del"] + 1 : 1;
                    }
                    else if (e.KeyValue == 110 && !shift)
                    {
                        keys.Add("Del");
                        keysCount["Del"] = keysCount.ContainsKey("Del") ? keysCount["Del"] + 1 : 1;
                    }
                    if (e.KeyValue == 111)
                    {
                        keys.Add("/");
                        keysCount["/"] = keysCount.ContainsKey("/") ? keysCount["/"] + 1 : 1;
                    }
                    if (e.KeyValue == 106)
                    {
                        keys.Add("*");
                        keysCount["*"] = keysCount.ContainsKey("*") ? keysCount["*"] + 1 : 1;
                    }
                    if (e.KeyValue == 107)
                    {
                        keys.Add("+");
                        keysCount["+"] = keysCount.ContainsKey("+") ? keysCount["+"] + 1 : 1;
                    }
                    if (e.KeyValue == 109)
                    {
                        keys.Add("-");
                        keysCount["-"] = keysCount.ContainsKey("-") ? keysCount["-"] + 1 : 1;
                    }
                }
            }


            KeyPress.Text = "";
            foreach (var key in keys)
            {
                KeyPress.Text += key;
            }
            label2.Text = "";
            foreach (var key in keysCount)
            {
                label2.Text += key.ToString();
            }
            //label3.Text = currentLanguage;
            //KeyPress.Text += e.KeyCode;
            /*ShowWindow(this.Handle, 0);
            Thread.Sleep(3000);
            ShowWindow(this.Handle, 1);*/

        }

        
    }
}