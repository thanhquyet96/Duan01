using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EPS.TSC.Service.Profiles
{
    public class UpperUnderscoreNamingConvention : INamingConvention
    {
        public Regex SplittingExpression { get; } = new Regex(@"[\p{Lu}0-9]+(?=_?)");

        public string SeparatorCharacter { get { return "_"; } }

        public string ReplaceValue(Match match) => match.Value[0].ToString().ToUpper() + match.Value.Substring(1);
    }
}
