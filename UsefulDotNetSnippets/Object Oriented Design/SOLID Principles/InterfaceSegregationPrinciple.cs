using System;
using System.Collections.Generic;

namespace Dvinun.UsefulDotNetSnippets.Object_Oriented_Design.SOLID_Principles
{
    public class InterfaceSegregationPrinciple
    {
        public static void DemoRun()
        {
            // This example is to show how the separation of concerns are cleanly 
            // divided into different classes and interfaces that has their own features
            // We have divided the functionalities seasonable and drawable into separate interfaces
            // So we are going to keep the classes of celestialbody to contain
            // mainly the properties and let them implement only required interfaces
            // and dont have to implement that is not necessary

            ISpaceRepository spaceRepository = new SanaSpaceRepository();
            List<CelestialBody> listCelestialBody = spaceRepository.GetTrendingCelestialBodies();

            listCelestialBody.ForEach(item => Console.WriteLine(item));
            listCelestialBody.ForEach(item => Console.WriteLine((item as ISeasonable)?.Info));
            listCelestialBody.ForEach(item => (item as I2DDrawable)?.Draw());
        }

        public class CelestialBody
        {
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private interface ISpaceRepository
        {
            List<CelestialBody> GetTrendingCelestialBodies();
        }

        private class SanaSpaceRepository : ISpaceRepository
        {
            public List<CelestialBody> GetTrendingCelestialBodies()
            {
                List<CelestialBody> listCelestialBody = new List<CelestialBody>();
                listCelestialBody.Add(new Moon("Callisto"));
                listCelestialBody.Add(new Asteroids("Ceres"));
                listCelestialBody.Add(new Meteorites("Murchison"));
                listCelestialBody.Add(new Planet("Mars", "Planet Mars got seasons"));
                return listCelestialBody;
            }
        }

        private class Planet : CelestialBody, ISeasonable, I2DDrawable
        {
            private string seasonableInfo;

            public Planet(string name, string seasonableInfo)
            {
                this.Name = name;
                this.Info = seasonableInfo;
            }

            public string Info { get => seasonableInfo; set => seasonableInfo = value; }

            public void Draw()
            {
                Console.WriteLine($"Drawing Planet - {Name}");
            }
        }

        private class Moon : CelestialBody, I2DDrawable
        {
            public Moon(string name)
            {
                this.Name = name;
            }

            public void Draw()
            {
                Console.WriteLine($"Drawing Moon - {Name}");
            }
        }

        private class Asteroids : CelestialBody, I2DDrawable
        {
            public Asteroids(string name)
            {
                this.Name = name;
            }

            public void Draw()
            {
                Console.WriteLine($"Drawing Asteroids - {Name}");
            }
        }

        private class Meteorites : CelestialBody, I2DDrawable
        {
            public Meteorites(string name)
            {
                this.Name = name;
            }

            public void Draw()
            {
                Console.WriteLine($"Drawing Meteorites - {Name}");
            }
        }

        private interface ISeasonable
        {
            string Info { get; set; }
        }

        private interface I2DDrawable
        {
            void Draw();
        }
    }
}
