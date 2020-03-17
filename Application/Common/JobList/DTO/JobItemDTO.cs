using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Common.JobList.DTO
{
    public class JobItemDTO : IMapFrom<JobItem>
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public SuburbItem Suburb { get; set; }
        public CategoryItem Category { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobItem, JobItemDTO>();
        }
    }

}
