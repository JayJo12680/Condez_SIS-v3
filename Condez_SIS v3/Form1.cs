using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Condez_SIS_v3.Form1;

namespace Condez_SIS_v3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class SchoolContext : DbContext
        {
            public DbSet<Students> Students { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-G6J8QFP\SQLEXPRESS01;Database=DaveDB;Trusted_Connection=True;TrustServerCertificate=True;");

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Students>().ToTable("DaveSTS");
            }

        }

        public class Students
        {
            [Key]
            public int StudentNo { get; set; }
            public string Name { get; set; }
            public string Year_Major { get; set; }
            public string Course { get; set; }
            public DateTime Birthday { get; set; }
            public string ContactNumber { get; set; }
            public string Address { get; set; }
            public string ContactPerson { get; set; }
            public string ContactPersonAddress { get; set; }
            public string ContactPersonNumber { get; set; }
            public byte[] StudentProfile { get; set; }
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

        private void button1_Click(object sender, EventArgs e)
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
                if(pictureBox1.Image != null)
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
    }
}