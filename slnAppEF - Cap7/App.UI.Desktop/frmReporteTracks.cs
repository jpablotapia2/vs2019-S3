using App.Data.DataAccess;
using App.Data.Repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.UI.Desktop
{
    public partial class frmReporteTracks : Form
    {
        public frmReporteTracks()
        {
            InitializeComponent();
            InicializarValores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        # region "Procedimientos Propios"    
        private void Buscar()
        {
            var uw = new AppUnitOfWork();

        
            var listado = uw.TrackRepositorys.ReporteTrack(txtNombre.Text.Trim());
            uw.Dispose();

            gvListadoTracks.DataSource = listado;
            gvListadoTracks.Refresh();
        }
        private void InicializarValores()
        {
            //Obteniendo información de Géneros
            IAppUnitOfWork uw = new AppUnitOfWork(); 

           
            var generoListado = uw.GenreRepositorys.GetAll().ToList();

            generoListado.Insert(0, new Genre()
            {
                GenreId=0,
                Name="Todos"
            });

            cboGenero.DataSource = generoListado;
            cboGenero.Refresh();

            //Obteniendo información de MediaTypes
            
            var generarListadoMedia = uw.MediaTypeRepositorys.GetAll().ToList();

            generarListadoMedia.Insert(0, new MediaType()
            {
                MediaTypeId = 0,
                Name= "Todos"
            });

            uw.Dispose();

            cboMedia.DataSource = generarListadoMedia;
            cboMedia.Refresh();
           


        }
        #endregion



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmConsultaTracks_Load(object sender, EventArgs e)
        {
            
        }
    }
}
