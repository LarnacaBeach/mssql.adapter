﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace mssql.adapter.generator.Models;

[DataContract]
public class DatabaseMeta
{
    [DataMember(Order = 1)]
    public string Name { get; set; }

    [DataMember(Order = 2)]
    public List<ProcedureMeta> Procedures { get; set; }

    public DatabaseMeta(collector.types.DatabaseMeta dbMeta)
    {
        Name = dbMeta.Name;
        Procedures = dbMeta.Procedures
            .Select(p => new ProcedureMeta(p))
            .ToList();
    }
}