using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Transport
{
   public class Get_String
    { 
        //Login Panel
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //Vehicle Details
        private string _corporation;
        private string _model;
        private string _vehicle_number;
        private string _load_number;
        private string _trailer_number;
        private string _load_model;
        private string _trailer_model;
        public string Corporation
        {
            get { return _corporation; }
            set { _corporation = value; }
        }

        public string Vehicle_Number
        {
            get { return _vehicle_number; }
            set { _vehicle_number = value; }
        }
       
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Load_Number
        {
            get { return _load_number; }
            set { _load_number = value; }
        }
        public string Trailer_Number
        {
            get { return _trailer_number; }
            set { _trailer_number = value; }
        }
        public string Load_Model
        {
            get { return _load_model; }
            set { _load_model = value; }
        }
        public string Trailer_Model
        {
            get { return _trailer_model; }
            set { _trailer_model = value; }
        }
        //Vehicle Update
        private string _update_vehicle_corporation; 
        private string _update_model;
        private string _update_vehicle_number;
        private string _update_load_number;
        private string _update_trailer_number;
        private string _update_trailer_trans_name;
        private string _update_load_trans_name;
        private string _update_lod_model;
        private string _update_tlr_model;
        public string Update_Vehicle_Corporation  
        {
            get { return _update_vehicle_corporation; }
            set { _update_vehicle_corporation = value; }
        }

        public string Update_Vehicle_Number
        {
            get { return _update_vehicle_number; }
            set { _update_vehicle_number = value; }
        }

        public string Update_Model
        {
            get { return _update_model; }
            set { _update_model = value; }
        }
        public string Update_Load_Number
        {
            get { return _update_load_number; }
            set { _update_load_number = value; }
        }
        public string Update_Trailer_Number 
        {
            get { return _update_trailer_number; }
            set { _update_trailer_number = value; }
        }
        public string Update_Trailer_Trans_Name
        {
            get { return _update_trailer_trans_name; }
            set { _update_trailer_trans_name = value; }
        }
        public string Update_Load_Trans_Name
        {
            get { return _update_load_trans_name; }
            set { _update_load_trans_name = value; }
        }
        public string Up_Trailer_Model
        {
            get { return _update_tlr_model; }
            set { _update_tlr_model = value; }
        }
        public string Up_Load_Model
        {
            get { return _update_lod_model; }
            set { _update_lod_model = value; }
        }
        //Diesel card Details
        private string _card_id;
        private string _customer_id;
        private string _credit_amount;
        private string _trip_num;
        
        public string Card_Id
        {
            get { return _card_id; }
            set { _card_id = value; }
        }
        public string Customer_Id
        {
            get { return _customer_id; }
            set { _customer_id = value; }
        }
        public string Credit_Amount
        {
            get { return _credit_amount; }
            set { _credit_amount = value; }
        }  
        public string Trip_Num
        {
            get { return _trip_num; }
            set { _trip_num = value; }
        }  

        //Driver Details
        private string _driver_name;
        private string _licence_no;
        private string _address;
        private string _referer_name;
        private string _bank_name;
        private string _acc_no;
        private string _branch;
        private string _ifsc_code;
        private string _contact;
        public string Driver_Name
        {
            get { return _driver_name; }
            set { _driver_name = value; }
        }
        public string Licence_No
        {
            get { return _licence_no; }
            set { _licence_no = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        public string Referer_Name
        {
            get { return _referer_name; }
            set { _referer_name = value; }
        }
        public string Bank_Name
        {
            get { return _bank_name; }
            set { _bank_name = value; }
        }
        public string Acc_No
        {
            get { return _acc_no; }
            set { _acc_no = value; }
        }
        public string Branch
        {
            get { return _branch; }
            set { _branch = value; }
        }
        public string IFSC
        {
            get { return _ifsc_code; }
            set { _ifsc_code = value; } 
        }
        //Driver Update
        private string _update_driver_name1;
        private string _update_licence_no;
        private string _update_address;
        private string _update_referer_name;
        private string _update_bank_name;
        private string _update_acc_no;
        private string _update_branch;
        private string _update_ifsc_code;
        private string _update_contact;
        public string Update_Driver_Name1  
        {
            get { return _update_driver_name1; }
            set { _update_driver_name1 = value; }
        }
        public string Update_Licence_No
        {
            get { return _update_licence_no; }
            set { _update_licence_no = value; }
        }
        public string Update_Address
        {
            get { return _update_address; }
            set { _update_address = value; }
        }
        public string Update_Contact
        {
            get { return _update_contact; }
            set { _update_contact = value; }
        }
        public string Update_Referer_Name
        {
            get { return _update_referer_name; }
            set { _update_referer_name = value; }
        }
        public string Update_Bank_Name
        {
            get { return _update_bank_name; }
            set { _update_bank_name = value; }
        }
        public string Update_Acc_No
        {
            get { return _update_acc_no; }
            set { _update_acc_no = value; }
        }
        public string Update_Branch
        {
            get { return _update_branch; }
            set { _update_branch = value; }
        }
        public string Update_IFSC 
        {
            get { return _update_ifsc_code; }
            set { _update_ifsc_code = value; }
        }
        // Driver payment
        private string _month;
        private string _year;
        private string _expense_cost;
        private string _remarks;
        private string _remarks_amount;
        private string _salary;
        public string Month
        {
            get { return _month; }
            set { _month = value; }
        }
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public string Expense_Cost
        {
            get { return _expense_cost; }
            set { _expense_cost = value; }
        }
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        public string Remarks_Amount
        {
            get { return _remarks_amount; }
            set { _remarks_amount = value; }
        }
        public string Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }


        //Trip Details

            //Load
        private string _origin;
        private string _destination;
        private string _starting_km;
        private string _load_weight;
        private string _trip_load_number;
        private string _trip_unload_number;
        private string _trip_close_number;
       
        public string Trip_Load_Number
        {
            get { return _trip_load_number; }
            set { _trip_load_number = value; }
        }
        public string Trip_Unload_Number
        {
            get { return _trip_unload_number; }
            set { _trip_unload_number = value; }
        }
        public string Trip_Close_Number
        {
            get { return _trip_close_number; }
            set { _trip_close_number = value; }
        }

        public string Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public string Starting_km
        {
            get { return _starting_km; }
            set { _starting_km = value; }
        }
        public string Load_Weight
        {
            get { return _load_weight; }
            set { _load_weight = value; }
        }

        //Unload
        private string _end_km;
        private string _unload_weight;
        private string _place;
        private string _litter;
        private string _price;
        public string End_Km
        {
            get { return _end_km; }
            set { _end_km = value; }
        }
        public string Unload_Weight
        {
            get { return _unload_weight; }
            set { _unload_weight = value; }
        }
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }
        public string Litter
        {
            get { return _litter; }
            set { _litter = value; }
        }
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        //Closed 
        private string _fright;
        private string _advance;
        private string _load_wages;
        private string _unload_wages;
        private string _phone;
        private string _spares;
        private string _driver_wages;
        private string _clener_wages;
        private string _toll_place;
        private string _toll_amount;
        private string _rto_place;
        private string _rto_amount;
        private string _other_reason;
        private string _other_amount;
        public string Fright
        {
            get { return _fright; }
            set { _fright = value; }
        }
        public string Advance
        {
            get { return _advance; }
            set { _advance = value; }
        }
        public string Toll_Amount 
        {
            get { return _toll_amount;  }
            set { _toll_amount = value; }
        }
        public string Toll_Place
        {
            get { return _toll_place; }
            set { _toll_place = value; }
        }
        public string Rto_Place
        {
            get { return _rto_place; }
            set { _rto_place = value; }
        }
        public string Rto_Amount
        {
            get { return _rto_amount; }
            set { _rto_amount = value; }
        }
        public string Other_Reason
        {
            get { return _other_reason; }
            set { _other_reason = value; }
        }
        public string Other_Amount
        {
            get { return _other_amount; }
            set { _other_amount = value; }
        }
        public string Load_Wages
        {
            get { return _load_wages; }
            set { _load_wages = value; }
        }
        public string Unload_Wages
        {
            get { return _unload_wages; }
            set { _unload_wages = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Spares
        {
            get { return _spares; }
            set { _spares = value; }
        }
        public string Driver_Wages
        {
            get { return _driver_wages; }
            set { _driver_wages = value; }
        }
        public string Clener_Wages
        {
            get { return _clener_wages ; }
            set { _clener_wages = value; }
        }


        //Trip Update
        private string _update_trip_number;
        private string _update_corporation;
        private string _update_driver_name;
        private string _update_origin;
        private string _update_destination;
        private string _update_load_weight;
        private string _update_end_km;
        private string _update_unload_weight;
        private string _update_frieght;
        private string _update_advance;
        private string _date;
        private string _pay_type;
        private string _update_price;
        private string _update_amount;
        private string _update_litter;
        private string _update_load_wages; 
        private string _update_unload_wages;
        private string _update_phone;
        private string _update_spares;
        private string _update_driver_wages;
        private string _update_clener_wages;
        private string _update_toll_place;
        private string _update_toll_amount;
        private string _update_rto_place;
        private string _update_rto_amount;
        private string _update_other_reason;
        private string _update_other_amount; 
        public string Vehicle_Numbers 
        {
            get { return _update_trip_number; }
            set { _update_trip_number = value; }
        }
        public string Update_Corporation
        {
            get { return _update_corporation; }
            set { _update_corporation = value; }
        }
        public string Update_Driver_Name
        {
            get { return _update_driver_name; }
            set { _update_driver_name = value; }
        }
        public string Update_Origin
        {
            get { return _update_origin; }
            set { _update_origin = value; }
        }
        public string Update_Destination
        {
            get { return _update_destination; }
            set { _update_destination = value; }
        }
        public string Update_Load_Weight
        {
            get { return _update_load_weight; }
            set { _update_load_weight = value; } 
        }
        public string Update_End_Km
        {
            get { return _update_end_km; }
            set { _update_end_km = value; }
        }
        public string Update_Unload_Weight
        {
            get { return _update_unload_weight; }
            set { _update_unload_weight = value; }
        }
        public string Update_Frieght
        {
            get { return _update_frieght; }
            set { _update_frieght = value; }
        }
        public string Update_Advance
        {
            get { return _update_advance; }
            set { _update_advance = value; }
        }
        
        public string Pay_Type
        {
            get { return _pay_type; }
            set { _pay_type = value; }
        }
        public string Date
        { get { return _date; }
          set { _date = value; }
        }
        public string Update_Price
        {
            get { return _update_price; }
            set { _update_price = value; }
        }
        public string Update_Litter
        {
            get { return _update_litter; }
            set { _update_litter = value; }
        }
        public string Update_Amount
        {
            get { return _update_amount; }
            set { _update_amount = value; }
        }
        public string Update_Toll_Amount
        {
            get { return _update_toll_amount; }
            set { _update_toll_amount = value; }
        }
        public string Update_Toll_Place
        {
            get { return _update_toll_place; }
            set { _update_toll_place = value; }
        }
        public string Update_Rto_Place
        {
            get { return _update_rto_place; }
            set { _update_rto_place = value; }
        }
        public string Update_Rto_Amount
        {
            get { return _update_rto_amount; }
            set { _update_rto_amount = value; }
        }
        public string Update_Other_Reason
        {
            get { return _update_other_reason; }
            set { _update_other_reason = value; }
        }
        public string Update_Other_Amount
        {
            get { return _update_other_amount; }
            set { _update_other_amount = value; }
        }
        public string Update_Load_Wages
        {
            get { return _update_load_wages; }
            set { _update_load_wages = value; }
        }
        public string Update_Unload_Wages
        {
            get { return _update_unload_wages; }
            set { _update_unload_wages = value; }
        }
        public string Update_Phone
        {
            get { return _update_phone; }
            set { _update_phone = value; }
        }
        public string Update_Spares
        {
            get { return _update_spares; }
            set { _update_spares = value; }
        }
        public string Update_Driver_Wages
        {
            get { return _update_driver_wages; }
            set { _update_driver_wages = value; }
        }
        public string Update_Clener_Wages 
        {
            get { return _update_clener_wages; }
            set { _update_clener_wages = value; }
        }


        //Trip View
        private string _trip_view_number;
        private string _trip_view_month;
        private string _trip_view_year;
        private string _trip_vehicle_number;
        public string Trip_Vehicle_Number
        {
            get { return _trip_vehicle_number; }
            set { _trip_vehicle_number = value; }
        }
        public string Trip_View_Number
        {
            get { return _trip_view_number; }
            set { _trip_view_number = value; }
        }
        public string Trip_View_Month
        {
            get { return _trip_view_month; }
            set { _trip_view_month = value; }
        }
        public string  Trip_View_Year
        {
            get { return _trip_view_year; }
            set { _trip_view_year = value; }
        }
        //Maintenance
        //Body Expense
        private string _body_vehicle_number;
        private string _description;
        private string _quantity;
        private string _rate;
        private string _bill_no;
        private string _discount;
        private string _bill_num;
        public string Body_Vehicle_Number
        {
            get { return _body_vehicle_number; }
            set { _body_vehicle_number = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        public string Bill_No
        {
            get { return _bill_no; }
            set { _bill_no = value; }
        }
        public string Discount  
        {
            get { return _discount; }
            set { _discount = value; }
        }
        public string Bill_Num
        {
            get { return _bill_num; }
            set { _bill_num = value; }
        }
        //Electrician Expense
        private string _elc_vehicle_number;
        private string _elc_description;
        private string _elc_quantity;
        private string _elc_rate;
        private string _elc_bill_no;
        private string _elc_discount;
        private string _elc_bill_num;
        public string Elc_Vehicle_Number 
        {
            get { return _elc_vehicle_number; }
            set { _elc_vehicle_number = value; }
        }
        public string Elc_Description
        {
            get { return _elc_description; }
            set { _elc_description = value; }
        }
        public string Elc_Quantity
        {
            get { return _elc_quantity; }
            set { _elc_quantity = value; }
        }
        public string Elc_Rate
        {
            get { return _elc_rate; }
            set { _elc_rate = value; }
        }
        public string Elc_Bill_No
        {
            get { return _elc_bill_no; }
            set { _elc_bill_no = value; }
        }
        public string Elc_Discount
        {
            get { return _elc_discount; }
            set { _elc_discount = value; }
        }
        public string Elc_Bill_Num 
        {
            get { return _elc_bill_num; }
            set { _elc_bill_num = value; }
        }
        //Mechanical Expense
        private string _mech_vehicle_number;
        private string _mech_description;
        private string _mech_quantity;
        private string _mech_rate;
        private string _mech_bill_no;
        private string _mech_discount;
        private string _mech_bill_num;
        private string _km;
        public string Mech_Vehicle_Number 
        {
            get { return _mech_vehicle_number; }
            set { _mech_vehicle_number = value; }
        }
        public string Mech_Description
        {
            get { return _mech_description; }
            set { _mech_description = value; }
        }
        public string Mech_Quantity
        {
            get { return _mech_quantity; }
            set { _mech_quantity = value; }
        }
        public string Mech_Rate
        {
            get { return _mech_rate; }
            set { _mech_rate = value; }
        }
        public string Mech_Bill_No
        {
            get { return _mech_bill_no; }
            set { _mech_bill_no = value; }
        }
        public string Mech_Discount
        {
            get { return _mech_discount; }
            set { _mech_discount = value; }
        }
        public string Mech_Bill_Num
        {
            get { return _mech_bill_num; }
            set { _mech_bill_num = value; }
        }
        public string KM
        {
            get { return _km; }
            set { _km = value; }
        }
        //Other Expense
        private string _other_vehicle_number;
        private string _other_description;
        private string _other_quantity;
        private string _other_rate;
        private string _other_bill_no;
        private string _other_discount;
        private string _other_bill_num;
        public string Other_Vehicle_Number
        {
            get { return _other_vehicle_number; }
            set { _other_vehicle_number = value; }
        }
        public string Other_Description 
        {
            get { return _other_description; }
            set { _other_description = value; }
        }
        public string Other_Quantity
        {
            get { return _other_quantity; }
            set { _other_quantity = value; }
        }
        public string Other_Rate
        {
            get { return _other_rate; }
            set { _other_rate = value; }
        }
        public string Other_Bill_No
        {
            get { return _other_bill_no; }
            set { _other_bill_no = value; }
        }
        public string Other_Discount
        {
            get { return _other_discount; }
            set { _other_discount = value; }
        }
        public string Other_Bill_Num
        {
            get { return _other_bill_num; }
            set { _other_bill_num = value; }
        }
        //Shop Expense
        private string _shop_vehicle_number;
        private string _shop_description;
        private string _shop_quantity;
        private string _shop_rate;
        private string _shop_bill_no;
        private string _shop_discount;
        private string _shop_bill_num;
        public string Shop_Vehicle_Number
        {
            get { return _shop_vehicle_number; }
            set { _shop_vehicle_number = value; }
        }
        public string Shop_Description
        {
            get { return _shop_description; }
            set { _shop_description = value; }
        }
        public string Shop_Quantity
        {
            get { return _shop_quantity; }
            set { _shop_quantity = value; }
        }
        public string Shop_Rate
        {
            get { return _shop_rate; }
            set { _shop_rate = value; }
        }
        public string Shop_Bill_No
        {
            get { return _shop_bill_no; }
            set { _shop_bill_no = value; }
        }
        public string Shop_Discount
        {
            get { return _shop_discount; }
            set { _shop_discount = value; }
        }
        public string Shop_Bill_Num
        {
            get { return _shop_bill_num; }
            set { _shop_bill_num = value; }
        }
        //Tank Expense
        private string _tank_vehicle_number;
        private string _tank_description;
        private string _tank_quantity;
        private string _tank_rate;
        private string _tank_bill_no;
        private string _tank_discount;
        private string _tank_bill_num;
        public string Tank_Vehicle_Number
        {
            get { return _tank_vehicle_number; }
            set { _tank_vehicle_number = value; }
        }
        public string Tank_Description
        {
            get { return _tank_description; }
            set { _tank_description = value; }
        }
        public string Tank_Quantity
        {
            get { return _tank_quantity; }
            set { _tank_quantity = value; }
        }
        public string Tank_Rate
        {
            get { return _tank_rate; }
            set { _tank_rate = value; }
        }
        public string Tank_Bill_No
        {
            get { return _tank_bill_no; }
            set { _tank_bill_no = value; }
        }
        public string Tank_Discount
        {
            get { return _tank_discount; }
            set { _tank_discount = value; }
        }
        public string Tank_Bill_Num 
        {
            get { return _tank_bill_num; }
            set { _tank_bill_num = value; }
        }
        //Maintenance View
        private string maintenance_number;
        private string maintenance_month;
        private string maintenance_year;
        public string Maintenance_Number
        {
            get { return maintenance_number; }
            set { maintenance_number = value; }
        }
        public string Maintenance_Month
        {
            get { return maintenance_month; }
            set { maintenance_month = value; }
        }
        public string Maintenance_Year
        {
            get { return maintenance_year; }
            set { maintenance_year = value; }
        }
        //Tyre Maintenance
        private string _tyre_vehicle_number;
        private string _tyre_no;
        private string _start_km;
        private string _tyre_company;
        private string _tyre_price;
        public string Tyre_Vehicle_Number
        {
            get { return _tyre_vehicle_number; }
            set { _tyre_vehicle_number = value; }
        }
        public string Tyre_No
        {
            get { return _tyre_no; }
            set { _tyre_no = value; }
        }
        public string Start_Km
        {
            get { return _start_km; }
            set { _start_km = value; }
        }
        public string Tyre_Company
        {
            get { return _tyre_company; }
            set { _tyre_company = value; }
        }
        public string Tyre_Price
        {
            get { return _tyre_price; }
            set { _tyre_price = value; }
        }

        // Report View
        private string report_vehicle;
        private string report_month;
        private string report_year;
        public string Report_Vehicle
        {
            get { return report_vehicle; }
            set { report_vehicle = value; }
        }
        public string Report_Month
        {
            get { return report_month; }
            set { report_month = value; }
        }
        public string Report_Year
        {
            get { return report_year; }
            set { report_year = value; }
        }
    }
}
