using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    partial class Program
    {


        static void Main(string[] args)
        {
            CorporateOfficeModel Brady = new CorporateOfficeModel("Mid-Level Java Developer", 100);
            CorporateOfficeModel Tesla = new CorporateOfficeModel("Entry-Level C++ Developer", 800);
            Enumerate nameThis = new Enumerate();


            for (int i = 0; i < Brady.MaxHires; i++)
            {
                Brady.HireOn(nameThis.ElementAt(i));
                Console.WriteLine(nameThis.ElementAt(i));
            }

            Brady.HireListFull += CompanyHireListFull;

            Tesla.HireListFull += CompanyHireListFull;

            //foreach (var HireName in Enum.GetValues(typeof(HireNames)))
            //{
            //    var Developer = HireName.ToString();
            //    Brady.HireOn(Developer);
            //    Brady.Next();
            //}

            Console.ReadLine();
        }

        private static void CompanyHireListFull(object sender, string e)
        {
            CorporateOfficeModel modeling = (CorporateOfficeModel)sender;
            Console.WriteLine();
            Console.WriteLine($"{ modeling.CompanyName} has an employment roster which is full right now. Definitely come back later.");
            Console.WriteLine();
        }

        //private static void PrintToConsole(this string use)
        //{
        //    Console.WriteLine(use);
        //}

        public class CorporateOfficeModel 
        {
            private List<string> CurrentEmployees = new List<string>();

            private List<string> PotentialHires = new List<string>();

            //event handler
            public event EventHandler<string> HireListFull;

            public string CompanyName { get; set; }

            public string NewHire { get; private set; }

            public int MaxHires { get; private set; }

            public CorporateOfficeModel(string hire, int maxEmployees)
            {
                NewHire = hire;

                MaxHires = maxEmployees;
            }

            public void HireOn(string NewHire)
            {
                string outp = "";
                if (CurrentEmployees.Count < MaxHires)
                {
                    CurrentEmployees.Add(NewHire);
                    outp = $"{NewHire} was hired on!";
                    if (CurrentEmployees.Count  == MaxHires)
                    {
                        HireListFull?.Invoke(this, $"{CompanyName} is not presently hiring. Try again 'later'.");
                    }
                }
                else
                {
                    PotentialHires.Add(NewHire);
                    outp = $"{NewHire} was added to the list of potential hires!";
                }
            }
        }

        public class Enumerate: IEnumerable<string>
        {
            public IEnumerator<string> GetEnumerator()
            {
                foreach (var HireName in Enum.GetValues(typeof(HireNames)))
                {
                    String HireQ = HireName.ToString();

                    yield return HireQ;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
        }
        public enum HireNames
        {


            //This is a massively abbreviated enum
            [Description("KingCthulhu")]
            KingCthulhu,
            [Description("Sue Storm")]
            SueStorm,
            [Description("Janus God of Choices")]
            JanusTwoface,
            [Description("Paul Son of Odin")]
            PaulDev,
            [Description("Beelzebuth Lady of Bugfixing")]
            BeelzebuthDev,
            [Description("Antaeus, Sharer of Programming Wisdom")]
            SeniorDevAntaeus,
            [Description("Rachel of the Long-Form Notes")]
            MeetingMinutesRachel,
            [Description("Jack Miller, Finder and Fixer of Obscure Errors")]
            JackMillerDev,
            [Description("Michael, Current Project Lead")]
            MichaelProjLead,
            [Description("George Orwell, Speaker of Common Sense Endpoints")]
            OrwellDev,
            [Description("Masayuki, Developing Prodigy")]
            MasayukiProdigy,
            [Description("Rimuru Tempest, High-Level Manager")]
            RimuruBoss,
            [Description("Lucifer, Temporary CEO")]
            LuciferCEO,
            [Description("Charlie, HR Manager")]
            CharlieHR,
            [Description("Alphonse El, Head of Security")]
            AlphonseSec,
            [Description("Sadie, Hacker Watchdog from Hell")]
            SadieEffectiveEmployee,
            [Description("Jemima, Cop/Secretary")]
            BadassJemima,
            [Description("Jillian, Razor Sharp (Intelligent and Effective) Floor Manager (Logistics)")]
            JillianRazor,
            [Description("Phil, Camera Watcher")]
            PhilCamera,
            [Description("Rose, PersonaCrafter (Often found in Marketing)")]
            RoseTrainer,
            [Description("GiBi, Mascot")]
            GiBiAttention,
            [Description("Jared, Company Traffic Monitor")]
            JaredTraffic,
            [Description("Mike, Janitor (Almighty)")]
            AccessMike,
            [Description("Tim, Senior Dev")]
            TimDefinesHisRole,
            [Description("Leo, Cyborg Adventurer")]
            LeoHasHigherAbstractionThanYou,
            [Description("Dom, Inventor Genius (Excellent Friends with Leo)")]
            DomCanEffectivelyModifyandMergeReality,
            [Description("Aslan, Protector of Development")]
            SpiritLion,
            [Description("Julie, HR Middle-Manager")]
            JulieOwnsLifeExperienceAndZombies,
            [Description("Janet, C++ Dev (Entry Level)")]
            JanetWithAPlan,
            [Description("Gamzee, Chaos Engineer")]
            GamzChaosEngr,
            [Description("Sollux, Hardware Repair")]
            SolluxReaper,
            [Description("Eridan Ampora, VP")]
            EridanVP,
            [Description("Feferi, Reality Negotiator")]
            FeferiHasDefinedMoreWorldsThanMany,
            [Description("Aradia, Time Manipulator")]
            AradiaRollsBackTimeButNotSoftwareProgressSoWeDontMissDeadlines,
            [Description("Devi, Electrician")]
            DeviHandlesTheLights,
            [Description("Donald Trump, President 2020")]
            TrumpPresident2020,
            [Description("James, Java Developer (Entry Level)")]
            EntryJavaJames,
            [Description("Confluence of Names and Identities")]
            AwareOfMoreThanYou,
            [Description("Yuyuko Saigyouji, Queen of Distribution Algorithms")]
            MasterOfDeath,
            [Description("Youmu Konpaku, Java Developer (Mid Level)--A Step At A Time")]
            YoumuPwnsJava,
            [Description("Alastor, Radio Demon")]
            MarshallerOFHRAndMasterOfTravelingSalesmanProblem,
            [Description("Joe, Commercial Designer")]
            JoeDesigner,
            [Description("Feynman, Mathematician (Physics)")]
            CriticalThinkingSparker,
            [Description("Reimu, Cafeteria Logistics")]
            FoodFromReimu,
            [Description("Zeke, Master of Networking")]
            ZDataCenterOrganizer,
            [Description("Masayoshi, Production Line Manager")]
            MasayoshiProdLine,
            [Description("Equius Zahhak, Development Course Trainer")]
            EquiusTrainsDevs,
            [Description("Carl, Senior Dev")]
            CarlPlaysAlmostAsMuchARoleDefiningRealityAsFeferi,
            [Description("Johnny, Marketing")]
            JohnnyMarket,
            [Description("Lucille, Clam Chowder Maker")]
            LucilleClamChowder,
            [Description("Jalonda, HR Middle Manager")]
            FreshJalonda,
            [Description("Karkat Vantas, Quality Inspector")]
            KarkatINpsectsFactoryLineQuality,
            [Description("Jemille, Operations Manager")]
            JemilleOps,
            [Description("Dave, the Accountant")]
            AccountantDave,
            [Description("Jordan, CFO for Eight Years")]
            JordanCFO,
            [Description("Janey, Purchasing Manager")]
            JaneyHandlesPurchases,
            [Description("Jonathon, IT Desk")]
            JonIT,
            [Description("Harold, IT Desk")]
            HaroldIT,
            [Description("Jemarkus, Sales Manager")]
            JemarkusSales,
            [Description("Jordie, Mechanical Engineering")]
            JordiME,
            [Description("Tatum, Electrical Engineer")]
            TatumEE,
            [Description("Harold, Product Design")]
            HaroldProdDes,
            [Description("Light, Designated Firer")]
            LightFires,
            [Description("Ultima, Mergers and Acquisitions")]
            UltimaTakes,
            [Description("Chase, Finance Intern")]
            ChaseIsNew,
            [Description("Carerra, Legal (Mid-Level)")]
            BigStickCarerra,
            [Description("Testarossa, Cybersecurity")]
            NotSureWhatTestarossaDoes,
            [Description("Diablo, Detail Handler for C-Suite")]
            DiableHasFingersInManyPies,
            [Description("Lazar, SecOps")]
            LazarWorksSecOps,
            [Description("Kyle, IT Architect")]
            KyleDecidesMnayPlatformsInUse,
            [Description("Fool, Ego Troubleshooter")]
            FoolHelpsPreventCentralizationOfAuthority,
            [Description("Lenore, DB Admin")]
            WorldNeedsMoreMultiDisciplinesLikeLenore,
            [Description("Kenny, Security Compliance Management")]
            OhNoTheyKilledKenny,
            [Description("Anon, ZKSTARK Integration")]
            ZeroTrustAnon,
            [Description("Anon0, Zexe Upgrader")]
            ConsiderAnon0,
            [Description("Jeffrey, Chief Technology Officer")]
            JeffCTO,
            [Description("Mark, Chief Operations Officer")]
            MarkSmithOpsArchitect,
            [Description("Shuna, Chief Marketing Officer")]
            WiseShunaIsWise,
            [Description("Marisa Kirisame, Chief Information Officer")]
            MarisaThoughtLeader,
            [Description("Bryce, IT")]
            BryceIT,
            [Description("Nicholas, Front-End Developer (Mid Level)")]
            NicholasJavaScript,
            [Description("Carrie, Front-End Developer (Entry Level)")]
            CarrieCSSFrameworks,
            [Description("Johan, Senior Front-End Developer")]
            JohanJavaScriptFrameworks,
            [Description("Magane Chikujoin, General Counsel")]
            GeneralMagane,
            [Description("Yukari Yakumo, Wearer of Many Hats (presently Chief Legal Officer)")]
            LegalChiefYukari,
            [Description("Jessica, Vice President Legal Affairs")]
            LegalVPJess,
            [Description("Jordan Peterson, Organizational Psychologist")]
            JPAdvocatesOrganization,
            [Description("Nitori Kawashiro, Civil Engineering")]
            NitoriCE,
            [Description("Jamal Blakely, Business Analyst")]
            JamalPlans,
            [Description("Haley Plents, Legal Receptionist")]
            HaleyPushesThrough,
            [Description("Jeremiah Henderson, Patent Agent")]
            JeremiahDoesPatents,
            [Description("William Leannah, Senior Manager Legal")]
            LeannahLeadsLawyers,
            [Description("Martin Salazar, Legal Services Director")]
            MartinHeadsMiddleManagement,
            [Description("Alessis DeVille, SAP Hana Security/GRC Lead")]
            DeVilleTakesCharge,
            [Description("Michael Jordan, Rockstar Developer")]
            StarTakesStage,
            [Description("Kevin Peterson, FactoryWorker")]
            KevinBackboneA,
            [Description("John Briansson, Factory Worker")]
            JohnBackboneB,
            [Description("Carl Marx, Factory Worker")]
            MarxTooBusyEarningAnHonestLivingToStartUpSocialUnrestBackboneC,
            [Description("Samuel Clemens, Quality Assurance")]
            DebuggerMaster,
            [Description("Shiraori, Kin of D")]
            MaintainerofaGivenWorldAtATime,
            [Description("D, Administrator")]
            EternalArchitect,
            [Description("Remaining Staff")]
            TenNonillionMoreAtLeast


        }
    }
}
