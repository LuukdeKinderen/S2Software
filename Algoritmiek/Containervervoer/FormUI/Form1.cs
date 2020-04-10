using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace FormUI
{
    public partial class Visualiser : Form
    {
        BerendBootje bb = new BerendBootje();
        public Visualiser()
        {
            InitializeComponent();



        }


        private TableLayoutPanel ShipsTable(ReadOnlyCollection<Ship> shipCollection)
        {
            TableLayoutPanel shipsTable = new TableLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Location = new Point(10, 10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
            };
            for (int ship = 0; ship < shipCollection.Count; ship++)
            {
                shipsTable.Controls.Add(new Label() { AutoSize = true, Text = shipCollection[ship].ToString() }, ship, 0);
                int xLength = shipCollection[ship].xLength;
                int yLenght = shipCollection[ship].yLength;
                TableLayoutPanel shipTable = new TableLayoutPanel()
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ColumnCount = xLength,
                    RowCount = yLenght,
                };
                for (int x = 0; x < xLength; x++)
                {
                    for (int y = 0; y < yLenght; y++)
                    {
                        Panel panel = new Panel
                        {
                            Size = new Size(200, 165),
                        };
                        Label label = new Label
                        {
                            Text = shipCollection[ship].GetStack(x, y).ToString(),
                            AutoSize = true,
                        };
                        ListBox listBox = new ListBox
                        {
                            DataSource = shipCollection[ship].GetStack(x, y).Containers,
                            Location = new Point(0, 55),
                            Size = new Size(180, 110),
                            SelectionMode = SelectionMode.None
                        };
                        panel.Controls.Add(label);
                        panel.Controls.Add(listBox);
                        shipTable.Controls.Add(panel, x, y);
                    }
                }
                shipsTable.Controls.Add(shipTable, ship, 1);
            }
            return shipsTable;
        }

        private void SetShipFormat_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            if (!int.TryParse(ShipXLength.Text, out x) || !int.TryParse(ShipYLength.Text, out y))
            {
                MessageBox.Show("Vul een geldig getal in!");
            }
            else if (x < 1 || y < 1)
            {
                MessageBox.Show("Vul een getal boven de nul in");
            }
            else
            {
                bb.SetShipFormat(x, y);
                MessageBox.Show(string.Format("Ship formaat is aangepast: ({0},{1})", x, y));
            }
        }

        private void DistributeContainers_Click(object sender, EventArgs e)
        {
            if (!bb.HasShipFormat)
            {
                MessageBox.Show("Stel eerst een schip formaat in");
            }
            else if (bb.containerCollection.Count == 0)
            {
                MessageBox.Show("Voeg eerst containers toe");
            }
            else
            {

                ScrollPanel.Controls.Clear();
                bb.DistributeContainers();
                ScrollPanel.Controls.Add(ShipsTable(bb.shipCollection));
            }
        }

        private void AddRandom_Click(object sender, EventArgs e)
        {
            int random;
            if (!int.TryParse(RandomInput.Text, out random))
            {
                MessageBox.Show("Vul een geldig getal in!");
            }
            else if (random < 1)
            {
                MessageBox.Show("Vul een getal boven de nul in");
            }
            else
            {
                bb.AddRandomContianers(random);
                UpdateContainerView();
            }
        }
        private void UpdateContainerView()
        {
            ContainersLabel.Text = Sorted.Checked ? bb.containerCollectionSorted.ExtendedToString() : bb.containerCollection.ExtendedToString();
            Containers.DataSource = null;
            Containers.DataSource = Sorted.Checked ? bb.containerCollectionSorted : bb.containerCollection;
        }

        private void Sorted_CheckedChanged(object sender, EventArgs e)
        {
            UpdateContainerView();
        }

        private void AddContianer_Click(object sender, EventArgs e)
        {
            int weight;
            if (!int.TryParse(WeightText.Text, out weight))
            {
                MessageBox.Show("Vul een geldig getal in!");
            }
            else
            {
                bb.AddContainer(Valuable.Checked, Cooled.Checked, weight);
                UpdateContainerView();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            bb.ClearContainers();
            UpdateContainerView();
            ScrollPanel.Controls.Clear();
        }
    }
}
