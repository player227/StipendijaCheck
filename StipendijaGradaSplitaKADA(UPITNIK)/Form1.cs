using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace StipendijaGradaSplitaKADA_UPITNIK_
{
    public partial class Form1 : Form
    {

        List<string> NOs = new List<string> {"LMAO no", "Same. But different. But same.","Ocu nadoknadu za dusevne boli", "rezultati natječaja su mi u top 5 favorita", "cuj to zakon. cuj to rok.", "coming soon . . .  NOT", "posalji in mail, sigurno ce upalit"
                , "sist ce 8 keka odjednom TOP", "It's been 84 years...", "Prije ce napravit novog Shreka" };
        //List<int> NOs_index = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int counter = 0;
        
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            button1.PerformClick();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // URL = https://www.split.hr/natjecaji-i-oglasi/rezultati-natjecaja
            // document.getElementsByClassName("edn-feed__item").length = broj elemenata koje tražimo na stranici,  = 0 jer nema nista, ovu promjenu pratimo

            string key = "edn-feed__item";
            string url = "https://www.split.hr/natjecaji-i-oglasi/rezultati-natjecaja";


            WebClient client = new WebClient();
            var data = client.DownloadData(url);
            string html = Encoding.UTF8.GetString(data);

            if (this.Name.Length <= 24) this.Name.Append('?');// za ovu sirinu max "?" u imenu forme je 14, skupa sa pocetnin nazivom stipendija to je 24

            if (html.Contains(key))
            {
                //true - učitaj YES gif
                pictureBox1.Image = Properties.Resources.yes;
                label1.Text = "IT'S HAPPENING!!!";
            }
            else
            {
                //false - učitaj jedan od NO stringova
                pictureBox1.Image = Properties.Resources.no;
                label1.Text = NOs[counter++];
            }
            if (counter == 10) counter = 0;

        }

       
    }

}
