document.addEventListener("DOMContentLoaded", function () {
    // Filter menu items by category
    document.getElementById("category-container").addEventListener("click", function (e) {
        if (e.target.classList.contains("category-filter")) {
            let category = e.target.dataset.category;
            document.querySelectorAll(".menu-item").forEach(item => {
                if (category === "all" || item.dataset.category === category) {
                    item.style.display = "flex"; // Assuming flexbox layout
                } else {
                    item.style.display = "none";
                }
            });
        }
    });

    // Add to cart functionality with quantity tracking
    document.getElementById("menu-container").addEventListener("click", function (e) {
        if (e.target.classList.contains("add-to-cart")) {
            let itemName = e.target.closest(".menu-item").querySelector("h5").innerText;
            let cart = document.getElementById("cart-items");

            // Check if item is already in the cart
            let existingItem = cart.querySelector(`.cart-item[data-name="${itemName}"]`);
            if (existingItem) {
                let quantityElement = existingItem.querySelector(".item-quantity");
                quantityElement.innerText = parseInt(quantityElement.innerText) + 1;
            } else {
                // Create a new cart item entry
                let newItem = document.createElement("div");
                newItem.classList.add("cart-item");
                newItem.dataset.name = itemName;
                newItem.innerHTML = `
                    <span>${itemName}</span> 
                    <span class="item-quantity">1</span>
                    <button class="remove-item">❌</button>
                `;
                cart.appendChild(newItem);
            }
        }
    });

    // Remove from cart
    document.getElementById("cart-items").addEventListener("click", function (e) {
        if (e.target.classList.contains("remove-item")) {
            e.target.parentElement.remove();
        }
    });
});
