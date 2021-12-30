using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace TestPDF{
public class MakePdf{

        public MigraDoc.DocumentObjectModel.Document CrateDocument(){

            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
            document.Info.Title = "Raport";
            document.Info.Subject = "Raport nadchodzących wydarzeń.";
            document.Info.Author = "Newsroom";

            DefineStyles(document);
            CreatePage(document);
            FillContent(document);
            return document;
        }

        public void DefineStyles(MigraDoc.DocumentObjectModel.Document document){
            Style style = document.Styles["Normal"];
            style.Font.Name = "Verdana";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Center);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Right);

            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Times New Roman";
            style.Font.Size = 12;
        }

        public void CreatePage(MigraDoc.DocumentObjectModel.Document document){
            Section section = document.AddSection();
            // PageSetup pageSetup = document.DefaultPageSetup.Clone();
            // pageSetup.Orientation = Orientation.Landscape; //TODO: Change Orientation

            //FOOTER
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("© Archidiecezjalna Rozgłośnia Radiowa Radio \"FARA\" - Newsroom");
            //paragraph.Style = ?? //TODO: Paragraph from styles
            paragraph.Format.Font.Size = 8;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            //Date Time
            paragraph = section.AddParagraph();
            paragraph.AddText("Raport z ");
            paragraph.AddDateField("yyyy.MM.dd");
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            paragraph.Format.Font.Size = 8;
            paragraph.Format.SpaceAfter = "1.2cm";

            //Create Table
            var table = section.AddTable();
            table.Style = "Table";
            table.Borders.Width = 0.5;
            table.Rows.LeftIndent = 0;

            #region Columns
            //Name
            Column column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Place
            column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Date
            column = table.AddColumn("2.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Information
            column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Notes
            column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Contact
            column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //RealizationUser
            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //EnrolmentUser
            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Creator
            column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            #endregion

            #region Rows
            //Header
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Format.Font.Color = Color.FromRgb(97,189,0);
            row.Shading.Color = Color.FromRgb(0,81,110);
            
            row.Cells[0].AddParagraph("Nazwa");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;

            row.Cells[1].AddParagraph("Miejsce");
            row.Cells[1].Format.Font.Bold = true;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            //Date
            row.Cells[2].AddParagraph("Data");
            row.Cells[2].Format.Font.Bold = true;
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            //Information
            row.Cells[3].AddParagraph("Informacje");
            row.Cells[3].Format.Font.Bold = true;
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            //Notes
            row.Cells[4].AddParagraph("Notatki");
            row.Cells[4].Format.Font.Bold = true;
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            //Contact
            row.Cells[5].AddParagraph("Kontakt");
            row.Cells[5].Format.Font.Bold = true;
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            //RealizationUser
            row.Cells[6].AddParagraph("Realizacja");
            row.Cells[6].Format.Font.Bold = true;
            row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
            //EnrolmentUser
            row.Cells[7].AddParagraph("Wpis");
            row.Cells[7].Format.Font.Bold = true;
            row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
            //Creator
            row.Cells[8].AddParagraph("Autor");
            row.Cells[8].Format.Font.Bold = true;
            row.Cells[8].Format.Alignment = ParagraphAlignment.Left;
            #endregion

            ///<href>http://pdfsharp.net/wiki/Invoice-sample.ashx</href>
        }
        public void FillContent(MigraDoc.DocumentObjectModel.Document document){
            
        }

}
}