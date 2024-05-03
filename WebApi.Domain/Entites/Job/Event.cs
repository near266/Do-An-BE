using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Entites.Job
{
    public class Event : BaseEntity
    {
        public string? title {  get; set; }
        public string? description { get; set; }
        public string? img {  get; set; }   
        public string? adrress { get; set; }
        public string? author {  get; set; }
        public int? priority { get; set; }
    }
}
