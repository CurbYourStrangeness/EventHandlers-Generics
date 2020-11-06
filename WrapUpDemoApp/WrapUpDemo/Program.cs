using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapUpDemo
{
    partial class Program
    {
        static void Main(string[] args)
        {

            List<PersonModel> persons = new List<PersonModel>
            {
                new PersonModel{ fName = "Developer", lName="Future", Email="Lookingforward@protonmail.com"},
                new PersonModel{ fName = "Jenn", lName="Shapeshifter", Email="lookingatyou@protonmail.com"},
                new PersonModel{ fName = "Marisa", lName="Kirisame", Email="orderedliving@protonmail.com"},

            };

            List<SubmarineModel> IdeaSubmarines = new List<SubmarineModel>
            {
                new SubmarineModel{ Designer = "Private0", Builder = "General Dynamics", Crew = "Moderately staffed with midshipman and officers."},
                new SubmarineModel{ Designer = "Private1", Builder = "Rolls Royce", Crew = "Skeleton Crew."},
                new SubmarineModel{ Designer = "Private2", Builder = "Huntington Ingalls", Crew = "Fully staffed."}
            };

            DataAccessing<PersonModel> pers = new DataAccessing<PersonModel>();
           
            DataAccessing<SubmarineModel> subs = new DataAccessing<SubmarineModel>();
           
            pers.SaveToCSV(persons, @"C:\\Temp\\persons.csv");
            //IdeaSubmarines.SaveToCSV(@"C:\\Temp\\SaveThis\\subs.csv");
            subs.SaveToCSV(IdeaSubmarines, @"C:\\Temp\\SaveThis\\subs.csv");

            pers.BadEntryFound += pers_BadEntryFound;
            subs.BadEntryFound += subs_BadEntryFound;
            Console.ReadLine();
        }

        private static void subs_BadEntryFound(object sender, SubmarineModel e)
        {
            Console.WriteLine($"Unusable entry found for {e.Designer}, {e.Builder}.");
        }

        private static void pers_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Unusable entry found for {e.fName} {e.lName}.");
        }
    }

    public class DataAccessing<T> where T: new()
    {

        public event EventHandler<T> BadEntryFound;
        public void SaveToCSV(List<T> devs, string filepath) 
        {
            List<string> rows = new List<string>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            string row = "";
            foreach (var col in cols)
            {
                row += $",{col.Name}";
            }

            row = row.Substring(1);

            rows.Add(row);

            foreach (var dev in devs)
            {
                row = "";
                bool UnusableWords = false;
                foreach (var col in cols)
                {
                    string value = col.GetValue(dev, null).ToString();

                    UnusableWords = UnusableWordDetector(value);
                    if (UnusableWords)
                    {
                        BadEntryFound?.Invoke(this, dev);
                        break;
                    }
                                        
                    row += $",{value}";
                }

                if (UnusableWords)
                {
                    continue;
                }
                else
                {
                    row = row.Substring(1);

                    rows.Add(row);
                }        
            }

            File.WriteAllLines(filepath, rows);
        }

        private bool UnusableWordDetector(string test)
        {
            bool outp = false;

            var useCase = test.ToLower();
            if (useCase.Contains("darn") || useCase.Contains("heck"))
            {
                outp = true;
            }

            return outp;
        }
    }
}
