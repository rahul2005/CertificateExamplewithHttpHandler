using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace UPUniversity
{
    public class StudentLibrary
    {
        private static List<Student> _students = new List<Student>();

        static StudentLibrary()
        {
            _students.Add(new Student { Id = 100, Name = "Subash", Qualification = "B.Tech in Electronics Engineering", Grade = "First Class" });
            _students.Add(new Student { Id = 101, Name = "Prateek", Qualification = "B.Tech in Electrical Engineering", Grade = "First Class with Distinction" });
            _students.Add(new Student { Id = 102, Name = "Raunak", Qualification = "B.Tech in Computer Engineering", Grade = "First Class" });
        }

        private Student GetStudent(string url)
        {
            int id = GetStudentIdFromUrl(url);
            var student = (from s in _students where s.Id == id select s).FirstOrDefault();

            return student;
        }

        private int GetStudentIdFromUrl(string url)
        {
            string str = GetStringBtw(url, "/certificates", ".cert");

            int id=0;
            if (int.TryParse(str, out id))
                return id;
            return id;
        }

        private string GetStringBtw(string data, string startstring, string endstring)
        {
            if (String.IsNullOrEmpty(data) || String.IsNullOrEmpty(startstring) || String.IsNullOrEmpty(endstring))
                return String.Empty;
            if (!data.Contains(startstring) || !data.Contains(endstring))
                return String.Empty;
            int ix_start = data.IndexOf(startstring);
            int ix_end = data.IndexOf(endstring, ix_start + startstring.Length);
            int valueStart = ix_start + startstring.Length;
            string substr = data.Substring(valueStart+1, ix_end - ix_start - startstring.Length-1);
            return substr;
        }

        public Bitmap GetCertificate(string url)


        {
            Student student = GetStudent(url);
            if (student != null)
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(@"C:\Users\rahul.choudhary\Downloads\Grade19.bmp", true);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawString(student.Name, new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new PointF(173, 102));
                graphics.DrawString(student.Qualification, new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new PointF(130, 130));
                graphics.DrawString(student.Grade, new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new PointF(85, 160));
                return bitmap;
            }
            
            return null;
        }
    }
}