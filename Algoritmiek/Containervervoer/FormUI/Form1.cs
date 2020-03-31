using System;
using System.Collections.Generic;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BerendBootje bb = new BerendBootje();

            bb.DistribureContainers();
            ScrollPanel.Controls.Add(ShipsTable(bb.shipCollection));

            

        }

        private TableLayoutPanel ShipsTable(List<Ship> shipCollection)
        {
            TableLayoutPanel shipsTable = new TableLayoutPanel()
            {
                AutoSize = true,
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
                    Location = new Point(0, 0),
                    ColumnCount = xLength,
                    RowCount = yLenght,
                };
                for (int x = 0; x < xLength; x++)
                {
                    for (int y = 0; y < yLenght; y++)
                    {
                        Panel panel = new Panel
                        {
                            AutoSize = true,
                        };
                        Label label = new Label
                        {
                            Text = shipCollection[ship].GetStack(x, y).ToString(),
                            AutoSize = true,
                        };
                        ListBox listBox = new ListBox
                        {
                            DataSource = shipCollection[ship].GetStack(x, y).Containers,
                            Location = new Point(0,15),
                            Size = new Size(175, 5),
                            AutoSize = true,
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



    }
}
