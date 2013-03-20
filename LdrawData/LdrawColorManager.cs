using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

// From http://stackoverflow.com/questions/4001908/get-dictionary-key-by-using-the-dictionary-value
// Does not take account of having more than one possible key, but good enough for this task.
// probably similiar with value lookup anyway.
public static class Extensions
{
    public static bool TryGetKey<K, V>(this IDictionary<K, V> instance, V value, out K key)
    {
        foreach (var entry in instance)
        {
            if (!entry.Value.Equals(value))
            {
                continue;
            }
            key = entry.Key;
            return true;
        }
        key = default(K);
        return false;
    }
}

namespace LdrawData
{
    public class LdrawColorManager
    {
        static Dictionary<int, int> data = new Dictionary<int, int> {{ 0 , 0x5131D },
{ 1 , 0x55BF },
{ 2 , 0x257A3E },
{ 3 , 0x8F9B },
{ 4 , 0xC91A09 },
{ 5 , 0xC870A0 },
{ 6 , 0x583927 },
{ 7 , 0x9BA19D },
{ 8 , 0x6D6E5C },
{ 9 , 0xB4D2E3 },
{ 10 , 0x4B9F4A },
{ 11 , 0x55A5AF },
{ 12 , 0xF2705E },
{ 13 , 0xFC97AC },
{ 14 , 0xF2CD37 },
{ 15 , 0xFFFFFF },
{ 16 , 0x7F7F7F },
{ 17 , 0xC2DAB8 },
{ 18 , 0xFBE696 },
{ 19 , 0xE4CD9E },
{ 20 , 0xC9CAE2 },
{ 21 , 0xE0FFB0 },
{ 22 , 0x81007B },
{ 23 , 0x2032B0 },
{ 24 , 0x7F7F7F },
{ 25 , 0xFE8A18 },
{ 26 , 0x923978 },
{ 27 , 0xA5D426 },
{ 28 , 0x958A73 },
{ 29 , 0xE4ADC8 },
{ 30 , 0xAC78BA },
{ 31 , 0xE1D5ED },
{ 32 , 0x0 },
{ 33 , 0x20A0 },
{ 34 , 0x237841 },
{ 35 , 0x56E646 },
{ 36 , 0xC91A09 },
{ 37 , 0xDF6695 },
{ 38 , 0xFF800D },
{ 39 , 0xC1DFF0 },
{ 40 , 0x635F52 },
{ 41 , 0x559AB7 },
{ 42 , 0xC0FF00 },
{ 43 , 0xAEE9EF },
{ 44 , 0x96709F },
{ 45 , 0xFC97AC },
{ 46 , 0xF5CD2F },
{ 47 , 0xFCFCFC },
{ 52 , 0xA5A5CB },
{ 54 , 0xDAB000 },
{ 57 , 0xF08F1C },
{ 60 , 0x645A4C },
{ 61 , 0x6C96BF },
{ 62 , 0x3CB371 },
{ 63 , 0xAA4D8E },
{ 64 , 0x1B2A34 },
{ 65 , 0xECC935 },
{ 66 , 0xCAB000 },
{ 67 , 0xFFFFFF },
{ 68 , 0xF3CF9B },
{ 69 , 0xCD6298 },
{ 70 , 0x582A12 },
{ 71 , 0xA0A5A9 },
{ 72 , 0x6C6E68 },
{ 73 , 0x5A93DB },
{ 74 , 0x73DCA1 },
{ 75 , 0x0 },
{ 76 , 0x635F61 },
{ 77 , 0xFECCCF },
{ 78 , 0xF6D7B3 },
{ 79 , 0xFFFFFF },
{ 80 , 0xA5A9B4 },
{ 81 , 0x899B5F },
{ 82 , 0xDBAC34 },
{ 83 , 0x1A2831 },
{ 84 , 0xCC702A },
{ 85 , 0x3F3691 },
{ 86 , 0x7C503A },
{ 87 , 0x6D6E5C },
{ 89 , 0x4C61DB },
{ 92 , 0xD09168 },
{ 100 , 0xFEBABD },
{ 110 , 0x4354A3 },
{ 112 , 0x6874CA },
{ 114 , 0xDF6695 },
{ 115 , 0xC7D23C },
{ 117 , 0xFCFCFC },
{ 118 , 0xB3D7D1 },
{ 120 , 0xD9E4A7 },
{ 125 , 0xF9BA61 },
{ 129 , 0x640061 },
{ 132 , 0x0 },
{ 133 , 0x0 },
{ 134 , 0xAB6038 },
{ 135 , 0x9CA3A8 },
{ 137 , 0x5677BA },
{ 142 , 0xDCBE61 },
{ 148 , 0x575857 },
{ 150 , 0xBBBDBC },
{ 151 , 0xE6E3E0 },
{ 178 , 0xB4883E },
{ 179 , 0x898788 },
{ 183 , 0xF2F3F2 },
{ 191 , 0xF8BB3D },
{ 216 , 0xA52D0A },
{ 226 , 0xFFF03A },
{ 232 , 0x7DBFDD },
{ 256 , 0x212121 },
{ 272 , 0xA3463 },
{ 273 , 0x33B2 },
{ 288 , 0x184632 },
{ 294 , 0xBDC6AD },
{ 297 , 0xCC9C2B },
{ 308 , 0x352100 },
{ 313 , 0x3592C3 },
{ 320 , 0x720E0F },
{ 321 , 0x78BC9 },
{ 322 , 0x36AEBF },
{ 323 , 0xADC3C0 },
{ 324 , 0xC40026 },
{ 326 , 0x9B9A5A },
{ 334 , 0xBBA53D },
{ 335 , 0xD67572 },
{ 351 , 0xF785B1 },
{ 366 , 0xFA9C1C },
{ 373 , 0x845E84 },
{ 375 , 0xC1C2C1 },
{ 378 , 0xA0BCAC },
{ 379 , 0x6074A1 },
{ 383 , 0xE0E0E0 },
{ 406 , 0x1D68 },
{ 449 , 0x81007B },
{ 450 , 0xB67B50 },
{ 462 , 0xFFA70B },
{ 484 , 0xA95500 },
{ 490 , 0xD7F000 },
{ 493 , 0x656761 },
{ 494 , 0xD0D0D0 },
{ 495 , 0xAE7A59 },
{ 496 , 0xA3A2A4 },
{ 503 , 0xE6E3DA },
{ 504 , 0x898788 },
{ 511 , 0xFAFAFA }};

        // returns -1 on fail.
        static public int LdrawToRGB(int i)
        {
            int res = -1;
            data.TryGetValue(i, out res);
            return res;
        }

        //returns -1 on fail.
        static public int RGBToLdraw(int i)
        {
            int res = -1;
            data.TryGetKey(i, out res);
            return res;
        }

        static int getCloseEnoughOBJColor(int r, int g, int b)
        {
            return ( (int) (r/10) << 16) | ((int)(g/10)<<8) | ((int) (b/10)); 
        }



    }
}
