using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class GenresForm : Form
    {
        public GenresForm()
        {
            InitializeComponent();
        }

        GENRE genre = new GENRE();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (name.Trim().Equals(""))
            {
                MessageBox.Show("New Genre Aded Succesfully!",
                    "New Genre",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                dgGenres.DataSource = genre.GenreList();
            }
            else 
            {
                MessageBox.Show("Genre Not Added!!",
                    "Add Error",
                    
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
