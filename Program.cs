using System;
using System.Linq;
using NaiveBayes.Models;

namespace NaiveBayes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the \"which ad should I show\" helper.");

            var inputData = new InputData();

            Console.WriteLine("Which Gender is the customer (Male/Female/Other)?");
            var genderString = Console.ReadLine();
            inputData.Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), genderString);

            Console.WriteLine("Which country is the customer from (England, Germany, France, Sweden, Norway, USA)?");
            var landString = Console.ReadLine();
            inputData.Land = (LandEnum)Enum.Parse(typeof(LandEnum), landString);

            Console.WriteLine("Which Age group is the customer from (UnderEighteen, EighteenToTwentyFive, TwentyFiveToForty, FortyOneToSixtyFive, OverSixtyFive)?");
            var ageGroupString = Console.ReadLine();
            inputData.AgeGroup = (AgeGroups)Enum.Parse(typeof(AgeGroups), ageGroupString);

            var database = new InMemoryDB();
            Console.WriteLine("-------------------------------------------");

            var electricCarProbability = GetProbability(database, AdEnum.ElectricCar, inputData);
            Console.WriteLine($"Calculated 'probability' for electric cars is {electricCarProbability}");
            Console.WriteLine("-------------------------------------------");

            var petrolCarProbability = GetProbability(database, AdEnum.PetrolCar, inputData);
            Console.WriteLine($"Calculated 'probability' for petrol cars is {petrolCarProbability}");
            Console.WriteLine("-------------------------------------------");

            var motorbikeProbability = GetProbability(database, AdEnum.Motorbike, inputData);
            Console.WriteLine($"Calculated 'probability' for motorbikes is {motorbikeProbability}");
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("We adjust the probabilities to add up to 1");
            var totalProbability = electricCarProbability + petrolCarProbability + motorbikeProbability;
            var adjustedElectricCarProbability = electricCarProbability / totalProbability;
            var adjustedPetrolCarProbability = petrolCarProbability / totalProbability;
            var adjustedMotorbikeProbability = motorbikeProbability / totalProbability;

            Console.WriteLine("Final probabilities are:");
            Console.WriteLine($"Electric car: {adjustedElectricCarProbability}");
            Console.WriteLine($"Petrol car: {adjustedPetrolCarProbability}");
            Console.WriteLine($"Motorbike car: {adjustedMotorbikeProbability}");
            Console.ReadLine();
        }

        static double GetProbability(InMemoryDB database, AdEnum adType, InputData inputData)
        {
            Console.WriteLine($"Probability calculation for {adType.ToString()}");

            var adData = database.AICounts.Single(c => c.AdType == adType);
            var baseProbability = (double)adData.TotalCount / database.TotalAds;
            Console.WriteLine($"Proportion of successful ads that were for {adType.ToString()}: {baseProbability}");

            var genderElectricCarData = adData.GenderCounts;
            var totalOfGenderPlus1 = (genderElectricCarData.SingleOrDefault(c => c.dataValue == inputData.Gender)?.Count ?? 1) + 1;
            var genderProbability = (double)totalOfGenderPlus1 / (adData.TotalCount + 1);
            Console.WriteLine($"Probability a customer is {inputData.Gender.ToString()} given they buy a/an {adType.ToString()} = {genderProbability}.");

            var landElectricCarData = adData.LandCounts;
            var totalFromLandPlus1 = (landElectricCarData.SingleOrDefault(c => c.dataValue == inputData.Land)?.Count ?? 1) + 1;
            var landProbability = (double)totalFromLandPlus1 / (adData.TotalCount + 1);
            Console.WriteLine($"Probability a customer is from {inputData.Land.ToString()} given they buy a/an {adType.ToString()} = {landProbability}.");

            var ageGroupElectricCarData = adData.AgeGroupCounts;
            var totalFromAgeGroupPlus1 = (ageGroupElectricCarData.SingleOrDefault(c => c.dataValue == inputData.AgeGroup)?.Count ?? 1) + 1;
            var ageGroupProbability = (double)totalFromAgeGroupPlus1 / (adData.TotalCount + 1);
            Console.WriteLine($"Probability a customer is from {inputData.AgeGroup.ToString()} age group given they buy a/an {adType.ToString()} = {ageGroupProbability}.");

            return baseProbability * genderProbability * landProbability * ageGroupProbability;
        }
    }
}
