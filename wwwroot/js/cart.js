@section Scripts {
    <script>
        const tableId = 1; // Replace with actual table ID
        const userId = 1;  // Replace with actual user ID

        $(document).ready(function () {
            loadCart();

        // Add to cart
        $(".add-to-cart").click(function () {
            let menuId = $(this).data("id");
        let price = $(this).data("price");

        $.post('/Cart/AddToCart', {
            tableId: tableId,
        userId: userId,
        menuItemId: menuId,
        price: price
            }, function () {
            loadCart();
            });
        });

        // Submit Order
        $("#submitOrder").click(function () {
            $.post('/Cart/SubmitOrder', {
                tableId: tableId,
                userId: userId
            }, function () {
                loadCart();
                alert("Order Submitted!");
            });
        });

        // Load cart items
        function loadCart() {
            $.get('/Cart/GetCartItems', { tableId: tableId, userId: userId }, function (data) {
                $("#cartItems").html(data);
            });
        }

        // Print Bill (just for demo)
        $("#printBill").click(function () {
            window.print();
        });
    });
    </script>
}
