﻿using AutoMapper;
using Employee.Infrastructure.Persistance;
using Employee.Model;
using Employee.Repository.Interface;
using Employee.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Concrete;

public class CountryRepository : RepositoryBase<Country, VMCountry, int>, ICountryRepository
{
    public CountryRepository(EmployeeDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {

    }
}
