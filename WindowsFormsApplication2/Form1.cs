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
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        String key;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            key = this.apibox.Text;
            listperso.Items.Clear();
            try {
                WebRequest request = WebRequest.Create("https://api.guildwars2.com/v2/characters?access_token=" + key);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();               
                List<string> perso = JsonConvert.DeserializeObject<List<string>>(responseString);
                listperso.Items.AddRange(perso.ToArray());
            }
            catch
            {
                listperso.Items.Add("Clé incorrecte");
            }
            
        }

        private void listperso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listperso.SelectedItem != null)
            {
                button2.Enabled = true;                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String value = listperso.SelectedItem.ToString();
            var form = new Form2(value,key,this);
            form.Show();
            //MessageBox.Show(value);
        }

        private void cleapi_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        public void updateBar()
        {           
            progressBar2.PerformStep();
        }

        public void iniPrgBar(int equip)
        {
            progressBar2.Maximum = equip + 4;
            progressBar2.Minimum = 0;
            progressBar2.Step = 1;
        }
    }

}
