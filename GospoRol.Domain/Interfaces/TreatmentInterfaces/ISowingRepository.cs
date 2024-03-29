﻿using System;
using System.Linq;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Interfaces.TreatmentInterfaces
{
    public interface ISowingRepository
    {
        int AddSowing(Sowing sowing);
        void DeleteSowing(int sowingId);
        void UpdateSowing(Sowing sowing);
        Sowing GetSowingById(int sowingId);
        IQueryable<Sowing> GetAllSowingsByUserId(string userId);
        Sowing GetNewestSowingDateTimeInField(int fieldId);
    }
}