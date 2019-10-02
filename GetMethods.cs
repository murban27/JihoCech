using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
namespace ConsoleApp2
{
    class GetMethods
    {
        public int RecaptchaResult { get; set; }
        public string RecaptachaCode { get; set; }
        public string FormId { get; set; }
        public string CaptchaToken { get; set; } 
        


        public GetMethods()
        {

            using (var Client = new HttpClient())
            {
                string Url = "Http://www.kraj-jihocesky.cz/ku_gordic/zadej?id=784";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(Url);


                var rows = doc.DocumentNode.SelectNodes("//table//tr");
                int counter = 0;
                int catcha_result = 0;
                string line = rows[1].InnerText.Replace("\n", " ").Replace(@"Matematický příklad", "").Replace(@"Vyřešte tento jednoduchý matematický příklad a vložte výsledek. Např. pro 1+3 vložte 4.", " ").Replace("=", " ").Trim();
                var cisla = line.Split('+');
             RecaptchaResult=
                int.Parse(cisla[0])+int.Parse(cisla[1]);

               // RecaptachaCode
                


             //   string[] lines = rows[1].InnerText.Split(" ",15);

                foreach (char s in rows[1].InnerText)
                {
                    int a = -1;
                    int.TryParse(s.ToString(),out a);
                    if (a > 0)
                    { 
                        counter++;
                        catcha_result = +a;
                        a = 0;

                    }

                   if(counter>1)
                    {
                        break;
                    }
                  

                }









            }





        }
    }
}