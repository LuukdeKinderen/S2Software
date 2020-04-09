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
    public partial class Visualiser : Form
    {
        BerendBootje bb = new BerendBootje(5,8);
        public Visualiser()
        {
            InitializeComponent();

            bb.AddRandomContianers(750);
            bb.DistribureContainers();
            ScrollPanel.Controls.Add(ShipsTable(bb.shipCollection));
        }

        private TableLayoutPanel ShipsTable(List<Ship> shipCollection)
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
                        Panel lbPanel = new Panel
                        {
                            Location = new Point(0, 55),
                            Size = new Size(205, 110),
                            AutoScroll = true,
                        };
                        ListBox listBox = new ListBox
                        {
                            DataSource = shipCollection[ship].GetStack(x, y).Containers,
                            AutoSize = true,
                            Size = new Size(180, 5),
                            SelectionMode = SelectionMode.None
                        };
                        panel.Controls.Add(label);
                        lbPanel.Controls.Add(listBox);
                        panel.Controls.Add(lbPanel);
                        shipTable.Controls.Add(panel, x, y);
                    }
                }
                shipsTable.Controls.Add(shipTable, ship, 1);
            }

            shipsTable.Controls.Add(
                new Label
                {
                    Text = "All containers \n" + bb.containerCollectionSorted.ExtendedToString(),
                    AutoSize = true,
                },
                shipCollection.Count,
                0
            );
            shipsTable.Controls.Add(
                new ListBox
                {
                    DataSource = bb.containerCollection,
                    AutoSize = true,
                    SelectionMode = SelectionMode.None
                },
                shipCollection.Count,
                1
            );
            
            shipsTable.Controls.Add(
                new Label
                {
                    Text = "All containers Sorted \n" + bb.containerCollectionSorted.ExtendedToString(),
                    AutoSize = true,
                },
                shipCollection.Count+1,
                0
            );
            shipsTable.Controls.Add(
                new ListBox
                {
                    DataSource = bb.containerCollectionSorted,
                    AutoSize = true,
                    SelectionMode = SelectionMode.None
                },
                shipCollection.Count+1,
                1
            );


            return shipsTable;
        }



    }
}
