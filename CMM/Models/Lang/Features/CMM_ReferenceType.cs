﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang.Features;

public abstract class CMM_ReferenceType<T> : CMM_Type<T>
{
    public sealed override TypeBehaviour Behaviour => TypeBehaviour.Reference;
}
