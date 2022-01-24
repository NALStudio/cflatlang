﻿using CMM.Exceptions;
using CMM.Lexing;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Language;

internal static class LanguageData
{
    private static List<CMM_Keyword>? _keywords = null;
    public static IReadOnlyList<CMM_Keyword> Keywords => _keywords ??= GetLangFeaturesOfType<CMM_Keyword>();


    private static List<CMM_Operator>? _operators = null;
    public static IReadOnlyList<CMM_Operator> Operators => _operators ??= GetLangFeaturesOfType<CMM_Operator>();


    public static bool IsDiscardName(string name)
    {
        foreach (char c in name)
        {
            if (c != ControlSequences.VariableDiscardRepeat)
                return false;
        }

        return true;
    }

    private static List<T> GetLangFeaturesOfType<T>() where T : LangFeature
    {
        Type type = typeof(T);

        List<T> instances = new();

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type t in assembly.GetTypes().Where(_t => _t.IsClass && !_t.IsAbstract && _t.IsSubclassOf(type)))
            {
                FieldInfo? nameField = t.GetField(nameof(LangFeature.Name), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                T kw = (T)(Activator.CreateInstance(t) ?? throw new CMM_Exception($"Internal Error. Could not construct object of type: {t.Name}"));
                instances.Add(kw);
            }
        }

        return instances;
    }
}
