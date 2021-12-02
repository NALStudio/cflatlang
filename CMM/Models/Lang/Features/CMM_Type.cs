﻿using CMM.Models.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang.Features;

public abstract class CMM_Type<T> : LangFeature
{
    public abstract InstantiationType Instantiation { get; }

    public abstract TypeBehaviour Behaviour { get; }

    public abstract Dictionary<string, Func<CMM_Type<T>, CMM_Type<T>, CMM_Type<T>>> OperatorImplementations { get; }


    public bool Nullable { get; set; }


    public abstract CMM_Type<T> CreateNew(params Argument[] arguments);
}
