
using Karma.Infrastructure.Commons;

namespace Karma.Infrastructure.Entites
{
    public class Color :BaseEntity<int>
    {
       
        public string Name { get; set; }
        public string HexCode { get; set; }


    }
}
