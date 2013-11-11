using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Jaed Norberg
    /// Last Updated: 10/20/2013 
    /// 
    /// This class is used to store list data that the listview
    /// reads from. It stores a list of TransactionItem classes.
    /// </summary>
    class TransactionList
    {
        public List<TransactionItem> transData = new List<TransactionItem>();

        // ADD ITEM
        // Attempts to add an item with the specified values, with ID being the key. If
        // it finds a match, it will increase the quantity. If not, it will add a new
        // item to the list.
        public void addItem(int id, string name, double price, int quantity, double discount)
        {
            TransactionItem newItem;

            try
            {
                bool foundMatch = false;

                // This particular section combines all items with a given ID.
                // It has been removed so items can be scanned separately
                // with an additional quantity input, and discounts applied
                // to each group.
                /*foreach (TransactionItem t in transData)
                {
                    if (id == t.getID())
                    {
                        t.setQuantity(t.getQuantity() + quantity);
                        t.updateTotal();
                        foundMatch = true;
                        break;
                    }
                }*/

                //if (!foundMatch)
                {
                    newItem = new TransactionItem(id, name, price, quantity, discount);
                    if (newItem != null)
                        transData.Add(newItem);
                }
            }
            catch (Exception ex)
            {
            }
        }


        // DELETE ITEM
        // Attempts to delete an item at the specified list position,
        // first decrementing it by the given quantity, or if the
        // quantity exceeds what's in the list, it will remove it
        // entirely.
        public void deleteItem(int pos, int quantity)
        {
            try
            {
                TransactionItem t = transData.ElementAt(pos);

                if (t.getQuantity() > quantity)
                {
                    t.setQuantity(t.getQuantity() - quantity);
                    t.updateTotal();
                }
                else
                    transData.RemoveAt(pos);
            }
            catch (Exception ex)
            {
            }
        }


        // CLEAR DATA
        // Removes all data from the list.
        public void clearData()
        {
            try
            {
                transData.Clear();
            }
            catch (Exception ex)
            {
            }
        }
    }


    /// <summary>
    /// Programmer: Jaed Norberg
    /// Last Updated: 10/20/2013 
    /// 
    /// This class is used by the TransactionList class.
    /// Each instance stores the data that would otherwise
    /// appear in a row on the listview.
    /// </summary>
    class TransactionItem
    {
        int id;
        string name;
        double price;
        int quantity;
        double discount;
        double total;

        public TransactionItem()
        {
            this.id = 0;
            this.name = "Nothing";
            this.price = 0.00;
            this.quantity = 0;
            this.discount = 0.00;

            this.total = price - discount;
        }

        public TransactionItem(int id, string name, double price, int quantity, double discount)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.discount = discount;

            this.total = quantity * (price - discount);
        }

        public void updateTotal()
        {
            this.total = quantity * (price - discount);
        }


        //----------------------------------------
        // Getters
        //----------------------------------------
        public int getID()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public double getPrice()
        {
            return price;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public double getDiscount()
        {
            return discount;
        }

        public double getTotal()
        {
            return total;
        }


        //----------------------------------------
        // Setters
        //----------------------------------------
        public void setPrice(double newPrice)
        {
            this.price = newPrice;
        }

        public void setQuantity(int newQuantity)
        {
            this.quantity = newQuantity;
        }

        public void setDiscount(double newDiscount)
        {
            this.discount = newDiscount;
        }
    }
}
