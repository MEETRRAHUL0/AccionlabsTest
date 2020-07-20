using System;

namespace accionlabsTest
{
    public static class Test2_payment_gateways_integrated
    {
        //2) Create a sample application. We have an eCommerce application and 
        //we have 2 payment gateways integrated with our application. 
        //Let's call these payment gateways as BankOne and BankTwo.

        //The BankOne charges 2% on credit cards if the order is less that 50 USD 
        //and 1% if it is more than 50 USD.
        //BankTwo on the other hand charges flat 1.5% for all the amounts.

        //So our payment module presents the user with three options as:
        // BankOne
        // BankTwo
        // Best for me

        //bank type => BankOne , BankTwo  , Best for me
        //bank  charge =>  2% < 50 USD > 1% ,   1.5% flat
        //Amount =>  50 USD

        // factory pattan to call bank
        // 

        public static void Start()
        {
            Console.WriteLine("Total amount");
            var amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Total amount");
            Console.WriteLine("1) BankOne ");
            Console.WriteLine("2) BankTwo ");
            Console.WriteLine("3) Best for me");

            var bankType = Convert.ToInt32( Console.ReadLine());

            var Result = BankFactory(amount, bankType);

            Console.WriteLine(Result);
            Console.ReadLine();
        }

        private static double BankFactory(int amount, int bankType)
        {
            IBank[] randomBank = new IBank[2];
            randomBank[0] = new BankOne();
            randomBank[1] = new BankTwo();

            Random random = new Random();
            var pick = random.Next(3);
            IBank bank = null;


            switch (bankType)
            {
                case 1:
                    bank = new BankOne();
                    break;
                case 2:
                    bank = new BankTwo();
                    break;
                default:
                    bank = randomBank[pick-1]; 
                    break;
            }

            return bank.GetCharge(amount);
        }
    }

    //public class BestOfAllBank : IBank
    //{
    //    readonly IBank[] randomBank = new IBank[2];
    //    Random random = new Random();

    //    public BestOfAllBank()
    //    {
    //        randomBank[0] = new BankOne();
    //        randomBank[1] = new BankTwo();
    //    }

    //    public BestOfAllBank GetInstance(int Amount)
    //    {
    //        var pick = random.Next(1, 2);
    //        return randomBank[pick - 1];
    //    }
    //}

    //public class BankRequest
    //{
    //    public Func<string> Condition { get; set; }
    //    public int Amount { get; set; }
    //    public int Percentage { get; set; }
    //}
    public abstract class IBank
    {
       public virtual double GetCharge(int Amount)
        {
            return Amount * 0.01;
        }
        
    }
    public class BankOne : IBank
    {
        public override double GetCharge(int Amount)
        {
            //bank  charge =>  2% < 50 USD > 1%  
            return (Amount >= 50) ? Amount * 0.01 : Amount * 0.02;

        }
    }
    public class BankTwo : IBank
    {
        public override double GetCharge(int Amount)
        {
            //1.5% flat
            return Amount * 0.015;
        }
    }

}
