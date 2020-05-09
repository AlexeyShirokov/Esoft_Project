using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class Menu : System.Windows.Forms.Form
    {
        public Menu()
        {
            InitializeComponent();
            if (FormAuthorization.users.type == "agent") buttonOpenAgents.Enabled = false;
            labelHello.Text = "ПРиветствую тебя, " + FormAuthorization.users.login;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpenClients_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formClient = new FormClient();
            formClient.Show();

        }

        private void buttonOpenRealEstates_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formRealEstate = new FormRealEstate();
            formRealEstate.Show();
        }

        private void buttonOpenAgents_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formAgents = new FormAgents();
            formAgents.Show();
        }

        private void buttonOpenDemands_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formSupply = new FormSupply();
            formSupply.Show();
        }

        private void buttonOpenSupplies_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formNeeds = new Form_DemandSet();
            formNeeds.Show();

        }

        private void buttonOpenDeals_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form formDeals = new FormDeal();
            formDeals.Show();
        }

       
    }
}
