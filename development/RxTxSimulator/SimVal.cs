namespace RxTxSimulator
{
    /// <summary>
    /// Diese KLasse hält die Daten der Simulation.
    /// </summary>
    public class SimVal
    {
        public enum SimStyles
        {
            NONE,
            INTEGER,
            COORD,
            STRING,
            Date,
            TIME
        };

        /// <summary>
        /// Anzahl der aktuell möglichen Displayarten.
        /// </summary>
        public const int MAX_SIM_TYPES = 100;

        public int Pos { get; set; }
        public int Value { get; set; }
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
        public int Speed { get; set; }
        public string Text { get; set; }
        public SimStyles Style { get; set; }

        public int CurrValue { get; set; }

        /// <summary>
        /// Konstrukor.
        /// </summary>
        public SimVal()
        {
            Pos = 0;
            Value = 0;
            RangeMin = 0;
            RangeMax = 0;
            Speed = 0;
            Text = "";
            Style = SimStyles.NONE;
        }


        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SimVal(int _Pos, int _Value, int _RangeMin, int _RangeMax, int _Speed, string _Text, SimStyles _Style)
        {
            Pos = _Pos;
            Value= _Value;
            RangeMin = _RangeMin;
            RangeMax = _RangeMax;
            Speed = _Speed;
            Text = _Text;
            Style = _Style;
        }

        /// <summary>
        /// Copy Konstruktor. 
        /// </summary>
        /// <param name="previous">Die vorhergehenden Daten.</param>
        public SimVal(SimVal previous)
        {
            Pos = previous.Pos;
            Value = previous.Value;
            RangeMin = previous.RangeMin;
            RangeMax = previous.RangeMax;
            Speed = previous.Speed;
            Text = previous.Text;
            Style = previous.Style; 
        }

        /// <summary>
        /// Vergleichsoperator.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SimVal other)
        {
            return (this.Value == other.Value && this.Text == other.Text);
        } // Equals()
    } // class SimVal
}
