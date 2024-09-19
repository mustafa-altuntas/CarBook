using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Results.BrandResults
{
    public class GetBrandByIdQueryResult
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
