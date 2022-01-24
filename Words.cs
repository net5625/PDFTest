using System.Globalization;
using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System.Collections.Generic;

namespace TestPDF
{
    public class LongWords{
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public string Result {get; set;}
    }
    public class Words
    {
        public static string Content {get; set;}
        public static short Width {get; private set; }

        public Words(string paragraph, short width){
            Content = paragraph;
            Width = width;

        }

        public string GetStringLines(){
            // List<short> indexer = new List<short>();

            // if(Content.Length <= Width){
            //     return Content;
            // }
            // indexer = GetIndexesOfWhiteSpace(Content);

            // for(int i = 0; i < indexer.Count - 1; i++){
            //     int number;
            //     if(i == 0){
            //         number = indexer[i];
            //         if(number > Width){
            //             Content = AddNewLine(Content, indexer[i] + Width);
            //             indexer = null;
            //             indexer = GetIndexesOfWhiteSpace(Content);
            //             i = 0;
            //         }
            //     }
            //     number = indexer[i+1] - indexer[i];
            //     if(number > Width){
            //         Content = AddNewLine(Content, indexer[i] + Width);
            //         indexer = null;
            //         indexer = GetIndexesOfWhiteSpace(Content);
            //         i = 0;
            //     }
            // }
            // return Content;
            return Content;
        }

        private static void BrakeLines(){
            var indexes = GetIndexesOfWhiteSpace(Content);
            int space = 0;
            List<LongWords> ToChange = new List<LongWords>();

            for(int i = 0; i < indexes.Count - 1; i++){
                if(i == 0 && indexes[i] != 0){
                    space = indexes[i];
                    if(space > Width){
                        ToChange.Add(new LongWords{StartIndex = 0,EndIndex = indexes[i]});
                    }
                }
                
                space = indexes[i+1] - indexes[i];
                if(space > Width){
                    ToChange.Add(new LongWords{StartIndex = indexes[i], EndIndex = indexes[i+1]});
                }
            }

            foreach(var item in ToChange){
                //item.Result =  //Make Text with brake lines
            }
            
            //Content = Substring //MAKE SUBSTRING CONTENT WITH ITEMS of LongWords.Result
        }

        private static string AddNewLine(string content, int position){
            return content.Substring(0, position) + Environment.NewLine + content.Substring(position);
        }

        private static List<short> GetIndexesOfWhiteSpace(string content){
            short ind = 0;
            List<short> indexer = new List<short>();

            foreach(char c in content){
                if(c == ' '){
                    indexer.Add(ind);
                }
                ind += 1;
            }
            return indexer;
        }
    }
}