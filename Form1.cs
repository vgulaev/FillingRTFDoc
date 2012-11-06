using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace FillingRTFDoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string chartoRTFstyle(string str)
        {
            return ("\\'" + BitConverter.ToString(Encoding.GetEncoding("Windows-1251").GetBytes(str)));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Char letterChar = 'Г';
            Encoding.Unicode.GetBytes("Г");
            Char.ToString('Г');
            //textBox2.Text = Char.ConvertToUtf32("U");
            //textBox2.Text = BitConverter.ToString(Encoding.Unicode.GetBytes("{"));
            //\'c5
            textBox2.Text = chartoRTFstyle("Г");
            //Encoding.GetEncoding("Windows-1251").GetBytes
            //Encoding.Unicode.GetString(Encoding.Unicode.GetBytes("Г"));
            
            Stream resourseStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FillingRTFDoc.template_doc.rtf");
            StreamReader tr = new StreamReader(resourseStream);
            StreamWriter tw = new StreamWriter("data.rtf");

            String stringDoc = tr.ReadToEnd();

            //"\'" + BitConverter.ToString(Encoding.GetEncoding("Windows-1251").GetBytes("Г"))
            stringDoc = stringDoc.Replace("$n01", chartoRTFstyle("Г"));
            stringDoc = stringDoc.Replace("$n02", chartoRTFstyle("у"));
            stringDoc = stringDoc.Replace("$n03", chartoRTFstyle("л"));

            tw.Write(stringDoc);
            tw.Close();

            Process.Start("data.rtf");
        }
    }
}
