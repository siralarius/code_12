using System;
namespace code_12.Models
{
    public abstract class Symbol
    {
        public int   ID         { get; set; }
        public float highest    { get; set; }
        public float lowest     { get; set; }
        public float high       { get; set; }
        public float low        { get; set; }
        public DateTime reading { get; set; }
    }

    public class Bitcoin : Symbol
    {
        public Bitcoin(float ihighest, float ilowest,  float ihigh, float ilow, DateTime ireading){
            this.highest = ihighest;
            this.lowest  = ilowest;
            this.high    = ihigh;
            this.low     = ilow;
        }

        public Bitcoin(){}
    }
}
