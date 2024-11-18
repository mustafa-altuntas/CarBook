using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Dtos
{
    public class TokenResponseDto
    {
        public TokenResponseDto(string toke, DateTime expireDate)
        {
            Toke = toke;
            ExpireDate = expireDate;
        }

        public string Toke { get; set; }
        public DateTime ExpireDate { get; set; }
        
    }
}
