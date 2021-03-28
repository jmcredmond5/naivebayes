using System.Collections.Generic;
using NaiveBayes.Models;

namespace NaiveBayes
{
    public class AdData
    {
        public AdEnum AdType { get; set; }
        public int TotalCount { get; set; }
        public List<AssociatedDataCount<GenderEnum>> GenderCounts { get; set; }
        public List<AssociatedDataCount<LandEnum>> LandCounts { get; set; }
        public List<AssociatedDataCount<AgeGroups>> AgeGroupCounts { get; set; }
    }
}
