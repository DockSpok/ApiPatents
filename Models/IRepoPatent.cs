using System;
using System.Collections.Generic;

namespace ApiPatents.Models
{
    public interface IRepoPatent
    {
        IEnumerable<PatentModel> Patents { get; }
        PatentModel this[int id] { get; }
        PatentModel AddPatent(PatentModel patent);
        PatentModel UpdatePatent(PatentModel patent);
        void DeletePatent(int id);
    }
}

