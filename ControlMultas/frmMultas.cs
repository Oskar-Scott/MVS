namespace ControlMultas
{
    public partial class frmMultas : Form
    {
        ListViewItem item;
        public frmMultas()
        {
            InitializeComponent();
        }

        private void frmMultas_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Today.ToShortDateString();
            lblHoraActual.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos
            string placa = txtNumeroPlaca.Text;
            double velocidad = double.Parse(txtVelocidad.Text);
            DateTime fecha = DateTime.Parse(lblFechaActual.Text);
            DateTime hora = DateTime.Parse(lblHoraActual.Text);

            //Procesando
            double multa = 0;
            if (velocidad <= 70)
                multa = 0;
            else if (velocidad > 70 && velocidad <= 90)
                multa = 120;
            else if (velocidad > 90 && velocidad <= 100)
                multa = 240;
            else if (velocidad > 100)
                multa = 350;

            //Imprimir los resultados
            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(lblFechaActual.Text);
            fila.SubItems.Add(lblHoraActual.Text);
            fila.SubItems.Add(velocidad.ToString("C"));
            fila.SubItems.Add(multa.ToString("C"));
            lvMultas.Items.Add(fila);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas seguro que quieres salir de la app?", "Control de multas de transito", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if( r == DialogResult.Yes )
                this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                lvMultas.Items.Remove(item);
                MessageBox.Show("Multa eliminada");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una multa de la lista");
            }
        }

        private void lvMultas_MouseClick(object sender, MouseEventArgs e)
        {
            item = lvMultas.GetItemAt(e.X, e.Y);
        }
    }
}