const cartIcon = document.querySelector("#cart-icon");
const cart = document.querySelector(".cart");
const cartClose = document.querySelector("#cart-close");
cartIcon.addEventListener("click", () => cart.classList.add("active"));
cartClose.addEventListener("click", () => cart.classList.remove("active"));

const addCartButtons = document.querySelectorAll(".add-cart");
addCartButtons.forEach(button => {
    button.addEventListener("click", event => {
        const productBox = event.target.closest(".product-box");
        addToCart(productBox);
    });
});

const cartContent = document.querySelector(".cart-content");

const addToCart = (productBox) => {
    const productImgSrc = productBox.querySelector(".img-box img").src;
    const productTitle = productBox.querySelector(".product-title").textContent;
    const productPrice = productBox.querySelector(".price").textContent;

    const cartItems = cartContent.querySelectorAll(".cart-product-title");
    for (let item of cartItems) {
        if (item.textContent === productTitle) {
            alert("This item is already in the cart.");
            return;
        }
    }

    const cartBox = document.createElement("div");
    cartBox.classList.add("cart-box");
    cartBox.innerHTML = `
        <img src="${productImgSrc}" class="cart-img">
        <div class="card-detail">
            <h2 class="cart-product-title">${productTitle}</h2>
            <span class="cart-price">${productPrice}</span>
            <div class="cart-quantity">
                <button class="decrement">-</button>
                <span class="number">1</span>
                <button class="increment">+</button>
            </div>
        </div>
        <i class="ri-delete-bin-line cart-remove"></i>
    `;

    cartContent.appendChild(cartBox);
    cart.classList.add("active");

    cartBox.querySelector(".cart-remove").addEventListener("click", () => {
        cartBox.remove();

        updateCartCount(-1);

        updateTotalPrice();
    });

    cartBox.querySelector(".cart-quantity").addEventListener("click", event => {
        const numberElement = cartBox.querySelector(".number");
        const decrementButton = cartBox.querySelector(".decrement");
        let quantity = parseInt(numberElement.textContent);

        if (event.target.classList.contains("decrement") && quantity > 1) {
            quantity--;
        } else if (event.target.classList.contains("increment")) {
            quantity++;
        }

        numberElement.textContent = quantity;
        updateTotalPrice();
    });
    updateCartCount(1);
    
    updateTotalPrice();
};

const updateTotalPrice = () => {
    const totalPriceElement = document.querySelector(".total-price");
    const cartBoxes = cartContent.querySelectorAll(".cart-box");
    let total = 0;

    cartBoxes.forEach(cartBox => {
        const priceElement = cartBox.querySelector(".cart-price");
        const quantityElement = cartBox.querySelector(".number");
        let price = parseFloat(priceElement.textContent.replace("lei", "").trim());
        let quantity = parseInt(quantityElement.textContent);

        if (!isNaN(price) && !isNaN(quantity)) {
            total += price * quantity;
        }
    });

    totalPriceElement.textContent = `${total} lei`;
};

let cartItemCount = 0;
const updateCartCount = (change) => {
    const cartItemCountBadge = document.querySelector(".cart-item-count");
    cartItemCount += change;
    if (cartItemCount > 0) {
        cartItemCountBadge.style.visibility = "visible";
        cartItemCountBadge.textContent = cartItemCount;
    } else {
        cartItemCountBadge.style.visibility = "hidden";
        cartItemCountBadge.textContent = "";
    }
};


const buyNowButton = document.querySelector(".btn-buy");

document.addEventListener("DOMContentLoaded", function () {
  const modal = document.getElementById("reservation-modal");
  const closeModalBtn = document.getElementById("close-modal");
  const confirmBtn = document.getElementById("confirm-reservation");
  const eventDateInput = document.getElementById("event-date");
  const eventTimeInput = document.getElementById("event-time");
  const buyNowButton = document.getElementById("buy-now-button");

  function setMinDateTime() {
    const now = new Date();
    const yyyy = now.getFullYear();
    const mm = String(now.getMonth() + 1).padStart(2, '0');
    const dd = String(now.getDate()).padStart(2, '0');
    const hh = String(now.getHours()).padStart(2, '0');
    const min = String(now.getMinutes()).padStart(2, '0');

    eventDateInput.min = `${yyyy}-${mm}-${dd}`;
    eventTimeInput.min = `${hh}:${min}`;
  }

  setMinDateTime();

  buyNowButton.addEventListener("click", () => {
    modal.style.display = "flex";
    setMinDateTime();
  });

  closeModalBtn.addEventListener("click", () => {
    modal.style.display = "none";
  });

  confirmBtn.addEventListener("click", async (e) => {
    e.preventDefault();

    const isAuthenticated = localStorage.getItem("isAuthenticated") === "true";
    const isLoggedIn = localStorage.getItem("isLoggedIn") === "true";

    if (!(isAuthenticated && isLoggedIn)) {
        alert("Trebuie să fii logat pentru a accesa această secțiune.");
        window.location.href = "authentification.html";
        return;
    }

    // Colectează datele
    const dateValue = eventDateInput.value;
    const timeValue = eventTimeInput.value;
    const numPersons = document.getElementById("num-persons").value;
    const eventType = document.getElementById("event-type").value;
    const phoneNumber = document.getElementById("phone-number").value;

    if (!dateValue || !timeValue || !numPersons || !eventType || !phoneNumber) {
        alert("Te rog completează toate câmpurile.");
        return;
    }

    const phoneRegex = /^[0-9\s\-+()]{7,15}$/;
    if (!phoneRegex.test(phoneNumber)) {
        alert("Te rog să introduci un număr de telefon valid.");
        return;
    }

    const selectedDateTime = new Date(`${dateValue}T${timeValue}`);
    const now = new Date();

    if (selectedDateTime <= now) {
        alert("Data și ora trebuie să fie în viitor.");
        return;
    }

    // Trimite datele către backend (exemplu cu fetch POST)NASTEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaaa
    try {
        const response = await fetch("/api/reservari", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                date: dateValue,
                time: timeValue,
                persons: numPersons,
                type: eventType,
                phone: phoneNumber
            })
        });

        if (response.ok) {
            alert("Rezervarea a fost înregistrată cu succes!");
            modal.style.display = "none";
            cart.classList.remove("active");
        } else {
            const result = await response.json();
            alert(`Eroare la trimitere: ${result.message || 'necunoscută'}`);
        }
    } catch (error) {
        alert("A apărut o eroare la conectarea cu serverul.");
        console.error(error);
    }
});
});