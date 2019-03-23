using System.Collections.Generic;

namespace RxTxSimulator
{
    class SimValList : List<SimVal>
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SimValList()
        {
            // SimVal V00 = new SimVal(0, 0, 0, 0, 0,"47.765787N,05.162745W;", SimVal.SimStyles.COORD);        // GPS-Position @00:47.765787N;05.162745W;
            SimVal V01 = new SimVal(1, 212, 1, 360, 10, "", SimVal.SimStyles.INTEGER);                      // GPS Heading @01:212;
            SimVal V02 = new SimVal(2, 1, 1, 1, 0, "", SimVal.SimStyles.INTEGER);                           // GPS HDOP  @02:1.1;
            SimVal V03 = new SimVal(3, 0, 0, 0, 60, "000000", SimVal.SimStyles.TIME);                       // GPS Uhrzeit @03:220124; (== 22h01 24s)
            SimVal V04 = new SimVal(4, 0, 0, 235900, 60, "01012016", SimVal.SimStyles.Date);                // GPS Datum @04:161012; (== 12 Okt. 2016)
            SimVal V05 = new SimVal(5, 9, 0, 16, 1, "", SimVal.SimStyles.INTEGER);                          // GPS Anzahl Satelliten: @05:9;
            SimVal V06 = new SimVal(6, 12, 0, 850, 25, "", SimVal.SimStyles.INTEGER);                     // GPS Höhe über Boden: @06:12;
            SimVal V07 = new SimVal(7, 413, 0, 850, 25, "", SimVal.SimStyles.INTEGER);                    // GPS Höhe über Meer: @07:413;
            SimVal V08 = new SimVal(8, -5, -10, 10, 1, "", SimVal.SimStyles.INTEGER);                       // GPS Vario: @08:-5.12;
            SimVal V09 = new SimVal(9, -20, -20, 20, 1, "", SimVal.SimStyles.INTEGER);                      // Temperatur (vom GPS) @09:24;

            SimVal V20 = new SimVal(20, 124, 120, 140, 1, "", SimVal.SimStyles.INTEGER);                    // Turbine Akku-Spannung: @20:12.4;
            SimVal V21 = new SimVal(21, 6, 0, 10, 1, "", SimVal.SimStyles.INTEGER);                         // Turbine Status: @21:6; (oder Text-Nachricht?)
            SimVal V22 = new SimVal(22, 10500, 0, 16000, 500, "", SimVal.SimStyles.INTEGER);                // Turbine Drehzahl: @22:105000;              
            SimVal V23 = new SimVal(23, 567, 0, 999, 10, "", SimVal.SimStyles.INTEGER);                     // Turbine Temperatur @23:567;                    
            SimVal V24 = new SimVal(24, 89, 0, 100, 10, "", SimVal.SimStyles.INTEGER);                      // Turbine Gas-Stellung @24:89;
            SimVal V25 = new SimVal(25, 452, 0, 900, 50, "", SimVal.SimStyles.INTEGER);                     // Turbine Aktueller Verbrauch: @25:452; (ml/min)
            SimVal V26 = new SimVal(26, 100, 0, 100, 50, "", SimVal.SimStyles.INTEGER);                     // Turbine Tank-Füllstand in %: @26:100;
            SimVal V27 = new SimVal(27, 2567, 0, 5000, 100, "", SimVal.SimStyles.INTEGER);                  // Turbine Tank-Füllstand in ml: 27:2567;

            SimVal V40 = new SimVal(40, 12, -150, 150, 5, "", SimVal.SimStyles.INTEGER);                    // Gyro: Links-Rechts-Lage: @40:12; (0 == Horizonal, pos = nach rechts geneigt)
            SimVal V41 = new SimVal(41, 10, -150, 150, 5, "", SimVal.SimStyles.INTEGER);                    // Gyro: Vorne-Hinten-Lage @41:-10; (0 == horizontal, pos = nach vorne geneigt)
            SimVal V42 = new SimVal(42, -147, -150, 150, 5, "", SimVal.SimStyles.INTEGER);                  // Gyro: Z-Lage: @42:-147; (0 == Startstellung, pos = nach rechts gedreht)

            // SimVal V99 = new SimVal(99, 0, 0, 0, 0, "Test", SimVal.SimStyles.STRING);                       // Text-Nachricht: @99:Alles was irgendwie dargestellt werden soll;

            // this.Add(V00);
            this.Add(V01);
            this.Add(V02);
            this.Add(V03);
            this.Add(V04);
            this.Add(V05);
            this.Add(V06);
            this.Add(V07);
            this.Add(V08);
            this.Add(V09);

            this.Add(V20);
            this.Add(V21);
            this.Add(V22);
            this.Add(V23);
            this.Add(V24);
            this.Add(V25);
            this.Add(V26);
            this.Add(V27);

            this.Add(V40);
            this.Add(V41);
            this.Add(V42);

            // this.Add(V99);

        } // Kontruktor
    } // class SimValList 
}
