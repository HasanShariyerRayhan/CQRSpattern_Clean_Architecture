using Employee.Model;
using Employee.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Persistance.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.FirstName);
        builder.HasOne(e =>e.Country).WithMany(e => e.Employees).HasForeignKey(e =>e.CountryId);
       
        builder.HasData(new
        {
            Id = 1,
            FirstName = "Raihan",
            LastName = "Shariare",
            Address = "Zigatola,Dhanmondi",
            CountryId = 1,
           
            Age = 29,
            PhoneNumber = "01580480304",
            Created = DateTimeOffset.Now,
            CreatedBy = "1",
            LastModified = DateTimeOffset.Now,
            Status = EntityStatus.Created

        });
        //, new
        //{
        //    Id = 2,
        //    FirstName = "Rayhan",
        //    LastName = "Rahman",
        //    Address = "Dhaka",
        //    Age = 25,
        //    PhoneNumber = "0197xxxxxx",
        //    Created = DateTimeOffset.Now,
        //    CreatedBy = "1",
        //    LastModified = DateTimeOffset.Now,
        //    Status = EntityStatus.Created

        //});
        
    }
}
