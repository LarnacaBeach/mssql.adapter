﻿using System.Collections.Generic;
using System.Runtime.Serialization;


namespace mssql.adapter.generator.Models;

[DataContract]
public class ResponseItem
{
    [DataMember(Order = 1)]
    public string Name { get; set; }

    [DataMember(Order = 2)]
    public List<ParamMeta> Params { get; set; }

    [DataMember(Order = 3)]
    public int Order { get; set; }

    [DataMember(Order = 4)]
    public int ParamsMaxOrder { get; set; }

    [DataMember(Order = 5)]
    public bool IsOperationResult { get; set; }

    public ResponseItem(collector.types.ResponseItem responseItem)
    {
        Name = responseItem.Name;
        Params = responseItem.Params
            .Select(p => new ParamMeta(p))
            .ToList();
        ParamsMaxOrder = Params
            .Select(x => x.Order)
            .DefaultIfEmpty()
            .Max();
        Order = responseItem.Order;
        IsOperationResult = collector.types.Helpers.IsOperationResult(responseItem);
    }
}