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


        private List<TabPage> ShipsTable(ReadOnlyCollection<Ship> shipCollection)
        {
            List<TabPage> tabs = new List<TabPage>();
            for (int ship = 0; ship < shipCollection.Count; ship++)
            {
                Panel scrollpanel = new Panel()
                {
                    AutoScroll = true,
                    Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left),
                };
                scrollpanel.Controls.Add(new Label() { AutoSize = true, Text = shipCollection[ship].ToString() });
                TableLayoutPanel shipTable = new TableLayoutPanel()
                {
                    Location = new Point(0,70),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ColumnCount = shipCollection[ship].yLength,
                    RowCount = shipCollection[ship].xLength,
                };
                foreach (ShipRow row in shipCollection[ship].ShipRows)
                {
                    foreach (Stack stack in row.Stacks)
                    {
                        Panel panel = new Panel
                        {
                            Size = new Size(200, 145),
                        };
                        Label label = new Label
                        {
                            Text = stack.ToString(),
                            AutoSize = true,
                        };
                        ListBox listBox = new ListBox
                        {
                            DataSource = stack.Containers,
                            Location = new Point(0, 45),
                            Size = new Size(190, 100),
                            SelectionMode = SelectionMode.None
                        };
                        panel.Controls.Add(label);
                        panel.Controls.Add(listBox);
                        shipTable.Controls.Add(panel);
                    }
                }
                scrollpanel.Controls.Add(shipTable);
                TabPage tab = new TabPage("ship " + (ship + 1));
                tab.Controls.Add(scrollpanel);
                tabs.Add(tab);
            }
            return tabs;
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
                //MessageBox.Show(string.Format("Ship formaat is aangepast: ({0},{1})", x, y));
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

                tabControl1.Controls.Clear();
                bb.DistributeContainers();
                foreach (TabPage table in ShipsTable(bb.shipCollection))
                {
                    tabControl1.Controls.Add(table);
                }
                if (bb.containersFailedToDistribute.Count > 0)
                {
                    TabPage tab = new TabPage("failed Containers");
                    ListBox listBox = new ListBox()
                    {
                        DataSource = bb.containersFailedToDistribute,
                        Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left)
                    };
                    tab.Controls.Add(listBox);
                    tabControl1.Controls.Add(tab);
                }
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
            tabControl1.Controls.Clear();
            bb.ClearContainers();
            UpdateContainerView();
        }
    }
}
