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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Los dos campos son obligatorios");
                return;
            }

            AccessRequest oAR = new AccessRequest();
            oAR.Email = txtUsuario.Text.Trim();
            oAR.Password = UtilityChat.Tools.Encrypt.GetSHA256(txtPassword.Text.Trim());

            RequestUtil oRequestUtil = new RequestUtil();
            Reply oReply =
                oRequestUtil.Execute<AccessRequest>(Constants.Url.ACCESS, "post", oAR);

            if (oReply.result == 1)
            {
                // la deserializacion necesita un string y oReplay.data viene como objeto anónimo desde
                // la BD por lo que
                // hay que serializar primero para pasar a string
                Business.Session.oUserResponse = JsonConvert.DeserializeObject<UserResponse>(
                    JsonConvert.SerializeObject(oReply.data)
                    );
                this.Close();
            }
            else
            {
                MessageBox.Show(oReply.message);
            }
        }
    }
}
