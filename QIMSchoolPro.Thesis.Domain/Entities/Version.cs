using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class Version : AuditableAutoEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        //public Document Document { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Index { get; set; }
        

        public Version() 
        {
        }

        public Version(int documentId, string name, string path, int index)
        {
          DocumentId = documentId;
          Name= name;
          Path = path;
          Index= index;
        }

        public static Version Create(int documentId, string name, string path, int index)
        {
            return new Version(
                documentId, name, path, index
            );
        }
    }
}
