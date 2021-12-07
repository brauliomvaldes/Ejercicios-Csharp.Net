using ChatDesktop.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityChat;
using UtilityChat.Models.WS;

namespace ChatDesktop
{
    public partial class FrmMain : Form
    {
        
        Panel lastPanel = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void iniciarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            SessionStart();
        }

        private void iniciarSessionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SessionStart();
        }

        private void cerrarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Business.Session.oUserResponse = null;
            iniciarSessionToolStripMenuItem1.Enabled = true;
            cerrarSessionToolStripMenuItem.Enabled = false;
            splitContainer1.Panel1.Enabled = false;
            splitContainer1.Panel2.Enabled = false;
        }

        #region HELPER

        private void GetDataInit()
        {
            List<ListRoomsResponse> lst = new List<ListRoomsResponse>();

            SecurityRequest oSecurityRequest = new SecurityRequest();
            oSecurityRequest.AccessToken = Session.oUserResponse.AccessToker;


            UtilityChat.RequestUtil oRequestUtil = new UtilityChat.RequestUtil();
            Reply oReply =
                oRequestUtil.Execute<SecurityRequest>(Constants.Url.ROOMS, "post", oSecurityRequest);

            // la deserializacion necesita un string y oReplay.data viene como objeto anónimo desde
            // la BD por lo que
            // hay que serializar primero para pasar a string

            lst = JsonConvert.DeserializeObject<List<ListRoomsResponse>>(JsonConvert.SerializeObject(oReply.data));

            cmbSalas.DataSource = lst;
            cmbSalas.DisplayMember = "Name";
            cmbSalas.ValueMember = "Id";

            // obtenemos los mensajes
            GetMessages();
        }

        private void SessionStart()
        {

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

            if (Business.Session.oUserResponse != null)
            {
                iniciarSessionToolStripMenuItem1.Enabled = false;
                cerrarSessionToolStripMenuItem.Enabled = true;
                splitContainer1.Panel1.Enabled = true;
                splitContainer1.Panel2.Enabled = true;
                GetDataInit();
            }
        }



        private void GetMessages()
        {
            int idRoom = 0;
            lastPanel = null;
            panelMessages.Controls.Clear();

            try
            {
                idRoom = (int)cmbSalas.SelectedValue;
            }
            catch
            {

            }

            if(idRoom > 0)
            {
                List<MessagesResponse> lst = new List<MessagesResponse>();

                MessagesRequest oMessagesRequest = new MessagesRequest();

                oMessagesRequest.AccessToken = Business.Session.oUserResponse.AccessToker;
                oMessagesRequest.IdRoom = idRoom;

                RequestUtil oRequestUtil = new RequestUtil();

                Reply oReply = oRequestUtil.Execute<MessagesRequest>(Constants.Url.MESSAGES, "post", oMessagesRequest);

                lst = JsonConvert.DeserializeObject<List<MessagesResponse>>(JsonConvert.SerializeObject(oReply.data));

                lst = lst.OrderBy(d => d.DateCreated).ToList();

                foreach (MessagesResponse oMessage in lst)
                {
                    AddMessages(oMessage);
                }
            }


        }

        private void AddMessages(MessagesResponse oMessage)
        {
            Panel oPanel = new Panel();
            oPanel.Width = panelMessages.Width-30;
            oPanel.Height = 70;
            oPanel.BackColor = Color.FloralWhite;

            // ubicar el panel por cada mensaje
            if (lastPanel == null)
                oPanel.Location = new Point(10, 10);
            else
                oPanel.Location = new Point(10, lastPanel.Location.Y + lastPanel.Height + 10);
            lastPanel = oPanel;
            
            panelMessages.Controls.Add(oPanel);
            panelMessages.ScrollControlIntoView(oPanel);

            // agregamos el texto del mensaje

            TextBox txtMessage = new TextBox();
            txtMessage.Text = oMessage.Message;
            txtMessage.Location = new Point(10, 10);
            txtMessage.Width = oPanel.Width - 20;
            txtMessage.ReadOnly = true;
            txtMessage.BorderStyle = BorderStyle.None;
            

            oPanel.Controls.Add(txtMessage);


        }


        #endregion

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMessages();

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
