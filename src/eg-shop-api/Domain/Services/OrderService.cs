namespace EgShopApi.Domain.Services
{
    public class OrderService
    {
        private const string GroceriesFile = "src/eg-shop-api/Entities/Groceries.json";
        private const string OrderTransFile = "src/eg-shop-api/Entities/OrderTrans.json";
        private const string InvoiceTransFile = "src/eg-shop-api/Entities/InvoiceTrans.json";
        private const string OrderTemplateFile = "src/eg-shop-api/Entities/Order.json";
        private const string InvoiceTemplateFile = "src/eg-shop-api/Entities/Invoice.json";

        public async Task<List<string>> GetGroceriesAsync()
        {
            using var stream = File.OpenRead(GroceriesFile);
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var groceries = new List<string>();
            foreach (var element in jsonDoc.RootElement.GetProperty("groceries").EnumerateArray())
            {
                groceries.Add(element.GetString() ?? string.Empty);
            }
            return groceries;
        }

        public async Task WriteOrderAsync(object order)
        {
            var orderJson = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(OrderTransFile, orderJson);
        }

        public async Task GenerateInvoiceAsync()
        {
            if (!File.Exists(OrderTransFile) || !File.Exists(InvoiceTemplateFile))
                return;

            var orderJson = await File.ReadAllTextAsync(OrderTransFile);
            var invoiceTemplateJson = await File.ReadAllTextAsync(InvoiceTemplateFile);

            using var orderDoc = JsonDocument.Parse(orderJson);
            using var invoiceDoc = JsonDocument.Parse(invoiceTemplateJson);

            var orderRoot = orderDoc.RootElement;
            var invoiceRoot = invoiceDoc.RootElement;

            // Create invoice based on order and invoice template
            var invoice = new
            {
                customer = orderRoot.GetProperty("customer").GetInt32(),
                invoice_number = invoiceRoot.GetProperty("invoice_number").GetInt32(),
                items = orderRoot.GetProperty("item_lines").EnumerateArray(),
                loyalty_membership = invoiceRoot.GetProperty("loyalty_membership"),
                total = orderRoot.GetProperty("total").GetDecimal()
            };

            var invoiceJson = JsonSerializer.Serialize(invoice, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(InvoiceTransFile, invoiceJson);
        }
    }
}
