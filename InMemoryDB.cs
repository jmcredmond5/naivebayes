using System.Collections.Generic;
using System.Linq;
using NaiveBayes.Models;

namespace NaiveBayes
{
    public class InMemoryDB
    {
        public List<AdData> AICounts { get; set; }
        // Total is 30 + 80 + 10 = 120
        public int TotalAds { get; set; }

        public InMemoryDB()
        {
            AICounts = new List<AdData>
            {
                CreateElectricCarData(),
                CreatePetrolCarData(),
                CreateMotorbikeData()
            };
            TotalAds = AICounts.Sum(c => c.TotalCount);
        }

        private static AdData CreateElectricCarData()
        {
            return new AdData()
            {
                AdType = AdEnum.ElectricCar,
                TotalCount = 30,
                LandCounts = new List<AssociatedDataCount<LandEnum>>()
                {
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.Norway,
                        Count = 20
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.England,
                        Count = 5
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.Germany,
                        Count = 3
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.Sweden,
                        Count = 2
                    }
                },
                GenderCounts = new List<AssociatedDataCount<GenderEnum>>()
                {
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Male,
                        Count = 10
                    },
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Female,
                        Count = 10
                    },
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Other,
                        Count = 10
                    }
                },
                AgeGroupCounts = new List<AssociatedDataCount<AgeGroups>>()
                {
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.TwentyFiveToForty,
                        Count = 20
                    },
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.FortyOneToSixtyFive,
                        Count = 8
                    },
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.EighteenToTwentyFive,
                        Count = 2
                    }
                }
            };
        }

        private static AdData CreatePetrolCarData()
        {
            return new AdData()
            {
                AdType = AdEnum.PetrolCar,
                TotalCount = 80,
                LandCounts = new List<AssociatedDataCount<LandEnum>>()
                {
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.Norway,
                        Count = 5
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.England,
                        Count = 10
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.Germany,
                        Count = 10
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.Sweden,
                        Count = 5
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.USA,
                        Count = 50
                    }
                },
                GenderCounts = new List<AssociatedDataCount<GenderEnum>>()
                {
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Male,
                        Count = 35
                    },
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Female,
                        Count = 35
                    },
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Other,
                        Count = 10
                    }
                },
                AgeGroupCounts = new List<AssociatedDataCount<AgeGroups>>()
                {
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.UnderEighteen,
                        Count = 5
                    },
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.TwentyFiveToForty,
                        Count = 20
                    },
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.FortyOneToSixtyFive,
                        Count = 15
                    },
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.EighteenToTwentyFive,
                        Count = 30
                    },
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.OverSixtyFive,
                        Count = 10
                    }
                }
            };
        }

        private static AdData CreateMotorbikeData()
        {
            return new AdData()
            {
                AdType = AdEnum.Motorbike,
                TotalCount = 10,
                LandCounts = new List<AssociatedDataCount<LandEnum>>()
                {
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.France,
                        Count = 1
                    },
                    new AssociatedDataCount<LandEnum>()
                    {
                        dataValue = LandEnum.USA,
                        Count = 9
                    }
                },
                GenderCounts = new List<AssociatedDataCount<GenderEnum>>()
                {
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Male,
                        Count = 4
                    },
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Female,
                        Count = 4
                    },
                    new AssociatedDataCount<GenderEnum>()
                    {
                        dataValue = GenderEnum.Other,
                        Count = 2
                    }
                },
                AgeGroupCounts = new List<AssociatedDataCount<AgeGroups>>()
                {
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.UnderEighteen,
                        Count = 9
                    },
                    new AssociatedDataCount<AgeGroups>()
                    {
                        dataValue = AgeGroups.OverSixtyFive,
                        Count = 1
                    }
                }
            };
        }
    }
}
