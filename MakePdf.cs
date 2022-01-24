using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System.Collections.Generic;

namespace TestPDF{
public class MakePdf : INewsObjects{
        public MigraDoc.DocumentObjectModel.Document CrateDocument(List<News> lista){

            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
            document.Info.Title = "Raport";
            document.Info.Subject = "Raport nadchodzących wydarzeń.";
            document.Info.Author = "Newsroom";

            DefineStyles(document);
            CreatePage(document, lista);
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
            style.Font.Size = 10;

            style = document.Styles.AddStyle("MyFooter", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Right;
            style.ParagraphFormat.Font.Size = 5;
            style.ParagraphFormat.Font.Name = "Arial";
            style.ParagraphFormat.Font.Color = Color.FromRgb(59, 59, 59);
        }

        public void CreatePage(MigraDoc.DocumentObjectModel.Document document, List<News> lista){
            document.DefaultPageSetup.Orientation = Orientation.Landscape;
            Section section = document.AddSection();

            //FOOTER
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("© Archidiecezjalna Rozgłośnia Radiowa Radio \"FARA\" - Newsroom");
            paragraph.Style = "MyFooter";

            //Header
            paragraph = section.Headers.Primary.AddParagraph();
            paragraph.AddPageField();

            //Date Time
            paragraph = section.AddParagraph();
            paragraph.AddText("Raport z ");
            paragraph.AddDateField("yyyy.MM.dd");
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            paragraph.Format.Font.Size = 8;
            paragraph.Format.SpaceAfter = "1.2cm";
            paragraph.Format.Font.Color = Color.FromRgb(59, 59, 59);

            //Create Table
            var table = section.AddTable();
            table.Style = "Table";
            table.Borders.Width = 0.5;
            table.Rows.LeftIndent = 0;


            #region Columns
            //Name
            Column column = table.AddColumn("3.8cm");
            column.Format.Alignment = ParagraphAlignment.Center;
            //Place
            column = table.AddColumn("3.8cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Date
            column = table.AddColumn("1.8cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Information
            column = table.AddColumn("5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Notes
            column = table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Contact
            column = table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //RealizationUser
            column = table.AddColumn("1.8cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //EnrolmentUser
            column = table.AddColumn("1.8cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            //Creator
            column = table.AddColumn("1.8cm");
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
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            row.Cells[1].AddParagraph("Miejsce");
            row.Cells[1].Format.Font.Bold = true;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            //Date
            row.Cells[2].AddParagraph("Data");
            row.Cells[2].Format.Font.Bold = true;
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            //Information
            row.Cells[3].AddParagraph("Informacje");
            row.Cells[3].Format.Font.Bold = true;
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            //Notes
            row.Cells[4].AddParagraph("Notatki");
            row.Cells[4].Format.Font.Bold = true;
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            //Contact
            row.Cells[5].AddParagraph("Kontakt");
            row.Cells[5].Format.Font.Bold = true;
            row.Cells[5].Format.Alignment = ParagraphAlignment.Center;
            //RealizationUser
            row.Cells[6].AddParagraph("Realizacja");
            row.Cells[6].Format.Font.Bold = true;
            row.Cells[6].Format.Alignment = ParagraphAlignment.Center;
            //EnrolmentUser
            row.Cells[7].AddParagraph("Wpis");
            row.Cells[7].Format.Font.Bold = true;
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            //Creator
            row.Cells[8].AddParagraph("Autor");
            row.Cells[8].Format.Font.Bold = true;
            row.Cells[8].Format.Alignment = ParagraphAlignment.Center;
            #endregion

            #region Add Content To Table
            bool color = true;
            foreach(var item in lista){
                Row rowItem = table.AddRow();
                rowItem.TopPadding = 1;
                var news = NotNull(item);
                if(color){
                    rowItem.Shading.Color = Color.FromRgb(139, 193, 232);
                    color = false;
                }
                else{
                    rowItem.Shading.Color = Color.FromRgb(227, 227, 227);
                    color = true;
                }

                //Name
                rowItem.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                rowItem.Cells[0].AddParagraph(news.Name);

                //Place
                rowItem.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                rowItem.Cells[1].AddParagraph(news.Place);

                //Date
                rowItem.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[2].Format.Alignment = ParagraphAlignment.Center;
                rowItem.Cells[2].AddParagraph(news.Date.ToString());

                //Information
                rowItem.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[3].Format.Alignment = ParagraphAlignment.Justify;
                rowItem.Cells[3].AddParagraph(news.Information);

                //Notes
                rowItem.Cells[4].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                rowItem.Cells[4].AddParagraph(new Words(news.Notes,12).GetStringLines());

                //Contact 
                rowItem.Cells[5].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[5].Format.Alignment = ParagraphAlignment.Left;
                rowItem.Cells[5].AddParagraph(new Words(news.Contact,12).GetStringLines());

                //RealizationUser
                rowItem.Cells[6].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[6].Format.Alignment = ParagraphAlignment.Center;
                rowItem.Cells[6].AddParagraph(UserName(news.RealizationUser.Name));

                //EnrolmentUser
                rowItem.Cells[7].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[7].Format.Alignment = ParagraphAlignment.Center;
                rowItem.Cells[7].AddParagraph(UserName(news.EnrolmentUser.Name));

                //Creator
                rowItem.Cells[8].VerticalAlignment = VerticalAlignment.Center;
                rowItem.Cells[8].Format.Alignment = ParagraphAlignment.Center;
                rowItem.Cells[8].AddParagraph(UserName(news.Creator.Name));
            }
            #endregion
        }
        
        public string UserName(string Name){
            string GoodName = "";
            short characters = 8;
            if(Name.Length > characters){
                GoodName = Name.Substring(0,characters) + Environment.NewLine + Name.Substring(characters);
            }
            else
                GoodName = Name;
            return GoodName;
        }

    }
}