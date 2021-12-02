using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week_09_MachineLearning.Entities;
using System.IO;

namespace week_09_MachineLearning
{
    public partial class Form1 : Form
    {
        #region Fields
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random vel = new Random(1234);
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            for (int year = 2005; year <= 2024; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                var nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                var nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();

                Console.WriteLine(
                string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }
        }
        #endregion

        #region Simulation methods

        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive)
                return;
            var Age = year - person.BirthYear;
            var deathProbability = (from x in DeathProbabilities
                                   where x.Age == Age && x.Gender == person.Gender
                                   select x.Probability).FirstOrDefault();
            if (vel.NextDouble() <= deathProbability)
                person.IsAlive = false;
            if (!person.IsAlive && person.Gender == Gender.Male)
                return;
            var birthProbability = (from x in BirthProbabilities
                                    where x.Age == Age && x.NumberOfChildren == person.NumberOfChildren
                                    select x.Probability).FirstOrDefault();
            if(vel.NextDouble() <= birthProbability)
                Population.Add(new Person()
                {
                    BirthYear = year,
                    Gender = (Gender)vel.Next(1,3),
                    NumberOfChildren = 0
                });
        }
        #endregion

        #region ReadData

        private List<Person> GetPopulation(string path)
        {
            List<Person> population = new List<Person>();

            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string[] t = sr.ReadLine().Split(';');
                Person p = new Person();
                p.BirthYear = int.Parse(t[0]);
                p.Gender = (Gender)int.Parse(t[1]);
                p.NumberOfChildren = int.Parse(t[2]);
                population.Add(p);
            }
            sr.Close();
            return population;
        }

        private List<BirthProbability> GetBirthProbabilities(string path)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] t = sr.ReadLine().Split(';');
                    birthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(t[0]),
                        NumberOfChildren = int.Parse(t[1]),
                        Probability = double.Parse(t[2])
                    });
                }
            }
            return birthProbabilities;
        }

        List<DeathProbability> GetDeathProbabilities(string path)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] t = sr.ReadLine().Split(';');
                    deathProbabilities.Add(
                        new DeathProbability()
                        {
                            Age = int.Parse(t[1]),
                            Gender = (Gender)int.Parse(t[0]),
                            Probability = double.Parse(t[2])
                        });
                }
            }

            return deathProbabilities;
        }


        #endregion
    }
}
