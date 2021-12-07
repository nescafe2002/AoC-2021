<Query Kind="Statements">
  <Reference Relative="06 input.txt">C:\Drive\Challenges\AoC 2021\06 input.txt</Reference>
</Query>

var input = "3,4,3,1,2".Split(',');

input = File.ReadAllText("06 input.txt").Split(',');

var population = new long[9];

foreach (var item in input.Select(long.Parse).ToLookup(x => x))
{
  population[item.Key] = item.Count();
}

for (int round = 0; round < 256; round++)
{
  var abc = population[0];

  for (int i = 0; i <= 7; i++)
  {
    population[i] = population[i + 1];
  }

  population[6] += abc;
  population[8] = abc;
}

population.Sum().Dump("Answer 1/2");