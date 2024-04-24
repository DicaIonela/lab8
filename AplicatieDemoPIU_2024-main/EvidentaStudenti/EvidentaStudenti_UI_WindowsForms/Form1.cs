using System;
using LibrarieModele;
using NivelStocareDate;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvidentaStudenti_UI_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareStudenti_FisierText adminStudenti;

        private Label lblNume;
        private Label lblPrenume;
        private Label lblNote;

        //private TextBox txtID;
        //private TextBox txtNume;
        //private TextBox txtPrenume;
        private Label[] lblsID;
        private Label[] lblsNume;
        private Label[] lblsPrenume;
        private Label[] lblsNote;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        public Form1()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminStudenti = new AdministrareStudenti_FisierText(caleCompletaFisier);
            int nrStudenti = 0;

            Student[] studenti = adminStudenti.GetStudenti(out nrStudenti);

            //setare proprietati
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Informatii studenti";
            this.StartPosition = FormStartPosition.CenterScreen;

            //adaugare control de tip Label pentru 'Nume';
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.DarkGreen;
            //this.Controls.Add(lblNume);

            //adaugare control de tip Label pentru 'Prenume';
            lblPrenume = new Label();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Text = "Prenume";
            lblPrenume.Left = 2 * DIMENSIUNE_PAS_X;
            lblPrenume.ForeColor = Color.DarkGreen;
            //this.Controls.Add(lblPrenume);

            //adaugare control de tip Label pentru 'Note';
            lblNote = new Label();
            lblNote.Width = LATIME_CONTROL;
            lblNote.Text = "Note";
            lblNote.Left = 3 * DIMENSIUNE_PAS_X;
            lblNote.ForeColor = Color.DarkGreen;
            //this.Controls.Add(lblNote);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaStudenti();
        }

        private void AfiseazaStudenti()
        {
            Student[] studenti = adminStudenti.GetStudenti(out int nrStudenti);

            lblsNume = new Label[nrStudenti];
            lblsPrenume = new Label[nrStudenti];
            lblsNote = new Label[nrStudenti];

            int i = 0;
            foreach (Student student in studenti)
            {
                /*//adaugare control de tip Label pentru numele studentilor;
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = student.Nume;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru prenumele studentilor
                lblsPrenume[i] = new Label();
                lblsPrenume[i].Width = LATIME_CONTROL;
                lblsPrenume[i].Text = student.Prenume;
                lblsPrenume[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsPrenume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPrenume[i]);

                //adaugare control de tip Label pentru notele studentilor
                lblsNote[i] = new Label();
                lblsNote[i].Width = LATIME_CONTROL;
                lblsNote[i].Text = string.Join(" ", student.GetNote());
                lblsNote[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsNote[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNote[i]);
                i++;*/
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            int ID= int.Parse(txtID.Text);
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            string note= txtNotes.Text;
            Student S = new Student(ID, nume, prenume);
            Student[] studenti = adminStudenti.GetStudenti(out int nrStudenti);
            S.SetNote(note);

            foreach (Student student in studenti) 
            {
                if (S.IdStudent==student.IdStudent&&S.Nume==student.Nume&&S.Prenume==student.Prenume)
                    MessageBox.Show("Studentul e deja pe lista.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                     adminStudenti.AddStudent(S);
            }   
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student[] studenti= adminStudenti.GetStudenti(out int nrStudenti);

            Label[,] lblsStudenti = new Label[studenti.Length, 4]; // Tablou bidimensional pentru toate label-urile

            int i = 0;
            foreach (Student student in studenti)
            {
                for (int j = 0; j < 4; j++) // Iteram pentru fiecare coloana (Nr, Nume, Adresa)
                {
                    lblsStudenti[i, j] = new Label();
                    lblsStudenti[i, j].Width = LATIME_CONTROL;
                    lblsStudenti[i, j].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsStudenti[i, j]);
                }

                lblsStudenti[i, 0].Text = student.IdStudent.ToString(); 
                lblsStudenti[i, 0].Left = 0;

                lblsStudenti[i, 1].Text = student.Nume; 
                lblsStudenti[i, 1].Left = DIMENSIUNE_PAS_X+15;

                lblsStudenti[i, 2].Text = student.Prenume; 
                lblsStudenti[i, 2].Left = 2 * DIMENSIUNE_PAS_X+70;

                lblsStudenti[i, 3].Text = student.GetStringNote();
                lblsStudenti[i, 3].Left = 3 * DIMENSIUNE_PAS_X+150;

                i++;
            }
            txtID.Text = "";
            txtNume.Text= "";
            txtPrenume.Text = "";
            txtNotes.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Width += 2 * LATIME_CONTROL;
            button2.Height += 10;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Width -= 2*LATIME_CONTROL;
            button2.Height -= 10;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            txtID.BackColor = Color.Red; 
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            txtID.BackColor = Color.White;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
