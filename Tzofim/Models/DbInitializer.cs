using System.Linq;
using System;

namespace Tzofim.Models
{
    public class DbInitializer
    {
       public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
            
            if (!context.Cultures.Any())
            {
                var cultures = new[]
                {
                    new CultureForNews{Key="ru"},
                    new CultureForNews{Key="en"},
                    new CultureForNews{Key="ua"}
                };

                context.Cultures.AddRange(cultures.ToList());
            }

            if (!context.News.Any())
            {
                var news = new[]
                {
                new News(){Title="Semper feugiat nibh",
                    NewsText="Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit, sed do eiusmod tempor incididunt ut" +
                " labore et dolore magna aliqua. Pellentesque eu tincidunt tortor" +
                " aliquam nulla facilisi cras fermentum. Tristique sollicitudin " +
                "nibh sit amet commodo. Tincidunt nunc pulvinar sapien et ligula" +
                " ullamcorper malesuada proin.",
                    CultureId = context.Cultures.FirstOrDefault(p=>p.Key=="en"),
                    DateTime = DateTime.Now
                },

                new News(){Title="Semper feugiat nibh",
                    NewsText="Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit, sed do eiusmod tempor incididunt ut" +
                " labore et dolore magna aliqua. Pellentesque eu tincidunt tortor" +
                " aliquam nulla facilisi cras fermentum. Tristique sollicitudin " +
                "nibh sit amet commodo. Tincidunt nunc pulvinar sapien et ligula" +
                " ullamcorper malesuada proin.",
                    CultureId = context.Cultures.FirstOrDefault(p=>p.Key=="en"),
                    DateTime = DateTime.Now
                },

                new News() {Title= "Lorem ipsum: употребление",
                    NewsText= "Lorem ipsum – псевдо-латинский текст, который используется" +
                    " для веб дизайна, типографии, оборудования, и распечатки вместо " +
                    "английского текста для того, чтобы сделать ударение не на содержание," +
                    " а на элементы дизайна. Такой текст также называется как заполнитель.",
                    CultureId = context.Cultures.FirstOrDefault(p=>p.Key=="ru"),
                    DateTime = DateTime.Now
                },

                 new News() {Title= "Lorem ipsum: употребление",
                    NewsText= "Lorem ipsum – псевдо-латинский текст, который используется" +
                    " для веб дизайна, типографии, оборудования, и распечатки вместо " +
                    "английского текста для того, чтобы сделать ударение не на содержание," +
                    " а на элементы дизайна. Такой текст также называется как заполнитель.",
                    CultureId = context.Cultures.FirstOrDefault(p=>p.Key=="ru"),
                    DateTime = DateTime.Now
                },

                new News() {Title= "Lorem ipsum: вживання",
                    NewsText= "Lorem ipsum - псевдо-латинський текст, який використовується "+
                     "Для веб дизайну, друкарні, обладнання, і роздруківки замість" +
                     "Англійського тексту для того, щоб зробити наголошує не на зміст," +
                     "А на елементи дизайну. Такий текст також називається як заповнювач. ",
                    CultureId = context.Cultures.FirstOrDefault(p=>p.Key=="ua"),
                    DateTime = DateTime.Now
                },

                 new News() {Title= "Lorem ipsum: вживання",
                    NewsText= "Lorem ipsum - псевдо-латинський текст, який використовується "+
                     "Для веб дизайну, друкарні, обладнання, і роздруківки замість" +
                     "Англійського тексту для того, щоб зробити наголошує не на зміст," +
                     "А на елементи дизайну. Такий текст також називається як заповнювач. ",
                    CultureId = context.Cultures.FirstOrDefault(p=>p.Key=="ua"),
                    DateTime = DateTime.Now
                },
                };

                context.News.AddRange(news.ToList());
            }

            context.SaveChanges();

        }
    }
}
