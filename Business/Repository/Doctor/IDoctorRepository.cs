﻿using Business.Dto.Doctors;
using System;
using System.Collections.Generic;

namespace Business.Repository.Doctor
{
    public interface IDoctorRepository
    {
        IEnumerable<DoctorDto> GetDoctors();
        DoctorDto GetDoctor(Guid nodeGuid);
    }
}
