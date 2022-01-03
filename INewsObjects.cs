using System;
namespace TestPDF
{
    public class INewsObjects
    {
        User user = new User(){Name = string.Empty, FirstName = string.Empty, LastName = string.Empty, Password = string.Empty, Theme = true, Off = true};
        public News NotNull(News news){
            if(news.Name == null){
                news.Name = string.Empty;
            }
            if(news.Place == null){
                news.Place = string.Empty;
            }
            if(news.Information == null){
                news.Information = string.Empty;
            }
            if(news.Contact == null){
                news.Contact = string.Empty;
            }
            if(news.Notes == null){
                news.Notes = string.Empty;
            }
            if(news.EnrolmentUser == null){
                news.EnrolmentUser = user;
            }
            if(news.RealizationUser == null){
                news.RealizationUser = user;
            }
            if(news.Creator == null){
                news.Creator = user;
            }
            return news;
        }
    }
}