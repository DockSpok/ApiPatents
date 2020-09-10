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
                    PatentClaims = "Nunc bibendum augue quis imperdiet tincidunt. Vivamus ut eros elementum, laoreet sem ut, vulputate arcu. " 
                    +"Pellentesque nec eleifend massa. Nam consequat, lectus vel dictum tincidunt, felis risus vehicula dui, nec consequat odio nunc a odio. " 
                    +"Ut pulvinar, nibh id sollicitudin fermentum, mi eros consectetur enim, eu condimentum nisi lectus vel tortor. Suspendisse a vulputate neque. " 
                    +"Donec semper magna nec metus rutrum, ac egestas massa venenatis. Proin gravida faucibus tortor in bibendum.",

                    PatentDate = new DateTime(1970, 01, 01),
                    DateModified = new DateTime(2020, 07, 01),
                },
                new PatentModel
                {
                    PatentId = 2,
                    PatentNumber = "ABC123456",
                    PatentTitle = "Thylenol",
                    PatentNumClaims = 3,
                    PatentClaims = "Vestibulum et lectus ultricies, vehicula leo sed, tincidunt metus. "
                    +"Integer convallis scelerisque mauris ut tristique. Praesent porta ut ipsum sit amet scelerisque. Aliquam erat volutpat." 
                    +"Vestibulum imperdiet nulla a est feugiat iaculis. Nullam imperdiet justo sed est lacinia semper. "
                    +"Mauris dignissim turpis risus, nec auctor lectus tempus eu. Donec ac arcu sagittis, molestie est quis, pretium arcu." 
                    +"Duis at neque ut felis iaculis malesuada. Morbi vel augue condimentum, tempus nisl non, hendrerit neque. "
                    +"Sed aliquet nisi et elit fermentum iaculis eu vel leo. Ut ac bibendum erat, vitae efficitur quam. "
                    +"Proin pellentesque, lacus sit amet blandit tempus, nunc est imperdiet mauris, vitae convallis urna nunc sed tellus.",
                    PatentDate = new DateTime(1980, 08, 08),
                    DateModified = new DateTime(2020, 08, 01),
                },
                new PatentModel
                {
                    PatentId = 3,
                    PatentNumber = "012012012",
                    PatentTitle = "Naldecon",
                    PatentNumClaims = 3,
                    PatentClaims = "In venenatis, libero sit amet semper ullamcorper, elit nisl auctor quam, at ultrices felis " +
                    "tortor egestas enim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." +
                    " Vestibulum orci ex, sollicitudin vitae congue id, vehicula ut arcu. Maecenas sollicitudin non nisi tristique commodo. " +
                    "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. " +
                    "Donec ac ipsum id ligula consequat posuere molestie sit amet nisl. Orci varius natoque penatibus et magnis dis parturient montes, " +
                    "nascetur ridiculus mus. Maecenas ullamcorper tempus urna, sed rhoncus neque porttitor vitae. Fusce non tellus efficitur, " +
                    "semper metus a, egestas nibh. Aliquam sed tincidunt mi. Cras luctus dignissim arcu id molestie. " +
                    "Sed efficitur feugiat erat, vitae accumsan odio accumsan et. Nulla facilisi.",
                    PatentDate = new DateTime(1990, 10, 10),
                    DateModified = new DateTime(2020, 09, 03),
                },
                                new PatentModel
                {
                    PatentId = 4,
                    PatentNumber = "5a5b5c5d5e",
                    PatentTitle = "Novalgina",
                    PatentNumClaims = 3,
                    PatentClaims = "Ut turpis sapien, feugiat ut augue id, ultricies dictum nisl. " +
                    "Proin luctus at eros non accumsan. Proin quis metus consectetur, commodo eros sed, feugiat nisl. " +
                    "Sed ligula eros, faucibus quis lacus dignissim, ultricies volutpat nunc. Nunc egestas metus diam, at ultrices nunc aliquet eu. " +
                    "Etiam facilisis sapien porttitor iaculis tempor. Integer efficitur, orci quis convallis lacinia, arcu lorem pharetra ligula, " +
                    "id laoreet mi velit sit amet ex. Quisque a placerat urna. Phasellus tincidunt et ligula non dictum. Mauris nulla dolor, posuere " +
                    "a ipsum sit amet, vehicula commodo lorem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; " +
                    "Aliquam quis pellentesque tellus.",
                    PatentDate = new DateTime(1950, 10, 10),
                    DateModified = new DateTime(2020, 02, 23),
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
