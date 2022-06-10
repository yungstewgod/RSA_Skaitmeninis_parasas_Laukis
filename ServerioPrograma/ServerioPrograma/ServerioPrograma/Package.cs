using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ServerioPrograma
{
    public class Package
    {
        BigInteger n;
        BigInteger e;
        BigInteger x;
        BigInteger s;
        String message;

        public BigInteger N { get => n; set => n = value; }
        public BigInteger E { get => e; set => e = value; }
        public BigInteger X { get => x; set => x = value; }
        public BigInteger S { get => s; set => s = value; }
        public string Message { get => message; set => message = value; }

        public Package(string message)
        {
            int q = RSA.GetRandomPrime();
            int p = RSA.GetRandomPrime();
            N = RSA.GetN(q, p);
            BigInteger phi = RSA.GetPhi(q, p);
            E = RSA.GetE(phi);
            BigInteger D = RSA.GetD(E, phi);
            X = RSA.GetRandom();
            S = RSA.GetS(X, (int)D, N);
            this.Message = message;
        }

        public Package() { }

        public void Parse(string data)
        {
            string[] lines = data.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            N = BigInteger.Parse(lines[0]);
            E = BigInteger.Parse(lines[1]);
            X = BigInteger.Parse(lines[2]);
            S = BigInteger.Parse(lines[3]);

            Message = "";
            for (int i = 4; i < lines.Length; i++)
            {
                Message += lines[i];
            }
        }

        public override string ToString()
        {
            return $"{N}" +
                   $"\n{E}" +
                   $"\n{X}" +
                   $"\n{S}" +
                   $"\n{Message}";
        }
    }
}
