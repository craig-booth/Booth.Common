﻿using System;
using System.Linq;

namespace Booth.Common
{
    public enum RoundingRule {Round, Truncate}

    public struct ApportionedCurrencyValue
    {
        public int Units;
        public decimal Amount;
    }

    public struct ApportionedIntegerValue
    {
        public int Units;
        public int Amount;
    }

    public class DailyAmount
    {
        public Date Date;
        public decimal Amount;

        public DailyAmount()
        {
            Date = new Date();
            Amount = 0.00m;
        }

        public DailyAmount(Date date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }
    }

    public static class MathUtils
    {
        public static decimal ToCurrency(this decimal value, RoundingRule rule)
        {
            if (rule == RoundingRule.Round)
                return Math.Round(value, 2, MidpointRounding.AwayFromZero);
            else if (rule == RoundingRule.Truncate)
            {
                int cents = (int)(value * 100);

                return ((decimal)cents / 100);
            }
            else
                return Math.Round(value, 2);
        }

        public static void ApportionAmount(decimal amount, ApportionedCurrencyValue[] values)
        {
            decimal totalUnits = values.Sum(x => x.Units);

            decimal totalAmount = amount.ToCurrency(RoundingRule.Truncate);
            for (int i = 0; i < values.Length; i++)
            {
                if (totalUnits > 0)
                    values[i].Amount = (totalAmount * (values[i].Units / totalUnits)).ToCurrency(RoundingRule.Round);
                else
                    values[i].Amount = 0.00m;

                totalUnits -= values[i].Units;
                totalAmount -= values[i].Amount;
            }
        }

        public static void ApportionAmount(int amount, ApportionedIntegerValue[] values)
        {
            int totalUnits = values.Sum(x => x.Units);

            int totalAmount = amount;
            for (int i = 0; i < values.Length; i++)
            {
                if (totalUnits > 0)
                    values[i].Amount = (int)Math.Round(totalAmount * ((decimal)values[i].Units / totalUnits));
                else
                    values[i].Amount = 0;

                totalUnits -= values[i].Units;
                totalAmount -= values[i].Amount;
            }
        }

        public static int ParseInt(string value)
        {
            if (int.TryParse(value, out int result))
                return result;
            else
                return 0;
        }

        public static int ParseInt(string value, int defaultValue)
        {
            if (int.TryParse(value, out int result))
                return result;
            else
                return defaultValue;
        }

        public static decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, out decimal result))
                return result;
            else
                return 0.0m;
        }

        public static decimal ParseDecimal(string value, decimal defaultValue)
        {
            if (decimal.TryParse(value, out decimal result))
                return result;
            else
                return defaultValue;
        }

        public static string FormatCurrency(decimal value)
        {
            return value.ToString("###,##0.00###");
        }

        public static string FormatCurrency(decimal value, bool round)
        {
            if (round)
                return value.ToString("###,##0.00");  
            else
                return value.ToString("###,##0.00###");  
        }

        public static string FormatCurrency(decimal value, bool round, bool includeCurrencySymbol)
        {
            if (round)
                {
                if (includeCurrencySymbol)
                    return value.ToString("$###,##0.00");
                else
                    return value.ToString("###,##0.00");
                }
            else
            {
                if (includeCurrencySymbol)
                    return value.ToString("$###,##0.00###");
                else
                    return value.ToString("###,##0.00###");
            }
        }

    }
}
