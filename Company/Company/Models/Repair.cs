using Company.Services.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Models
{
    public class Repair : NotifyProperty
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int CityId { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        public DateTime? SelectDate { get; set; }

        public Work Work { get; set; }

        public int? MasterId { get; set; }

        public string CommentUser { get; set; }

        public string CommentMaster { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public ICollection<Option> Options { get; set;}

        [JsonIgnore]
        public int GetPrice
        {
            get
            {
                int count = Work.Price;

                if (Options == null)
                    return count;

                foreach (var option in Options)
                {
                    count += option.Price ?? 0;
                }

                return count;
            }
        }

        public Repair()
        {
            StartTime = DateTime.Now;
        }
    }
}
