using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        Form1 form;
        public Form2(String name,String key, Form1 frm1)
        {

            form = frm1;
            
            InitializeComponent();
            persName.Text = name;
            button1.Hide();

            WebRequest request = WebRequest.Create("https://api.guildwars2.com/v2/characters/" + name + "?access_token=" + key);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Personnages perso = JsonConvert.DeserializeObject<Personnages>(responseString);

            int nbEquip = perso.equipment.Count;

            form.iniPrgBar(nbEquip);
            form.progressBar2.Value = 0;

            labRace.Text = perso.race;
            form.updateBar();
            labSexe.Text = perso.gender;
            form.updateBar();
            labClasse.Text = perso.profession;
            form.updateBar();
            labNiveau.Text = perso.level;
            form.updateBar();
            for (int i=0; i<nbEquip; i++)
            {
                String slot = perso.equipment[i].slot;
                switch (slot)
                {
                    case "Helm":
                        string helm = perso.equipment[i].id;
                        pictureBoxHelm.ImageLocation = recupImg(helm);
                        break;
                    case "Gloves":
                        string gloves = perso.equipment[i].id;
                        pictureBoxGloves.ImageLocation = recupImg(gloves);
                        break;
                    case "Boots":
                        string boots = perso.equipment[i].id;
                        pictureBoxBoots.ImageLocation = recupImg(boots);
                        break;
                    case "Coat":
                        string coat = perso.equipment[i].id;
                        pictureBoxCoat.ImageLocation = recupImg(coat);
                        break;
                    case "Leggings":
                        string leggings = perso.equipment[i].id;
                        pictureBoxLeg.ImageLocation = recupImg(leggings);
                        break;
                    case "Shoulders":
                        string shoulders = perso.equipment[i].id;
                        pictureBoxShould.ImageLocation = recupImg(shoulders);
                        break;
                    case "Accessory1":
                        string acces1 = perso.equipment[i].id;
                        pictureAcces1.ImageLocation = recupImg(acces1);
                        break;
                    case "Accessory2":
                        string acces2 = perso.equipment[i].id;
                        pictureAcces2.ImageLocation = recupImg(acces2);
                        break;
                    case "Ring1":
                        string ring1 = perso.equipment[i].id;
                        pictureRing1.ImageLocation = recupImg(ring1);
                        break;
                    case "Ring2":
                        string ring2 = perso.equipment[i].id;
                        pictureRing2.ImageLocation = recupImg(ring2);
                        break;
                    case "Amulet":
                        string amu = perso.equipment[i].id;
                        pictureAmu.ImageLocation = recupImg(amu);
                        break;
                    case "WeaponAquaticA":
                        string aquaA = perso.equipment[i].id;
                        pictureWeapAquaA.ImageLocation = recupImg(aquaA);
                        break;
                    case "WeaponAquaticB":
                        string aquaB = perso.equipment[i].id;
                        pictureWeapAquaB.ImageLocation = recupImg(aquaB);
                        break;
                    case "WeaponA1":
                        string weapa1 = perso.equipment[i].id;
                        pictureWeapA1.ImageLocation = recupImg(weapa1);
                        break;
                    case "WeaponA2":
                        string weapa2 = perso.equipment[i].id;
                        pictureWeapA2.ImageLocation = recupImg(weapa2);
                        break;
                    case "WeaponB1":
                        string weapb1 = perso.equipment[i].id;
                        pictureWeapB1.ImageLocation = recupImg(weapb1);
                        break;
                    case "WeaponB2":
                        string weapb2 = perso.equipment[i].id;
                        pictureWeapB2.ImageLocation = recupImg(weapb2);
                        break;
                    case "Backpack":
                        string back = perso.equipment[i].id;
                        pictureBack.ImageLocation = recupImg(back);
                        break;
                    case "HelmAquatic":
                        string helmAq = perso.equipment[i].id;
                        pictureHelmAqua.ImageLocation = recupImg(helmAq);
                        break;
                    case "Sickle":
                        string sick = perso.equipment[i].id;
                        pictureSick.ImageLocation = recupImg(sick);
                        break;
                    case "Axe":
                        string axe = perso.equipment[i].id;
                        pictureAxe.ImageLocation = recupImg(axe);
                        break;
                    case "Pick":
                        string pick = perso.equipment[i].id;
                        picturePick.ImageLocation = recupImg(pick);
                        break;
                }
                form.updateBar();
            }              
        }

        private string recupImg(string equip)
        {
            WebRequest requeste = WebRequest.Create("https://api.guildwars2.com/v2/items/" + equip);
            var responses = (HttpWebResponse)requeste.GetResponse();
            var responsesString = new StreamReader(responses.GetResponseStream()).ReadToEnd();
            Items item = JsonConvert.DeserializeObject<Items>(responsesString);
            //form.updateBar();

            return item.icon;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labSexe_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxHelm_Click(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pictureBoxHelm, "Your username");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
