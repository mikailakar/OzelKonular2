using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ok2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            encryptd.ReadOnly = true;
            decryptd.ReadOnly = true;
        }

        string lastkey;
        string lastinput2;

        private void input_TextChanged(object sender, EventArgs e) {
            try {
                updsif();
            } catch (Exception ex) {
            }
        }

        private void input2_TextChanged(object sender, EventArgs e) {
            try {
                upddes();
            } catch (Exception ex) {
                if (input2.Text != "") { input2.Text = lastinput2;}
            }
            lastinput2 = input2.Text;
        }

        private void key_TextChanged(object sender, EventArgs e) {
            try {
                updsif();
                upddes();
            } catch (Exception ex) {
                if (key.Text != "") {key.Text = lastkey;}       
            }
            if(key.Text.Select(x => Convert.ToInt32(x.ToString())).ToList().Count > 7) {key.Text = lastkey;}
            lastkey = key.Text;
        }

        private void updsif() {
            mapmaker(Convert.ToInt32(key.Text));
            List<int> encryptedd = encrypt(input.Text);
            encryptd.Text = string.Join("", encryptedd);
        }

        private void upddes() {
            mapmaker(Convert.ToInt32(key.Text));
            List<char> decryptedd = decrypt(input2.Text.Select(x => Convert.ToInt32(x.ToString())).ToList());
            decryptd.Text = string.Join("", decryptedd);
        }

        private void input2_Click(object sender, EventArgs e) {
            input2.Text = encryptd.Text;
        }

        int x, y, z;
        int xSize = 4, ySize = 3, zSize = 3, keySize = 7;
        char[] kar = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'i', 'ı', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'q', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'w', 'x', 'y', 'z', '.', ',', ' ' };
        char[][][] c0 = new char[][][] { new char[][] { new char[] { '0', '0', '0', '0' }, new char[] { '0', '0', '0', '0' }, new char[] { '0', '0', '0', '0' } }, new char[][] { new char[] { '0', '0', '0', '0' }, new char[] { '0', '0', '0', '0' }, new char[] { '0', '0', '0', '0' } }, new char[][] { new char[] { '0', '0', '0', '0' }, new char[] { '0', '0', '0', '0' }, new char[] { '0', '0', '0', '0' } } };

        private void reset() {
            x = 0;
            y = 0;
            z = 0;
            foreach (char[][] ch0 in c0) {
                foreach (char[] ch1 in ch0) {
                    int ccount = 0;
                    foreach (char ch2 in ch1) {
                        ch1[ccount] = '0';
                        ccount++;
                    }
                }
            }
        }

        private void mapmaker(int key) {
            reset();
            int l = 0;
            foreach (char a in kar) {
                x = xyz(key, l, 0);
                y = xyz(key, l, 1);
                z = xyz(key, l, 2);

                x = x % xSize;
                y = y % ySize;
                z = z % zSize;

                l++;

                put(a, x, y, z, 0, 0);
            }
        }

        private int xyz(int key, int tour, int ind) {
            int xr1 = key / 1000000;
            int xr2 = key / 100000 - xr1 * 10;
            int xr3 = key / 10000 - xr1 * 100 - xr2 * 10;
            int xr4 = key / 1000 - xr1 * 1000 - xr2 * 100 - xr3 * 10;
            int xr5 = key / 100 - xr1 * 10000 - xr2 * 1000 - xr3 * 100 - xr4 * 10;
            int xr6 = key / 10 - xr1 * 100000 - xr2 * 10000 - xr3 * 1000 - xr4 * 100 - xr5 * 10;
            int xr7 = key - xr1 * 1000000 - xr2 * 100000 - xr3 * 10000 - xr4 * 1000 - xr5 * 100 - xr6 * 10;

            int lt = 0;
            for (int xt = 1; xt <= keySize - 2; xt++) {
                for (int yt = xt+1; yt <= keySize - 1; yt++) {
                    for (int zt = yt+1; zt <= keySize; zt++) {
                        if (lt == tour) {
                            if (ind == 0) {
                                switch (xt) {
                                    case 1:
                                        return xr1;
                                    case 2:
                                        return xr2;
                                    case 3:
                                        return xr3;
                                    case 4:
                                        return xr4;
                                    case 5:
                                        return xr5;
                                }
                            } else if (ind == 1) {
                                switch (yt) {
                                    case 2:
                                        return xr2;
                                    case 3:
                                        return xr3;
                                    case 4:
                                        return xr4;
                                    case 5:
                                        return xr5;
                                    case 6:
                                        return xr6;
                                }
                            } else if (ind == 2) {
                                switch (zt) {
                                    case 3:
                                        return xr3;
                                    case 4:
                                        return xr4;
                                    case 5:
                                        return xr5;
                                    case 6:
                                        return xr6;
                                    case 7:
                                        return xr7;
                                }
                            }
                        }
                        lt++;
                    }
                }
            }
            return 0;
        }

        private void put(char a, int x3, int y3, int z3, int t, int t2) {
            if (c0[z3][y3][x3] == '0') {
                c0[z3][y3][x3] = a;
            } else {
                int t3 = 0;
                int t4 = 0;
                if (t2 == 0) {
                    if (t < 3) {
                        t3 = t + 1;
                        t4 = t2;
                        x3 = (x3 + 1) % xSize;
                    } else {
                        t3 = 0;
                        t4 = t2 + 1;
                        x3 = (x3 + 1) % xSize;
                        y3 = (y3 + 1) % ySize;
                    }
                } else if (t2 == 1) {
                    if (t < 3) {
                        t3 = t + 1;
                        t4 = t2;
                        x3 = (x3 + 1) % xSize;
                    } else {
                        t3 = 0;
                        t4 = t2 + 1;
                        x3 = (x3 + 1) % xSize;
                        y3 = (y3 + 1) % ySize;
                    }
                } else if (t2 == 2) {
                    if (t < 3) {
                        t3 = t + 1;
                        t4 = t2;
                        x3 = (x3 + 1) % xSize;
                    } else {
                        t3 = 0;
                        t4 = 0;
                        x3 = (x3 + 1) % xSize;
                        y3 = (y3 + 1) % ySize;
                        z3 = (z3 + 1) % zSize;
                    }
                }
                put(a, x3, y3, z3, t3, t4);
            }
        }

        void printcub() {
            foreach (char[][] i in c0) {
                foreach (char[] j in i) {
                    j.ToList().ForEach(h => Console.Write(h + " "));
                    Console.Write("--- ");
                }
                Console.Write("\n");
            }
        }

        private List<int> encrypt(string entry) {
            List<int> encrypted = new List<int>();
            int lxe = 0;
            int lye = 0;
            int lze = 0;

            foreach (char cht in entry) {

                int degage = 0;

                for (int xe = 0; xe < xSize; xe++) {
                    for (int ye = 0; ye < ySize; ye++) {
                        for (int ze = 0; ze < zSize; ze++) {
                            int nxe = (lxe + xe) % xSize;
                            int nye = (lye + ye) % ySize;
                            int nze = (lze + ze) % zSize;

                            if (c0[nze][nye][nxe] == cht) {
                                encrypted.Add(xe);
                                encrypted.Add(ye);
                                encrypted.Add(ze);

                                lxe = nxe;
                                lye = nye;
                                lze = nze;

                                degage = 1;
                                break;
                            }
                        }
                        if (degage == 1) {
                            break;
                        }
                    }
                    if (degage == 1) {
                        break;
                    }
                }
            }
            return encrypted;
        }


        private List<char> decrypt(List<int> dc) {
            List<char> decrypted = new List<char>();
            int lxe = 0;
            int lye = 0;
            int lze = 0;
            for (int dt = 0; dt < dc.Count; dt += 3) {
                int dx = dc[dt];
                int dy = dx;
                int dz = dx;
                if (dt + 1 < dc.Count) {dy = dc[dt + 1];}
                if (dt + 2 < dc.Count) {dz = dc[dt + 2];}                    

                int nxe = (lxe + dx) % xSize;
                int nye = (lye + dy) % ySize;
                int nze = (lze + dz) % zSize;

                lxe = nxe;
                lye = nye;
                lze = nze;

                decrypted.Add(c0[nze][nye][nxe]);
            }
            return decrypted;
        }
    }
}
