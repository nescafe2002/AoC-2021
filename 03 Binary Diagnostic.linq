<Query Kind="Statements">
  <Reference Relative="03 input.txt">C:\Drive\Challenges\AoC 2021\03 input.txt</Reference>
</Query>

var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010".Split('\n');

input = File.ReadAllLines("03 input.txt");

var length = input.Length;

var bits = input.Select(x => x.Trim().ToCharArray().Select(x => (x == '1') ? 1 : 0).ToArray()).ToList();

var width = bits[0].Length;

var sum = bits.Aggregate((x, y) => Enumerable.Range(0, x.Length).Select(i => x[i] + y[i]).ToArray()).Select(x => x * 2 > length).ToList();

var a = Enumerable.Range(0, bits[0].Length).Where(x => sum[x]).Sum(x => Math.Pow(2, width - x - 1)).Dump();
var b = Enumerable.Range(0, bits[0].Length).Where(x => !sum[x]).Sum(x => Math.Pow(2, width - x - 1)).Dump();

(a * b).Dump();

(2539 * 709).Dump("Answer 2");

for (int i = 0; i < width; i++)
{
  var count = bits.Sum(x => x[i]);
  bits.RemoveAll(x => x[i] == ((count * 2 >= bits.Count) ? 0 : 1));
  //bits.Select(x => string.Join("", x)).Dump();
  if (bits.Count == 1)
  {
    Enumerable.Range(0, bits[0].Length).Where(x => bits[0][x] == 1).Sum(x => Math.Pow(2, width - x - 1)).Dump();
    return;
  }
}