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
            _mode = NodeMode.Transporter;

            EditorModeCB.Items.AddRange(Enum.GetNames(typeof(EditorMode)));
            EditorModeCB.SelectedIndex = 0;
            canvas.MouseWheel += canvas_MouseWheel;

            canvas.Invalidate();
        }

        // Change radius of the node signal
        void canvas_MouseWheel(object sender, MouseEventArgs e)
        {            
            foreach (Node node in nodeList)
            {
                node.IsSelected = false;
                float dx = node.posX - e.X;
                float dy = node.posY - e.Y;
                if (dx * dx + dy * dy <= node.rNode * node.rNode)
                {
                    node.IsSelected = true;
                    node.rSignal += e.Delta/128;
                    break;
                }

            }
            canvas.Invalidate();
        }

        #region enums

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

        #endregion
        #region vars

        NodeMode _mode;
        List<Node> nodeList = new List<Node> ();
        EditorMode _editorMode;
        Node selectedNode;
        #endregion

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
            selectedNode = null;
            foreach (Node node in nodeList)
            {
                node.IsSelected = false;
                float dx = node.posX - e.X;
                float dy = node.posY - e.Y;
                if (dx * dx + dy * dy <= node.rNode * node.rNode)
                {
                    selectedNode = node;
                    node.IsSelected = true;
                    break;
                }

            }
            canvas.Invalidate();
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
            canvas.Focus();
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (selectedNode == null)
                e.Cancel = true;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripMenuItem).Name;

            switch (item)
            {
                case "senderMode": break;
                case "TransporterMode": break;
                case "ReceiverMode": break;
                case "EditName":
                    var name = Microsoft.VisualBasic.Interaction.InputBox("Введите название для нода", "Наименование нода", "", this.Width / 2, this.Height / 2);
                    if (name == null)
                        return;

                    selectedNode.SetName(name);
                    canvas.Invalidate();
                    break;
                case "EditDesc":
                    var desc = Microsoft.VisualBasic.Interaction.InputBox("Введите описание для нода", "Описание нода", "", this.Width / 2, this.Height / 2);
                    if (desc == null)
                        return;

                    selectedNode.SetDescription(desc);
                    break;
                case "EditLoc": 
                    var location = Microsoft.VisualBasic.Interaction.InputBox("Введите расположение нода", "Расположение нода", "", this.Width/2, this.Height/2);
                    if (location == null)
                        return;

                    selectedNode.SetLocation(location);
                    break;
            }
        }                
    }
}
