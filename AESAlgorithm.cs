﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SecurityLibrary
{
    class AESAlgorithm
    {
        byte[,] SBox;
        byte[,] InvSBox;
        byte[,] MulMatrix;
        Dictionary<char, int> Index;

        public AESAlgorithm()
        {
            LoadSBox();
            LoadMulMatrix();
            LoadInvSBox();

        }

        public string Encrypt(string Message, string OriginalKey)
        {
            string[,] state = GenerateTable(Message);
            string[,] Key = GenerateTable(OriginalKey);
            state = addRoundKey(state, Key);
            for (int i = 1; i < 10; ++i)
            {
               Key= KeyExpansion(Key, i-1);
                state=SubBytes(state);
                state=ShiftRows(state);
                state = MixColumn(state);
                state = addRoundKey(state, Key);
                // state = addRoundKey(MixColumn(ShiftRows(SubBytes(state))), Key);
            }
            Key = KeyExpansion(Key, 9);
            state = SubBytes(state);
            state = ShiftRows(state);
            state = addRoundKey(state,Key);
            return "0x" + GetMessage(state);
        }
        private string[,] SubBytes(string[,] state)
        {
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {

                    int ni = Index[state[i, j].ToUpper()[0]];
                    int nj = Index[state[i, j].ToUpper()[1]];
                    byte tmp = SBox[ni, nj];
                    state[i, j] = String.Format("{0:X}", tmp);
                }


            return state;
        }
        private string[,] INVSubBytes(string[,] state)
        {
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {

                    int ni = Index[state[i, j].ToUpper()[0]];
                    int nj = Index[state[i, j].ToUpper()[1]];
                    byte tmp = InvSBox[ni, nj];
                    state[i, j] = String.Format("{0:X}", tmp);
                }


            return state;
        }

        public string[,] KeyExpansion(string [,]OldKey,int round)
        {
            string[,] NewKey = new string[4,4];
            string[] col = new string[4];
            for (int o = 0; o < 4; ++o)
                col[o] = OldKey[o, 3];

          ///  rotate
            string tmp = col[0];
            for (int i = 1; i < 4; ++i)
                col[i - 1] = col[i];
            col[3] = tmp;
            /////subbyte for last column
            for (int j = 0; j < 4; ++j)
            {

                int ni = Index[col[j].ToUpper()[0]];
                int nj = Index[col[j].ToUpper()[1]];
                byte tmp1 = SBox[ni, nj];
                col[ j] = String.Format("{0:X}", tmp1);
                if (col[j].Length == 1)
                    col[j] = "0" + col[j];
            }

            for(int p=0;p<4;++p)
            {
                NewKey[p, 0] = String.Format("{0:X}", Convert.ToByte(OldKey[p, 0],16) ^Convert.ToByte( col[p],16) ^MulMatrix[round,p]);
                if (NewKey[p,0].Length == 1)
                    NewKey[p,0] = "0" + NewKey[p,0];
            }
            for(int i=1;i<4;++i)
                for(int j=0;j<4;++j)
                {
                    NewKey[j,i] = String.Format("{0:X}", Convert.ToByte(OldKey[j, i], 16) ^ Convert.ToByte(NewKey[j, i-1], 16) );
                    if (NewKey[j,i].Length == 1)
                        NewKey[j,i] = "0" + NewKey[j,i];
                }

            return NewKey;
        }
        private string[,] ShiftOneRow(string[,] state, int i)
        {
            for (int x = 0; x < i; ++x)
            {
                string tmp = state[i, 0];
                for (int j = 1; j < 4; ++j)
                {
                    state[i, j - 1] = state[i, j];
                }
                state[i, 3] = tmp;
            }
            return state;
        }
        private string[,] InvShiftOneRow(string[,] state, int i)
        {
            for (int x = 0; x < i; ++x)
            {
                string tmp = state[i, 3];
                for (int j = 2; j >=0; --j)
                {
                    state[i, j+1 ] = state[i, j];
                }
                state[i, 0] = tmp;
            }
            return state;
        }
        public string[,] ShiftRows(string[,] state)
        {

            for (int i = 1; i < 4; ++i)
            {
                state = ShiftOneRow(state, i);
            }
            return state;
        }
        public string[,] InvShiftRows(string[,] state)
        {

            for (int i = 1; i < 4; ++i)
            {
                state = InvShiftOneRow(state, i);
            }
            return state;
        }
        private string[,] MixColumn(string[,]state)
        {


            /*
             0100101010110
             *
             0000010000001
             ---------------------
             0000100000010
             xor m3 elly fo2
               else 
               010000110
               *
               100000010
 
             */

            byte[,] s = ConvertStateToByte(state);
            for (int c = 0; c < 4; c++)
            {
                state[0, c] = String.Format("{0:X}", (Byte)(GMul(0x02, s[0, c]) ^ GMul(0x03, s[1, c]) ^ GMul(0x01,s[2, c]) ^GMul(0x01, s[3, c])));
                if (state[0, c].Length == 1)
                    state[0, c] = "0"+state[0, c];
                state[1, c] = String.Format("{0:X}", (Byte)(GMul(0x01,s[0, c]) ^ GMul(0x02, s[1, c]) ^ GMul(0x03, s[2, c]) ^GMul(0x01, s[3, c])));
                if (state[1, c].Length == 1)
                    state[1, c] ="0"+ state[1, c];
                state[2, c] = String.Format("{0:X}", (Byte)(GMul(0x01,s[0, c]) ^ GMul(0x01,s[1, c]) ^ GMul(0x02, s[2, c]) ^ GMul(0x03, s[3, c])));
                if (state[2, c].Length == 1)
                    state[2, c] = "0" + state[2, c];
                state[3, c] = String.Format("{0:X}", (Byte)(GMul(0x03, s[0, c]) ^ GMul(0x01,s[1, c]) ^ GMul(0x01,s[2, c]) ^ GMul(0x02, s[3, c])));
                if (state[3, c].Length == 1)
                    state[3, c] = "0" + state[3, c];
            }
            return state;
        }

        private string[,] INVMixColumn(string[,] state)
        {


            /*
             0100101010110
             *
             0000010000001
             ---------------------
             0000100000010
             xor m3 elly fo2
               else 
               010000110
               *
               100000010
 
             */

            byte[,] s = ConvertStateToByte(state);
            for (int c = 0; c < 4; c++)
            {
                state[0, c] = String.Format("{0:X}", (Byte)(GMul(0x0e, s[0, c]) ^ GMul(0x0b, s[1, c]) ^ GMul(0x0d, s[2, c]) ^ GMul(0x09, s[3, c])));
                if (state[0, c].Length == 1)
                    state[0, c] = "0" + state[0, c];
                state[1, c] = String.Format("{0:X}", (Byte)(GMul(0x09, s[0, c]) ^ GMul(0x0e, s[1, c]) ^ GMul(0x0b, s[2, c]) ^ GMul(0x0d, s[3, c])));
                if (state[1, c].Length == 1)
                    state[1, c] = "0" + state[1, c];
                state[2, c] = String.Format("{0:X}", (Byte)(GMul(0x0d, s[0, c]) ^ GMul(0x09, s[1, c]) ^ GMul(0x0e, s[2, c]) ^ GMul(0x0b, s[3, c])));
                if (state[2, c].Length == 1)
                    state[2, c] = "0" + state[2, c];
                state[3, c] = String.Format("{0:X}", (Byte)(GMul(0x0b, s[0, c]) ^ GMul(0x0d, s[1, c]) ^ GMul(0x09, s[2, c]) ^ GMul(0x0e, s[3, c])));
                if (state[3, c].Length == 1)
                    state[3, c] = "0" + state[3, c];
            }
            return state;
        }
        private byte[,] ConvertStateToByte(string[,] state)
        {
            byte[,] tmp = new byte[4, 4];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                    tmp[i, j] = Convert.ToByte(state[i, j], 16);
            return tmp;
        }
        Byte GMul(Byte a, Byte b)
        {
            Byte p = 0;
            Byte counter;
            Byte hi_bit_set;
            for (counter = 0; counter < 8; counter++)
            {
                if ((b & 1) != 0)
                {
                    p ^= a;
                }
                hi_bit_set = (Byte)(a & 0x80);
                //10000000
                a <<= 1;
                /// a if (MSB==1)
                if (hi_bit_set != 0)
                {
                    a ^= 0x1b; /* x^8 + x^4 + x^3 + x + 1 
                    0001 1011
                     */
                }
                b >>= 1;
            }
            return p;
        }
        public string[,] addRoundKey(string[,] state, string[,] cipherKeyarr)
        {
            string[,] Tmmp = new string[4, 4];
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 4; j++)
                {
                    int tmp = Convert.ToByte(state[i, j], 16) ^ Convert.ToByte(cipherKeyarr[i, j], 16);
                    ////// check
                    Tmmp[i, j] = Convert.ToString(tmp, 16);
                    if (Tmmp[i, j].Length == 1)
                    {
                        Tmmp[i, j] = "0"+ Tmmp[i, j];
                    }
                }
            }
            return Tmmp;
        }
        public string Decrypt(string Message, string OriginalKey)
        {
            string[,] state = GenerateTable(Message);
            string[,] Key = GenerateTable(OriginalKey);
            //////Generate Keys
            List<string[,]> Keys = new List<string[,]>();
           Keys.Add(Key);
            int count = 1;
            for (int i = 1; i <= 10; ++i)
            {
                Key = KeyExpansion(Key, i-1);
                Keys.Add(Key);
                ++count;
            }
            /////decrypt
           state= addRoundKey(state, Keys[count-1]);
            --count;
            for(int i=9;i>=1;--i)
            {
               state= InvShiftRows(state);
                state = INVSubBytes(state);
                state = addRoundKey(state, Keys[count-1]);
                --count;
                
                state = INVMixColumn(state);

            }
           state= InvShiftRows(state);
            state = INVSubBytes(state);
            state = addRoundKey(state,Keys[count-1]);
            --count;

            return "0x" + GetMessage(state);
        }
        private string[,] GenerateTable(string Message)
        {
            string[,] table = new string[4, 4];
            int index = 2;
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j, ++index)
                {
                    table[j, i] += Message[index];
                    ++index;
                    table[j, i] += Message[index];
                }
            return table;
        }
        private string GetMessage(string[,] table)
        {
            string Message = "";
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                    Message += table[j, i];

            return Message;
        }
        void LoadSBox()
        {
            Index = new Dictionary<char, int>();
            Index.Add('0', 0);
            Index.Add('1', 1);
            Index.Add('2', 2);
            Index.Add('3', 3);
            Index.Add('4', 4);
            Index.Add('5', 5);
            Index.Add('6', 6);
            Index.Add('7', 7);
            Index.Add('8', 8);
            Index.Add('9', 9);
            Index.Add('A', 10);
            Index.Add('B', 11);
            Index.Add('C', 12);
            Index.Add('D', 13);
            Index.Add('E', 14);
            Index.Add('F', 15);
            SBox = new byte[,]     /*0*/  {
           {0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76},
    /*1*/  {0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0},
    /*2*/  {0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15},
    /*3*/  {0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75},
    /*4*/  {0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84},
    /*5*/  {0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf},
    /*6*/  {0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8},
    /*7*/  {0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2},
    /*8*/  {0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73},
    /*9*/  {0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb},
    /*a*/  {0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79},
    /*b*/  {0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08},
    /*c*/  {0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a},
    /*d*/  {0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e},
    /*e*/  {0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf},
    /*f*/  {0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16} };
        }

        void LoadInvSBox()
        {

            InvSBox = new byte[,]   {
           {0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb},
    /*1*/  {0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb},
    /*2*/  {0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e},
    /*3*/  {0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25},
    /*4*/  {0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92},
    /*5*/  {0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84},
    /*6*/  {0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06},
    /*7*/  {0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b},
    /*8*/  {0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73},
    /*9*/  {0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e},
    /*a*/  {0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b},
    /*b*/  {0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4},
    /*c*/  {0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f},
    /*d*/  {0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef},
    /*e*/  {0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61},
    /*f*/  {0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d} };
        }

        void LoadMulMatrix()
        {
            MulMatrix = new byte[10, 4] {
                                   {0x01, 0x00, 0x00, 0x00},
                                   {0x02, 0x00, 0x00, 0x00},
                                   {0x04, 0x00, 0x00, 0x00},
                                   {0x08, 0x00, 0x00, 0x00},
                                   {0x10, 0x00, 0x00, 0x00},
                                   {0x20, 0x00, 0x00, 0x00},
                                   {0x40, 0x00, 0x00, 0x00},
                                   {0x80, 0x00, 0x00, 0x00},
                                   {0x1b, 0x00, 0x00, 0x00},
                                   {0x36, 0x00, 0x00, 0x00} };
        }
    }

}
