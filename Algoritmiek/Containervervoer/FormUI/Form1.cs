using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            TableLayoutPanel tlp = new TableLayoutPanel()
            {
                AutoSize = true,
                Location = new Point(0, 0),
            };

            this.Controls.Add(ShipsDislplay(bb.ShipStringList()));



        }

       
        private TableLayoutPanel ShipsDislplay(List<List<string>[,]> ships)
        {
            TableLayoutPanel tlp = new TableLayoutPanel()
            {
                AutoSize = true,
                Location = new Point(10, 10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
            };
            for (int s = 0; s < ships.Count; s++)
            {
                tlp.Controls.Add(new Label() { Text = string.Format("Ship: {0}", s) }, s, 0);
                tlp.Controls.Add(ShipDislplay(ships[s]), s, 1);
            }
            

            return tlp;
        }

        private TableLayoutPanel ShipDislplay(List<string>[,] ship)
        {
            int cc = ship.GetLength(0);
            int rc = ship.GetLength(1);
            TableLayoutPanel tlp = new TableLayoutPanel()
            {
                AutoSize = true,
                Location = new Point(0, 0),
                ColumnCount = cc,
                RowCount = rc
            };
            for (int c = 0; c < cc; c++)
            {
                for (int r = 0; r < rc; r++)
                {
                    tlp.Controls.Add(new ListBox { DataSource = ship[c, r], Anchor = AnchorStyles.Left, AutoSize = true }, c, r);
                }
            }

            return tlp;
        }

    }
}
