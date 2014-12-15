using System;
using System.Text;

namespace com.thoughtworks.refactoring
{

/**
 * OrderReceipt prints the details of order including customer name, address, description, quantity,
 * price and amount. It also calculates the sales tax @ 10% and prints as part
 * of order. It computes the total order amount (amount of individual lineItems +
 * total sales tax) and prints it.
 * 
 */
public class OrderReceipt {
    private Order o;

    public OrderReceipt(Order o) {
        this.o = o;
	}

	public String printReceipt() {
		StringBuilder output = new StringBuilder();

		// print headers
			output.Append("======Printing Orders======\n");

		// print date, bill no, customer name
//        output.append("Date - " + order.getDate();
			output.Append(o.GetCustomerName());
			output.Append(o.GetCustomerAddress());
//        output.append(order.getCustomerLoyaltyNumber());

		// prints lineItems
		double totSalesTx = 0d;
		double tot = 0d;
			foreach (LineItem lineItem in o.GetLineItems()) {
				output.Append(lineItem.GetDescription());
				output.Append('\t');
				output.Append(lineItem.GetPrice());
				output.Append('\t');
				output.Append(lineItem.GetQuantity());
				output.Append('\t');
				output.Append(lineItem.TotalAmount());
				output.Append('\n');
			// calculate sales tax @ rate of 10%
				double salesTax = lineItem.TotalAmount() * .10;
            totSalesTx += salesTax;

            // calculate total amount of lineItem = price * quantity + 10 % sales tax
				tot += lineItem.TotalAmount() + salesTax;
		}

		// prints the state tax
			output.Append("Sales Tax").Append('\t').Append(totSalesTx);

        // print total amount
			output.Append("Total Amount").Append('\t').Append(tot);
			return output.ToString();
	}
}
}