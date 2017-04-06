using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Transport 
{
    class load_trailer_String
    {
        private String vehiclenumber;
        public String venum
        {
            get { return vehiclenumber; }
            set { vehiclenumber = value; }


        }
        private String tripnumber;
        public String tripnum
        {
            get { return tripnumber; }
            set { tripnumber = value; }


        }
        private String driverid;
        public String driid
        {
            get { return driverid; }
            set { driverid = value; }


        }
        private String from;
        public String frm
        {
            get { return from; }
            set { from = value; }


        }
        private String to;
        public String too
        {
            get { return to; }
            set { to = value; }


        }
        private String startingkm;
        public String startkm
        {
            get { return startingkm; }
            set { startingkm = value; }


        }
        private string challon;
        public string chaln
        {
            get { return challon; }
            set { challon = value; }
        }
        private String loadadvance;
        public String ldadv
        {
            get { return loadadvance; }
            set { loadadvance = value; }


        }
        private String driveradvance;
        public String driadv
        {
            get { return driveradvance; }
            set { driveradvance = value; }



        }
        private String tripadvance;
        public String tripadv
        {
            get { return tripadvance; }
            set { tripadvance = value; }
        }
        private String freight;
        public String frght
        {
            get { return freight; }
            set { freight = value; }


        }
        private String clinername;
        public String clname
        {
            get { return clinername; }
            set { clinername = value; }


        }
        private String loadname;
        public String ldname
        {
            get { return loadname; }
            set { loadname = value; }


        }
        private String weight;
        public String wght
        {
            get { return weight; }
            set { weight = value; }


        }
        private String endingkm;
        public String endkm
        {
            get { return endingkm; }
            set { endingkm = value; }


        }
        private String unloadweight;
        public String unloadwght
        {
            get { return unloadweight; }
            set { unloadweight = value; }


        }
        private String payment;
        public String pay
        {
            get { return payment; }
            set { payment = value; }
        }
        private String driverpayment;
        public String dripay
        {
            get { return driverpayment; }
            set { driverpayment = value; }


        }
        private String clinerpayment;
        public String clipay
        {
            get { return clinerpayment; }
            set { clinerpayment = value; }


        }
        private String commision;
        public String commi
        {
            get { return commision; }
            set { commision = value; }


        }
        private String freightreduction;
        public String frghtred
        {
            get { return freightreduction; }
            set { freightreduction = value; }


        }
        private String cardid;
        public String Card_Id
        {
            get { return cardid; }
            set { cardid = value; }
        }
        private String fillplace;
        public String Place
        {
            get { return fillplace; }
            set { fillplace = value; }
        }
        private String diesellitter;
        public String Litter
        {
            get { return diesellitter; }
            set { diesellitter = value; }
        }
        private String dieselprice;
        public String Price
        {
            get { return dieselprice; }
            set { dieselprice = value; }
        }
        private String otherwages;
        public String Load_Wages
        {
            get { return otherwages; }
            set { otherwages = value; }
        }
        private String unloadwages;
        public String Unload_Wages
        {
            get { return unloadwages; }
            set { unloadwages = value; }
        }
        private String phone;
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public String spares;
        public String Spares
        {
            get { return spares; }
            set { spares = value; }
        }
        public String perdriver;
        public String Driver_Wages
        {
            get { return perdriver; }
            set { perdriver = value; }
        }
        private String percliner;
        public String Clener_Wages
        {
            get { return percliner; }
            set { percliner = value; }

        }
        private String place;
        public String Toll_Place
        {
            get { return place;}
            set { place = value; }
        }
        private String amount;
        public String Toll_Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private String tollplace;
        public String Rto_Place
        {
            get { return tollplace; }
            set { tollplace = value; }
        }
        private String tollamount;
        public String rto_amount
        {
            get { return tollamount; }
            set { tollamount = value; }
        }
        private string total;
        public string Other_Reason
        {
            get { return total; }
            set { total = value; }
        }
        private string otheramount;
        public string Other_Amount
        {
            get { return otheramount; }
            set { otheramount = value; }
        }
        private string driverbalance;
        public string Driver_Balance
        {
            get { return driverbalance; }
            set { driverbalance = value; }
        }
        private string load_upd_litter;
        public string Load_Update_Litter
        {
            get { return load_upd_litter; }
            set { load_upd_litter = value; }
        }
        private string load_up_amnt;
        public string Load_Update_Amount
        {
            get { return load_up_amnt; }
            set { load_up_amnt = value; }
        }
        private string load_up_price;
        public string Load_Update_Price
        {
            get { return load_up_price; }
            set { load_up_price = value; }
        }
        private string load_up_lwages;
        public string Load_Update_Lwages
        {
            get { return load_up_lwages; }
            set { load_up_lwages = value; }
        }
        private string load_up_uwages;
        public string Load_Update_Uwages
        {
            get { return load_up_uwages; }
            set { load_up_uwages = value; }
        }
        private string load_up_phone;
        public string Load_Update_Phone
        {
            get { return load_up_phone; }
            set { load_up_phone = value; }
        }
        private string load_up_spare;
        public string Load_Update_Spare
        {
            get { return load_up_spare; }
            set { load_up_spare = value; }
        }
        private string load_up_driver;
        public string Load_Update_Driver
        {
            get { return load_up_driver; }
            set { load_up_driver = value; }
        }
        private string load_up_cliner;
        public string Load_Update_Cliner
        {
            get { return load_up_cliner; }
            set { load_up_cliner = value; }
        }

        private string load_up_tplace;
        public string Load_Update_Tplace
        {
            get { return load_up_tplace; }
            set { load_up_tplace = value; }
        }
        private string load_up_tamnt;
        public string Load_Update_Tamnt
        {
            get { return load_up_tamnt; }
            set { load_up_tamnt = value; }
        }
        private string load_up_rplace;
        public string Load_Update_Rplace
        {
            get { return load_up_rplace; }
            set { load_up_rplace = value; }
        }
        private string load_up_ramnt;
        public string Load_Update_Ramnt
        {
            get { return load_up_ramnt; }
            set { load_up_ramnt = value; }
        }
        private string load_up_oplace;
        public string Load_Update_Oplace
        {
            get { return load_up_oplace; }
            set { load_up_oplace = value; }
        }
        private string load_up_oamnt;
        public string Load_Update_Oamnt
        {
            get { return load_up_oamnt; }
            set { load_up_oamnt = value; }
        }
    }
}