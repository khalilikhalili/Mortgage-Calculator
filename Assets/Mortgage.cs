using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Mortgage : MonoBehaviour
{
    public InputField PurchasePrice;
    public InputField Downpayment;
    public InputField InterestRate;
    public InputField Amortization;
    public Dropdown PaymentFrequency;
    public Dropdown AmortizationPeriod;
    public Text Result;
    public Text TotalPayment;
    public Text TotalInterestPaid;

    public void MortgagePayment()
    {
        double principal = double.Parse(PurchasePrice.text) - double.Parse(Downpayment.text);

        double r = double.Parse(InterestRate.text) / 1200;
        double n = 0;
        //double n = double.Parse(Amortization.text) * 12;
        if (AmortizationPeriod.value == 0)
        {
            n = 15 * 12;
        }

        else if (AmortizationPeriod.value == 1)
        {
            n = 20 * 12;
        }

        else if (AmortizationPeriod.value == 2)
        {
            n = 25 * 12;
        }

        else if (AmortizationPeriod.value == 3)
        {
            n = 30 * 12;
        }
        double power = Math.Pow((1 + r), n);

        double m = (principal) * ((r * power) / (power - 1));
        m = Math.Round(m, 2);
        double HouseTotalPayment = m * n;
        double HouseInterestPaid = HouseTotalPayment - principal;
        TotalPayment.text = HouseTotalPayment.ToString();
        TotalInterestPaid.text = HouseInterestPaid.ToString();

        if (PaymentFrequency.value == 0)
        {
            Result.text = m.ToString();
        }
        else if (PaymentFrequency.value == 1)
        {
            Result.text = Math.Round((m / 2), 2).ToString();
        }
        else if (PaymentFrequency.value == 2)
        {
            Result.text = Math.Round((m / 4), 2).ToString();
        }

    }

    public void RefreshButton()
    {
        PurchasePrice.text = "--- --- ---";
        Downpayment.text = "--- --- ---";
        InterestRate.text = "--- --- ---";
        PaymentFrequency.value = 0;
        AmortizationPeriod.value = 0;

    }
        //double totalpayment = m * n;
        //Result.text = m.ToString();

    
    /* double principal = houseprice - downPayment;
            double r = interestRate / 1200;
            double n = termOfLoan * 12;
            double power = Math.Pow((1 + r), n);
            double m = (principal) * ((r * power) / (power - 1));
            double totalpayment = m * n;
            Console.WriteLine($"Your mountly mortgage is {Math.Round(m, 2)}.");
            Console.WriteLine($"Your total payment is {Math.Round(totalpayment,2)}");*/
}

