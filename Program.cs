using System.Collections.Generic;
using System;
using MigraDoc.Rendering;
using System.Diagnostics;

namespace TestPDF
{
    class Program
    {
        private static List<User> users = new List<User>(){
            new User{Name = "Administrator", FirstName = "Administrator", LastName = "Administratorowie", Password = "pass", Role = Role.Administrator, Theme = true, Off = false },
            new User{Name = "Dyrektor", FirstName = "Andrzej", LastName = "Kowalski", Password = "pass", Role = Role.Dyrektor, Theme = true, Off = false },
            new User{Name = "GB", FirstName = "Grzegorz", LastName = "Brzęczyszczykiewicz", Password = "pass", Role = Role.Pracownik, Theme = true, Off = false },
            new User{Name = "KG", FirstName = "Karol", LastName = "Gągorzelewski", Password = "pass", Role = Role.Wolontariusz, Theme = true, Off = false }
        };

        private static List<News> newses = new List<News>(){
            new News{ID = 1, Name = "Wydarzenie 1", Date = DateTime.Now, Information = "I1",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 2, Name = "Wydarzenie 2", Date = DateTime.Now, Information = "I2",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 3, Name = "Wydarzenie 3", Date = DateTime.Now, Information = "I3",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 4, Name = "Wydarzenie 4", Date = DateTime.Now, Information = "I4",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[3]},
            new News{ID = 5, Name = "Wydarzenie 5", Date = DateTime.Now, Information = "I5",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[3]},
            new News{ID = 6, Name = "Wydarzenie 6", Date = DateTime.Now, Information = "I6",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[3]},
            new News{ID = 7, Name = "Wydarzenie 7", Date = DateTime.Now, Information = "I7",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[3]},
            new News{ID = 8, Name = "Wydarzenie 8", Date = DateTime.Now, Information = "I8",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[3]},
            new News{ID = 9, Name = "Wydarzenie 9", Date = DateTime.Now, Information = "I9",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 10, Name = "Wydarzenie 10", Date = DateTime.Now, Information = "I10",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 11, Name = "Wydarzenie 11", Date = DateTime.Now, Information = "I11",Contact = "Test contact...", Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 12, Name = "Wydarzenie 12", Date = DateTime.Now, Information = "I12",Contact = "Test contact...", Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 13, Name = "Wydarzenie 13", Date = DateTime.Now, Information = "I13",Contact = "Test contact...", Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 14, Name = "Wydarzenie 14", Date = DateTime.Now, Information = "I14",Contact = "Test contact...", Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 15, Name = "Wydarzenie 15", Date = DateTime.Now, Information = "I15",Contact = "Test contact...", Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 16, Name = "Wydarzenie 16", Date = DateTime.Now, Information = "I16",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 17, Name = "Wydarzenie 17", Date = DateTime.Now, Information = "I17",Contact = null, Notes = null, Realization = true, Enrollment = false, RealizationUser = users[1], EnrolmentUser = null, Creator = users[0]},
            new News{ID = 18, Name = "Wydarzenie 18", Date = DateTime.Now, Information = "I18",Contact = null, Notes = null, Realization = true, Enrollment = false, RealizationUser = users[1], EnrolmentUser = null, Creator = users[0]},
            new News{ID = 19, Name = "Wydarzenie 19", Date = DateTime.Now, Information = "I19",Contact = null, Notes = null, Realization = true, Enrollment = false, RealizationUser = users[1], EnrolmentUser = null, Creator = users[0]},
            new News{ID = 20, Name = "Wydarzenie 20", Date = DateTime.Now, Information = "I20",Contact = null, Notes = null, Realization = true, Enrollment = false, RealizationUser = users[1], EnrolmentUser = null, Creator = users[0]},
            new News{ID = 21, Name = "Wydarzenie 21", Date = DateTime.Now, Information = "I21",Contact = null, Notes = null, Realization = true, Enrollment = false, RealizationUser = users[1], EnrolmentUser = null, Creator = users[0]},
            new News{ID = 22, Name = "Wydarzenie 22", Date = DateTime.Now, Information = "I22",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 23, Name = "Wydarzenie 23", Date = DateTime.Now, Information = "I23",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 24, Name = "Wydarzenie 24", Date = DateTime.Now, Information = "I24",Contact = null, Notes = "Test notes...", Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 25, Name = "Wydarzenie 25", Date = DateTime.Now, Information = "I25",Contact = null, Notes = "Test notes...", Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 26, Name = "Wydarzenie 26", Date = DateTime.Now, Information = "I26",Contact = null, Notes = "Test notes...", Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 27, Name = "Wydarzenie 27", Date = DateTime.Now, Information = "I27",Contact = null, Notes = "Test notes...", Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 28, Name = "Wydarzenie 28", Date = DateTime.Now, Information = "I28",Contact = null, Notes = "Test notes...", Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 29, Name = "Wydarzenie 29", Date = DateTime.Now, Information = "I29",Contact = null, Notes = "Test notes...", Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 30, Name = "Wydarzenie 30", Date = DateTime.Now, Information = "I30",Contact = null, Notes = null, Realization = false, Enrollment = false, RealizationUser = null, EnrolmentUser = null, Creator = users[0]},
            new News{ID = 31, Name = "Wydarzenie 31", Date = DateTime.Now, Information = "I31",Contact = null, Notes = null, Realization = false, Enrollment = true, RealizationUser = null, EnrolmentUser = users[2], Creator = users[0]},
            new News{ID = 32, Name = "Wydarzenie 32", Date = DateTime.Now, Information = "I32",Contact = null, Notes = null, Realization = false, Enrollment = true, RealizationUser = null, EnrolmentUser = users[2], Creator = users[0]},
            new News{ID = 33, Name = "Wydarzenie 33", Date = DateTime.Now, Information = "I33",Contact = null, Notes = null, Realization = false, Enrollment = true, RealizationUser = null, EnrolmentUser = users[2], Creator = users[0]},
            new News{ID = 34, Name = "Wydarzenie 34", Date = DateTime.Now, Information = "I34",Contact = null, Notes = null, Realization = false, Enrollment = true, RealizationUser = null, EnrolmentUser = users[2], Creator = users[0]},
            new News{ID = 35, Name = "Wydarzenie 35", Date = DateTime.Now, Information = "I35",Contact = null, Notes = null, Realization = false, Enrollment = true, RealizationUser = null, EnrolmentUser = users[2], Creator = users[0]}
        };

        static void Main(string[] args)
        {
            MakePdf document = new MakePdf();
            MigraDoc.DocumentObjectModel.Document pdf = document.CrateDocument();
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(pdf, "Raport.mdddl");
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = pdf;
            renderer.RenderDocument();
            string fname = "Raport.pdf";
            renderer.PdfDocument.Save(fname);
            Process.Start(fname);
        }        
    }
}
