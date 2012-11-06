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
            
            Stream resourseStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FillingRTFDoc.template_doc.rtf");
            StreamReader tr = new StreamReader(resourseStream);
            StreamWriter tw = new StreamWriter("data.rtf");

            String stringDoc = tr.ReadToEnd();

            String FIO;

            FIO = textBoxSurname.Text.Trim() + " " + textBoxName.Text.Trim();
            FIO = FIO.Trim() + " " + textBoxAddName.Text.Trim();
            FIO.Trim();
            
            int indexN = 1;
            //filing Surname in Doc
            foreach (char _c in FIO)
            {
                stringDoc = stringDoc.Replace("$n" + String.Format("{0:000}",indexN), chartoRTFstyle(_c.ToString()));
                indexN = indexN + 1;
            }

            for (int i = indexN; i < 38 ; i++)
            {
                stringDoc = stringDoc.Replace("$n" + String.Format("{0:000}", i), "");
            }

            FIO = textBoxSurname1.Text.Trim() + " " + textBoxName1.Text.Trim();
            FIO = FIO.Trim() + " " + textBoxAddName1.Text.Trim();
            FIO.Trim();

            indexN = 101;
            //filing Surname in Doc
            foreach (char _c in FIO)
            {
                stringDoc = stringDoc.Replace("$n" + String.Format("{0:000}", indexN), chartoRTFstyle(_c.ToString()));
                indexN = indexN + 1;
            }

            for (int i = indexN; i < 138; i++)
            {
                stringDoc = stringDoc.Replace("$n" + String.Format("{0:000}", i), "");
            }

            tw.Write(stringDoc);
            tw.Close();

            Process.Start("data.rtf");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
