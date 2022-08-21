using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Mans");
            algorithm = new MansScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Woman");
            algorithm = new WomanScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildrensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));
            Console.ReadLine();
        }
    }
    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits/*vuruş*/,TimeSpan time)//template method
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);//puan kırma
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);

        public abstract int CalculateReduction(TimeSpan time);

        public abstract int CalculateBaseScore(int hits);
    }
    class MansScoringAlgorithm : ScoringAlgorithm//erkeklere göre hesaplama yöntemi
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100; 
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return Convert.ToInt32(time.TotalSeconds / 5);
        }
    }
    class WomanScoringAlgorithm : ScoringAlgorithm//erkeklere göre hesaplama yöntemi
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return Convert.ToInt32(time.TotalSeconds / 3);
        }
    }
    class ChildrensScoringAlgorithm : ScoringAlgorithm//erkeklere göre hesaplama yöntemi
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return Convert.ToInt32(time.TotalSeconds / 2);
        }
    }
}
