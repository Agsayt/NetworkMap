using NetworkMap.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _editorMode = EditorMode.Create;
            _mode = NodeMode.Sender;

            EditorModeCB.Items.AddRange(Enum.GetNames(typeof(EditorMode)));
            EditorModeCB.SelectedIndex = 0;

            canvas.Invalidate();
        }

       

        public enum EditorMode
        {
            Create,
            Select,
            Edit    
        }

        public enum NodeMode
        {
            Sender,
            Transporter,
            Receiver      
        }

        private NodeMode _mode;
        List<Node> nodeList = new List<Node> ();
        private EditorMode _editorMode;        

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            
            foreach (var node in nodeList)
            {
                node.Draw (e.Graphics);
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach (var node in nodeList)
                {
                    if (node.IsSelected)
                    {
                        node.ChangePosition (e.X, e.Y);
                        canvas.Invalidate();
                    }
                }
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (_editorMode == EditorMode.Create)
            {
                Node node = new Node (e.X, e.Y, 100, _mode);
                nodeList.Add (node);
                canvas.Invalidate ();    
            }                                                         
            
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Node node in nodeList)
            {
                node.IsSelected = false;
                float dx = node.posX - e.X;
                float dy = node.posY - e.Y;
                if (dx * dx + dy * dy <= node.rNode * node.rNode)
                {
                    node.IsSelected = true;
                    canvas.Invalidate ();
                    break;
                }

            }

        }

        private void EditorModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ToolStripComboBox;

            if (combo == null)
                return;

            EditorMode mode;

            var selectedItem = combo.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Create": mode = EditorMode.Create; break;
                case "Select": mode = EditorMode.Select; break;
                case "Edit": mode = EditorMode.Edit; break;
                default: return;
            }

            _editorMode = mode;
        }
    }
}
