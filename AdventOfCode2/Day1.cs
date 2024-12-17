using System;
using System.Collections.Generic;

namespace AdventOfCode {
    public class Day1 {
        private List<int> lefts, rights; 
        private Dictionary<int, int> leftOccurrences, rightOccurrences;
        long distance, similarScore = 0;
        private List<string> lines;

        public Day1() {
            // AttemptI
            lefts = new List<int>();
            rights = new List<int>();
            lines = new List<string>();

            // AttemptII
            leftOccurrences = new Dictionary<int, int>();
            rightOccurrences = new Dictionary<int, int>();

            using (StreamReader sr = new StreamReader("./input/day1.txt")) {
                while (sr.Peek() >= 0) {
                    lines.Add(sr.ReadLine());
                }
            }

            foreach (string line in lines) {
                string[] curData = line.Split("   ");
                int left, right = 0 ;
                int.TryParse(curData[0], out left);
                int.TryParse(curData[1], out right);
                lefts.Add(left); rights.Add(right);
            }
        }

        public long AttemptI() {
            distance = 0;
            lefts.Sort();
            rights.Sort();

            for (int i = 0; lefts.Count() > i; i++) {
                distance += Math.Abs(lefts[i] - rights[i]);
            }
            return distance;
        }

        public long AttemptII() {
            similarScore = 0;
            foreach (int n in lefts) {
                if (!leftOccurrences.ContainsKey(n)) leftOccurrences[n] = 1;
                else leftOccurrences[n] += 1;
            }
            foreach (int n in rights) {
                if (!rightOccurrences.ContainsKey(n)) rightOccurrences[n] = 1;
                else rightOccurrences[n] += 1;
            }
            foreach (int n in leftOccurrences.Keys) {
                similarScore += n * leftOccurrences[n] * (rightOccurrences.ContainsKey(n) ? rightOccurrences[n] : 0);
            }
            return similarScore;
        }
    }
}