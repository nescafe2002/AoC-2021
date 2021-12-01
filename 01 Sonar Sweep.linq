<Query Kind="Statements">
  <Reference Relative="01 input.txt">C:\Drive\Challenges\AoC 2021\01 input.txt</Reference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = new[] {
  199,
  200,
  208,
  210,
  200,
  207,
  240,
  269,
  260,
  263,
};

input = File.ReadAllLines("01 input.txt").Select(int.Parse).ToArray();

// How many measurements are larger than the previous measurement?

int CountIncreasing(IEnumerable<int> value) => value.Window(2).Count(x => x.ElementAt(1) > x.ElementAt(0));

var answer1 = CountIncreasing(input).Dump("Answer 1");

// How many sums are larger than the previous sum?

var answer2 = CountIncreasing(input.Window(3).Select(x => x.Sum())).Dump("Answer 2");