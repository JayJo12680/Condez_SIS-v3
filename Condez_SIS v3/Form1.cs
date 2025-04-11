using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Condez_SIS_v3.Form1;
using System.IO;

namespace Condez_SIS_v3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte[] ImageToByteArray(PictureBox pictureBox1)
        {
            if (pictureBox1.Image == null)
                return Array.Empty<byte>();

            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                return ms.ToArray();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new SchoolContext())
            {
                var studentsList = context.Students.ToList();

                dataGridView1.Rows.Clear(); // Clear existing rows if any

                foreach (var student in studentsList)
                {
                    dataGridView1.Rows.Add(
                        student.StudentNo,
                        student.Name,
                        student.Year_Major,
                        student.Course,
                        student.Birthday.ToShortDateString(),
                        student.ContactNumber,
                        student.Address,
                        student.ContactPerson,
                        student.ContactPersonAddress,
                        student.ContactPersonNumber
                    );
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select Student Photo";
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) //insert
        {
            using (var context = new SchoolContext())
            {
                var students = new Students
                {
                    Name = textBox2.Text,
                    Year_Major = textBox3.Text,
                    Course = comboBox1.Text,
                    Birthday = dateTimePicker1.Value.Date,
                    ContactNumber = textBox4.Text,
                    Address = textBox5.Text,
                    ContactPerson = textBox6.Text,
                    ContactPersonNumber = textBox8.Text,
                    ContactPersonAddress = textBox7.Text,

                };
                if (pictureBox1.Image != null)
                {
                    students.StudentProfile = ImageToByteArray(pictureBox1);
                }
                else
                {
                    students.StudentProfile = null;
                }
                context.Students.Add(students);
                context.SaveChanges();
                MessageBox.Show("Student record saved successfully!");


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}