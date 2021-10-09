using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Challenges
{
    [DataContract]
    class UserRating
    {
        [DataMember(Name = "average_rating")]
        public double AverageRating { get; set; }

        [DataMember(Name = "votes")]
        public int Votes { get; set; }
    }

    [DataContract]
    class Datum
    {
        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "estimated_cost")]
        public int EstimatedCost { get; set; }

        [DataMember(Name = "user_rating")]
        public UserRating UserRating { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }

    [DataContract]
    class FoodOutletResult
    {
        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "per_page")]
        public int PerPage { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }

        [DataMember(Name = "data")]
        public List<Datum> Data { get; set; }
    }
}
