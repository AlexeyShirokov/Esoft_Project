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
    public partial class Form_DemandSet : System.Windows.Forms.Form
    {
        public Form_DemandSet()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            ShowDemandSet();
            ShowClients();
            ShowAgents();
        }




        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewApartment.Visible = true;
                textBoxMaxPrise.Visible = true;
                textBoxMinPrise.Visible = true;
                textBoxMaxS.Visible = true;
                textBoxMinS.Visible = true;
                textBoxMinRooms.Visible = true;
                textBoxMaxRooms.Visible = true;
                textBoxMinTotalFloors.Visible = true;
                textBoxMaxTotalFloors.Visible = true;
                textBoxMinFloor.Visible = true;
                textBoxMaxFloor.Visible = true;
                labelMinTotalFloors.Visible = true;
                labelMaxTotalFloors.Visible = true;
                labelMinFloor.Visible = true;
                labelMaxFloor.Visible = true;


                listViewHouse.Visible = false;
                listViewLand.Visible = false;

                /*textBoxMaxFloor.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxS.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinPrise.Text = "";*/
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewHouse.Visible = true;
                textBoxMaxPrise.Visible = true;
                textBoxMinPrise.Visible = true;
                textBoxMaxS.Visible = true;
                textBoxMinS.Visible = true;
                textBoxMinRooms.Visible = true;
                textBoxMaxRooms.Visible = true;
                textBoxMinTotalFloors.Visible = true;
                textBoxMaxTotalFloors.Visible = true;
                textBoxMinFloor.Visible = true;
                textBoxMaxFloor.Visible = true;
                labelMinTotalFloors.Visible = true;
                labelMaxTotalFloors.Visible = true;
                labelMinFloor.Visible = true;
                labelMaxFloor.Visible = true;


                listViewLand.Visible = false;
                listViewApartment.Visible = false;
                labelMinTotalFloors.Visible = false;
                textBoxMinTotalFloors.Visible = false;
                labelMaxTotalFloors.Visible = false;
                textBoxMaxTotalFloors.Visible = false;

                /*textBoxMaxFloor.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxS.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinPrise.Text = "";*/

            }
            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewLand.Visible = true;
                textBoxMaxPrise.Visible = true;
                textBoxMinPrise.Visible = true;
                textBoxMaxS.Visible = true;
                textBoxMinS.Visible = true;
                textBoxMinRooms.Visible = true;
                textBoxMaxRooms.Visible = true;
                textBoxMinTotalFloors.Visible = true;
                textBoxMaxTotalFloors.Visible = true;
                textBoxMinFloor.Visible = true;
                textBoxMaxFloor.Visible = true;
                labelMinTotalFloors.Visible = true;
                labelMaxTotalFloors.Visible = true;
                labelMinFloor.Visible = true;
                labelMaxFloor.Visible = true;


                listViewHouse.Visible = false;
                listViewApartment.Visible = false;
                labelMinTotalFloors.Visible = false;
                textBoxMinTotalFloors.Visible = false;
                labelMaxTotalFloors.Visible = false;
                textBoxMaxTotalFloors.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;

                /*textBoxMaxFloor.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxS.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinPrise.Text = "";*/
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            DemandSet demandSet = new DemandSet();

            demandSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
            demandSet.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
            demandSet.MinArea = Convert.ToDouble(textBoxMinS.Text);
            demandSet.MaxArea = Convert.ToDouble(textBoxMaxS.Text);
            demandSet.MinPrise = Convert.ToInt32(textBoxMinPrise.Text);
            demandSet.MaxPrise = Convert.ToInt32(textBoxMaxPrise.Text);

            if (comboBoxType.SelectedIndex == 0)
            {
                demandSet.Type = 0;
                demandSet.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                demandSet.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                demandSet.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                demandSet.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                demandSet.Type = 1;
                demandSet.MaxFloors = Convert.ToInt32(textBoxMaxFloor.Text);
                demandSet.MinFloors = Convert.ToInt32(textBoxMinFloor.Text);
            }
            else
            {
                demandSet.Type = 2;
            }
            Program.wftDb.DemandSet.Add(demandSet);
            Program.wftDb.SaveChanges();
            ShowDemandSet();
        }
        void ShowDemandSet()
        {
            listViewApartment.Items.Clear();
            listViewHouse.Items.Clear();
            listViewLand.Items.Clear();
            foreach (DemandSet demandSet in Program.wftDb.DemandSet)
            {
                if (demandSet.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                     demandSet.IdAgent.ToString() + ". " + demandSet.AgentsSet.FirstName + " " + demandSet.AgentsSet.LastName,
                     demandSet.IdClient.ToString() + ". " + demandSet.ClientsSet.FirstName + " " + demandSet.ClientsSet.LastName,
                     demandSet.Type.ToString()+". Квартира",
                     demandSet.MinArea.ToString(),
                     demandSet.MaxArea.ToString(),
                     demandSet.MinRooms.ToString(),
                     demandSet.MaxRooms.ToString(),
                     demandSet.MinFloor.ToString(),
                     demandSet.MaxFloor.ToString(),
                     demandSet.MinPrise.ToString(),
                     demandSet.MaxPrise.ToString(),
                    });
                    item.Tag = demandSet;
                    listViewApartment.Items.Add(item);
                }
                else if (demandSet.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                     demandSet.IdAgent.ToString() + ". " + demandSet.AgentsSet.FirstName + "  " + demandSet.AgentsSet.LastName,
                     demandSet.IdClient.ToString() + ". " + demandSet.ClientsSet.FirstName + "  " + demandSet.ClientsSet.LastName,
                     demandSet.Type.ToString() +". Квартира",
                     demandSet.MinPrise.ToString(),
                     demandSet.MaxPrise.ToString(),
                     demandSet.MinArea.ToString(),
                     demandSet.MaxArea.ToString(),
                     demandSet.MinFloors.ToString(),
                     demandSet.MaxFloors.ToString()


                    });
                    item.Tag = demandSet;
                    listViewHouse.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                 demandSet.IdAgent.ToString() + ". " + demandSet.AgentsSet.FirstName + "  " + demandSet.AgentsSet.LastName,
                 demandSet.IdClient.ToString() + ". " + demandSet.ClientsSet.FirstName + " " + demandSet.ClientsSet.LastName,
                 demandSet.Type.ToString() +". Квартира",
                 demandSet.MinPrise.ToString(),
                 demandSet.MaxPrise.ToString(),
                 demandSet.MinArea.ToString(),
                 demandSet.MaxArea.ToString(),
                    });
                    item.Tag = demandSet;
                    listViewLand.Items.Add(item);
                }
            }
            listViewApartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewHouse.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewLand.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewApartment.SelectedItems.Count == 1)
                {
                    DemandSet demandSet = listViewApartment.SelectedItems[0].Tag as DemandSet;
                    demandSet.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demandSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                    demandSet.MinPrise = Convert.ToInt64(textBoxMinPrise.Text);
                    demandSet.MaxPrise = Convert.ToInt64(textBoxMaxPrise.Text);
                    demandSet.MinArea = Convert.ToDouble(textBoxMinS.Text);
                    demandSet.MaxArea = Convert.ToDouble(textBoxMaxS.Text);
                    demandSet.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                    demandSet.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                    demandSet.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                    demandSet.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                if (listViewHouse.SelectedItems.Count == 1)
                {
                    DemandSet demandSet = listViewHouse.SelectedItems[0].Tag as DemandSet;
                    demandSet.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demandSet.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                    demandSet.MinPrise = Convert.ToInt64(textBoxMinPrise.Text);
                    demandSet.MaxPrise = Convert.ToInt64(textBoxMaxPrise.Text);
                    demandSet.MinArea = Convert.ToDouble(textBoxMinS.Text);
                    demandSet.MaxArea = Convert.ToDouble(textBoxMaxS.Text);
                    demandSet.MinFloors = Convert.ToInt32(textBoxMinFloor.Text);
                    demandSet.MaxFloors = Convert.ToInt32(textBoxMaxFloor.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listViewApartment.SelectedItems.Count == 1)
                    {
                        DemandSet demandSet = listViewApartment.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demandSet);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                textBoxMaxFloor.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxS.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinPrise.Text = "";
                }



                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewHouse.SelectedItems.Count == 1)
                    {
                        if (listViewHouse.SelectedItems.Count == 1)
                        {
                            DemandSet demandSet = listViewHouse.SelectedItems[0].Tag as DemandSet;
                            Program.wftDb.DemandSet.Remove(demandSet);
                            Program.wftDb.SaveChanges();
                            ShowDemandSet();
                        }
                    }
                    textBoxMaxFloor.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxRooms.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMaxS.Text = "";
                    textBoxMinS.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMinPrise.Text = "";
                }
                else
                {
                    if (listViewLand.SelectedItems.Count == 1)
                    {
                        if (listViewLand.SelectedItems.Count == 1)
                        {
                            DemandSet demandSet = listViewLand.SelectedItems[0].Tag as DemandSet;
                            Program.wftDb.DemandSet.Remove(demandSet);
                            Program.wftDb.SaveChanges();
                            ShowDemandSet();
                        }
                    }
                    textBoxMaxFloor.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxRooms.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMaxS.Text = "";
                    textBoxMinS.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMinPrise.Text = "";
                }

            }
            catch
            {
                MessageBox.Show("Невозможно удаить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void comboBoxAgent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void ShowAgents()
        {
            comboBoxAgent.Items.Clear();
            foreach (AgentsSet agentsSet in Program.wftDb.AgentsSet)
            {
                string[] item = { agentsSet.Id.ToString() + ".", agentsSet.FirstName, agentsSet.MiddleName, agentsSet.LastName };
                comboBoxAgent.Items.Add(string.Join(" ", item));
            }
        }
        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientsSet clientsSet in Program.wftDb.ClientsSet)
            {
                string[] item = { clientsSet.Id.ToString() + ".", clientsSet.FirstName, clientsSet.MiddleName, clientsSet.LastName };
                comboBoxClient.Items.Add(string.Join(" ", item));

            }
        }
    }
}

    
       

