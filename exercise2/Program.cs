using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Name: David Piatt
 * Date: 02/06/2021
 * Remarks: This was fun! 
 */

namespace exercise2
{
    class Program
    {
        static double HeightMetersSquared(int height)
        {
            double heightMetersSquared = 0;
            //meters = inches * 0.0254
            heightMetersSquared = height * 0.0254;
            //now square it
            heightMetersSquared = heightMetersSquared * heightMetersSquared;
            return heightMetersSquared;
        }

        static double WeightKilograms(int weight)
        {
            double weightKilograms = 0;
            //kilos = pounds * 0.453592
            weightKilograms = weight * 0.453592;
            return weightKilograms;
        }

        static double CalculateBMI(double convertedHeight, double convertedWeight)
        {
            double bmi = 0;
            bmi = convertedWeight / convertedHeight;
            return bmi;
        }

        static String ClassifyBMI(double bmi)
        {
            String bmiClassification = "";

            if(bmi == 0)
            {
                bmiClassification = "Dead";
            } else if(bmi >0 && bmi < 18.5)
            {
                bmiClassification = "Underweight";
            }
            else if(bmi >= 18.5 && bmi < 25)
            {
                bmiClassification = "Normal Weight";
            }
            else if(bmi >= 25 && bmi < 30)
            {
                bmiClassification = "Overweight";
            }
            else if(bmi >= 30)
            {
                bmiClassification = "Obesity";
            }

            return bmiClassification;
        }

        static double CalculateKarvonen(int age, int restingHeartRate, double intensityPercent)
        {
            double ttz = 0;
            //int mhr = 220 - age;
            //int hrr = mhr - restingHeartRate;
            //double mtz = hrr * intensityPercent;
            //ttz = mtz + restingHeartRate;
            ttz = ((((220 - age) - restingHeartRate) * intensityPercent) + restingHeartRate);
            return ttz;
        }

        static void Main(string[] args)
        {
            //Greet user
            Console.WriteLine("BMI and Karovonen Calculator");

            Console.WriteLine("Please enter the following values for the user . . . ");

            //Get height in inches
            Console.WriteLine("Height in inches: ");
            String heightString = Console.ReadLine();
            int height = Convert.ToInt32(heightString);

            //Get weight in pounds
            Console.WriteLine("Weight in pounds: ");
            String weightString = Console.ReadLine();
            int weight = Convert.ToInt32(weightString);

            //Convert height to m^2
            double convertedHeight = HeightMetersSquared(height);

            //Convert weight to kilos
            double convertedWeight = WeightKilograms(weight);

            //Calculate BMI
            double calculatedBMI = CalculateBMI(convertedHeight, convertedWeight);

            //Classify BMI
            String bmiClassification = ClassifyBMI(calculatedBMI);

            //get age
            Console.WriteLine("Age: ");
            String ageString = Console.ReadLine();
            int age = Convert.ToInt32(ageString);

            //get resting heart rate
            Console.WriteLine("Resting heart rate: ");
            String restingHeartRateString = Console.ReadLine();
            int restingHeartRate = Convert.ToInt32(restingHeartRateString);

            Console.WriteLine("Results . . . ");

            Console.WriteLine("Your BMI is: {0:N2} -- {1}", calculatedBMI, bmiClassification);

            Console.WriteLine("Exercise Intensity Heart Rates: ");
            Console.WriteLine("Intensity \t Max heart Rate");
            
            for(double i = .5; i<1; i+= 0.05)
            {
                double karvonen = CalculateKarvonen(age, restingHeartRate, i);
                Console.WriteLine("{0} \t -- \t {1}", i.ToString("P0"), karvonen);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to end the program.");
            Console.ReadLine();
        }
    }
}
