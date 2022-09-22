using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace XML
{
    public partial class Form1 : Form
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Languages));
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("languages.xml", FileMode.OpenOrCreate))
            {
                Languages? languages = xmlSerializer.Deserialize(fs) as Languages;
                Console.WriteLine($"Name: {languages?.Name}  Creator: {languages?.Creator}");
            }
        }
    }
    //[Serializable]
    public class Languages
    {
        public string Name { get; set; } = "Undefined";
        public string Creator { get; set; } = "Undefined";

        public Languages() { }
        public Languages(string name, string creator)
        {
            Name = name;
            Creator = creator;
        }
    }
}
