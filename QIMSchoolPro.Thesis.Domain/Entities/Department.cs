﻿using Qface.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class Department : AuditableAutoEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

    }
}