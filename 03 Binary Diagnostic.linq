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

int BitArrayToInt(bool[] value) => (int)Enumerable.Range(0, value.Length).Where(x => value[x]).Sum(x => Math.Pow(2, value.Length - x - 1));

var a = BitArrayToInt(sum.ToArray());
var b = BitArrayToInt(sum.Select(x => !x).ToArray());

(a * b).Dump("Answer 1");

//(2539 * 709).Dump("Answer 2");

(a, b) = (0, 0);

var bits2 = bits.ToList();

for (int i = 0; i < width; i++)
{
  var count = bits2.Sum(x => x[i]);
  bits2.RemoveAll(x => x[i] == ((count * 2 >= bits2.Count) ? 1 : 0));
  if (bits2.Count == 1)
  {
    a = BitArrayToInt(bits2[0].Select(x => bits2[0][x] == 0).ToArray());
    break;
  }
}

for (int i = 0; i < width; i++)
{
  var count = bits.Sum(x => x[i]);
  bits.RemoveAll(x => x[i] == ((count * 2 >= bits.Count) ? 0 : 1));
  if (bits.Count == 1)
  {
    b = BitArrayToInt(bits[0].Select(x => bits[0][x] == 0).ToArray());
    break;
  }
}

(a.Dump() * b.Dump()).Dump("Answer 2");