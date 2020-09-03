using System;
using System.Collections.Generic;

namespace ApiPatents.Models
{
    public class PatentRepository : IRepoPatent
    {
        private Dictionary<int, PatentModel> _items;

        public PatentRepository()
        {
            _items = new Dictionary<int, PatentModel>();

            new List<PatentModel>
            {
                new PatentModel {
                    PatentId = 1,
                    PatentNumber = "987654",
                    PatentTitle = "Aspirin",
                    PatentNumClaims = 3,
                    PatentClaims = new List<string> { "claim 1", "claim 2", "claim 3" },
                    PatentDate = new DateTime(1970, 01, 01),
                    DateModified = new DateTime(2020, 07, 01),
                },
                new PatentModel
                {
                    PatentId = 2,
                    PatentNumber = "ABC123456",
                    PatentTitle = "Thylenol",
                    PatentNumClaims = 3,
                    PatentClaims = new List<string> { "claim 1", "claim 2", "claim 3" },
                    PatentDate = new DateTime(1980, 08, 08),
                    DateModified = new DateTime(2020, 08, 01),
                }

            }.ForEach(pat => AddPatent(pat));
        }

        public PatentModel this[int id] => _items.ContainsKey(id) ? _items[id] : null;

        public IEnumerable<PatentModel> Patents => _items.Values;

        public PatentModel AddPatent(PatentModel patent)
        {
            if (patent.PatentId == 0)
            {
                int key = _items.Count;
                while (_items.ContainsKey(key)) { key++; };
                patent.PatentId = key;
            }
            _items[patent.PatentId] = patent;
            return patent;
        }

        public void DeletePatent(int id)
        {
            if (_items[id] != null) 
            {
                _items.Remove(id);
            }
        }

        public PatentModel UpdatePatent(PatentModel patent)
        {
            AddPatent(patent);
            return patent;
        }
    }
}
