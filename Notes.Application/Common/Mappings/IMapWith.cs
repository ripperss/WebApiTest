﻿using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Common.Mappings;

public  interface IMapWith<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T),GetType());
}
