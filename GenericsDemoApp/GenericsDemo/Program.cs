using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            //string[] testArr;
            //List<string> strList = new List<string>();

            //List<int> sampleDev = new List<int>();

            //sampleDev.Add(99999999);
            //strList.Add(1.ToString());

            //string result = FlipSus("Handsome");

            //Console.WriteLine($"Handsome: {result}");

            //result = FlipSus(999);

            //Console.WriteLine($"999: {result}");

            //result = FlipSus(new PersonModel { fName = "Jeremy", lName = "TEKSystems"});

            //Console.WriteLine($"PersonModel: {result}");

            GenericHelper<PersonModel> Developer = new GenericHelper<PersonModel>();

            Developer.ValidateAndCollect(new PersonModel { fName = "Jack", lName = "Miller", returns = 99999999999999999, HasErrors = false  });

            foreach(var obj in Developer.SomeStuff)
            {
                Console.WriteLine($"{obj.fName} is in use.");
            }

            foreach(var yeet in Developer.StuffOut)
            {
                Console.WriteLine($"{yeet.fName} is not currently in use.");
            }

            Console.ReadLine();
        }

        private static string FlipSus<T>(T fullCircleBringer)
        {
            //private static T FlipSus<T, Q> -- can add more than one generic associated with a given method
            //if num %3 == 0 return sus
            //if num %5 == 0 return notSus
            //if num %5 == 0 && num %3 == 0 return GameRestart
            int relevantLength = fullCircleBringer.ToString().Length;
            string outp = "";

            //TypeShift(fullCircleBringer, outp);

            //MethodInfo m = typeof(T).GetMethod("Parse", new Type[] { typeof(string) });

            //if (m != null)
            //{
            //    return m.Invoke(null, new object[] { base.Value });
            //}

            //fullCircleBringer.TryCast<string>(out outp);

            if (relevantLength % 3 == 0)
            {
                outp += "Sus";
            }
            else if (relevantLength % 5 == 0)
            {
                outp += "Not Sus";
            }
            else if (relevantLength % 5 == 0 && relevantLength % 3 == 0)
            {
                outp += "Game Restart";
            }
            else if (relevantLength % 8 == 0)
            {
                outp += "Badasses";
            }
            else if (relevantLength % 8 == 0 && relevantLength % 3 == 0)
            {
                outp += "Exploratory Spacefaring";
            }

                //var ret = outp.TryCast<T>(out fullCircleBringer);

                //return fullCircleBringer;

                return outp;
        }


        //public static object TypeShift(Type t, object value)
        //{
        //    TypeConverter tc = TypeDescriptor.GetConverter(t);
        //    return tc.ConvertFrom(value);
        //}

        //public static bool TryCast<T>(this object obj, out T result)
        //{
        //    if (obj is T)
        //    {
        //        result = (T)obj;
        //        return true;
        //    }

        //    result = default(T);
        //    return false;
        //}

        public class GenericHelper<T> where T: IErrorCheck//class, interface model
        {
            public List<T> SomeStuff { get; set; } = new List<T>();
            public List<T> StuffOut { get; set; } = new List<T>();

            public void ValidateAndCollect(T dpj)
            {
                if (dpj.HasErrors == false && !(dpj.Equals(null)))
                {
                    SomeStuff.Add(dpj);
                }
                else
                {
                    StuffOut.Add(dpj);
                }
            }
        }

        public interface IErrorCheck
        {
            bool HasErrors { get; set; }
        }

        public class SpaceShipModel : IErrorCheck
        {
            public string Builder { get; set; }

            public int MyProperty { get; set; }
            public bool HasErrors { get; set; }
        }

        public class PersonModel : IErrorCheck
        {
            public string fName { get; set; }

            public string lName { get; set; }

            public long returns { get; set; }
            public bool HasErrors { get; set; }
        }

    }
}
